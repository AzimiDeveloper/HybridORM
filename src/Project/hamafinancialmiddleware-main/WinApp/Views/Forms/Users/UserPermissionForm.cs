using DevExpress.Data.Linq;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList.Nodes;
using Hama.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Hama.Share.Tools;
using Hama.WinApp.Views.Components;
using Hama.Service.Interfaces.ORM;
using Hama.WinApp.Helpers.UI.Notifications;
using Hama.WinApp.Helpers.UI.Grid;
using Hama.WinApp.Helpers.UI.Loading;
using Hama.WinApp.Helpers.UI.Fillers;
using Hama.Share.Results;

namespace Hama.WinApp.Views.Forms.Users
{
    public partial class UserPermissionForm : BaseForm
    {
        private readonly IBaseServiceEf<Role> _efRoleService;
        private readonly IBaseServiceEf<User> _efUserService;
        private readonly IBaseServiceEf<Permission> _efPermissionService;
        private readonly IBaseServiceEf<UserPermission> _efUserPermissionService;
        private readonly IBaseServiceEf<RolePermission> _efRolePermissionService;

        private readonly IBaseRepoDbService<Role> _repoRoleService;
        private readonly IBaseRepoDbService<User> _repoUserService;
        private readonly IBaseRepoDbService<Permission> _repoPermissionService;
        private readonly IBaseRepoDbService<UserPermission> _repoUserPermissionService;
        private readonly IBaseRepoDbService<RolePermission> _repoRolePermissionService;

        LinqServerModeSource PermissionData = new();
        LinqServerModeSource roleData = new();
        LinqServerModeSource UserData = new();

        public UserPermissionForm(
            IBaseServiceEf<Role> efRoleService,
            IBaseServiceEf<User> efUserService,
            IBaseServiceEf<Permission> efPermissionService,
            IBaseServiceEf<UserPermission> efUserPermissionService,
            IBaseServiceEf<RolePermission> efRolePermissionService,
            IBaseRepoDbService<Role> repoRoleService,
            IBaseRepoDbService<User> repoUserService,
            IBaseRepoDbService<Permission> repoPermissionService,
            IBaseRepoDbService<UserPermission> repoUserPermissionService,
            IBaseRepoDbService<RolePermission> repoRolePermissionService)
        {
            InitializeComponent();

            _efRoleService = efRoleService;
            _efUserService = efUserService;
            _efPermissionService = efPermissionService;
            _efUserPermissionService = efUserPermissionService;
            _efRolePermissionService = efRolePermissionService;

            _repoRoleService = repoRoleService;
            _repoUserService = repoUserService;
            _repoPermissionService = repoPermissionService;
            _repoUserPermissionService = repoUserPermissionService;
            _repoRolePermissionService = repoRolePermissionService;

            _visibleBarItems = new BarItem[] {
                barButtonItemSave,
                barButtonItemDelete
            };

            InitializeBarItemVisible(_visibleBarItems);
        }


        public override async Task InitializeList()
        {
            await base.InitializeList();
            await LoadingHelper.ProcessAsync(this, async () =>
            {
                // Roles
                var resultRole = await _efRoleService.EfGetQueryable(null);
                if (!resultRole.Success)
                    AlertHelper.ShowError(this, string.Join("\n", resultRole.Errors));

                roleData = new LinqServerModeSource
                {
                    KeyExpression = "Id",
                    QueryableSource = resultRole.Data.Select(r => new { r.Id, r.Name })
                };

                 await FillerHelper.SetData(lueRoleCode_user, roleData, "Id", "Name", "Name");
                 await FillerHelper.SetData(lueUserRoleCode, roleData, "Id", "Name", "Name");

                // Users
                var resultUser = await _efUserService.EfGetQueryable(null);
                if (!resultUser.Success)
                    AlertHelper.ShowError(this, string.Join("\n", resultUser.Errors));

                UserData = new LinqServerModeSource
                {
                    KeyExpression = "Id",
                    QueryableSource = resultUser.Data.Select(u => new
                    {
                        u.Id,
                        UserFullName = u.FirstName + " " + u.LastName + $" [{u.UserName}]"
                    })
                };

                 await FillerHelper.SetData(lueUserCodeAdd, UserData, "Id", "UserFullName", "UserFullName");
                 await FillerHelper.SetData(lueUserCode_user, UserData, "Id", "UserFullName", "UserFullName");
                 await FillerHelper.SetData(lueUserUserCode, UserData, "Id", "UserFullName", "UserFullName");

                lueUserRoleCode.EditValueChanged += LueUserRoleCode_EditValueChanged;
                lueUserUserCode.EditValueChanged += LueUserUserCode_EditValueChanged;

                // Permissions
                var resultPermission = await _efPermissionService.EfGetQueryable(null);
                if (!resultPermission.Success)
                    AlertHelper.ShowError(this, string.Join("\n", resultPermission.Errors));

                PermissionData = new LinqServerModeSource
                {
                    KeyExpression = "Id",
                    QueryableSource = resultPermission.Data.Select(p => new
                    {
                        p.Id,
                        p.Description,
                        p.ParentId
                    }).OrderBy(p => p.ParentId)
                };

                trvUserControl.OptionsView.ShowCheckBoxes = true;
                trvUserControl.ParentFieldName = "ParentId";
                trvUserControl.KeyFieldName = "Id";
                trvUserControl.DataSource = PermissionData;
                trvUserControl.RootValue = 0;
                trvUserControl.AfterCheckNode += TrvUserControl_AfterCheckNode;
                trvUserControl.Columns["Description"].Caption = "دسترسی ها";

            });
        }
        public override async Task ActionSave()
        {
            ServiceResult<bool> saveResult = null;

            await LoadingHelper.ProcessAsync(this, async () =>
            {
                try
                {
                    if (tabPaneMain.SelectedPage == tabPaneMain.Pages[0])
                    {
                        if (!tgsUser.IsOn)
                        {
                            if (lueUserRoleCode.EditValue == null)
                            {
                                AlertHelper.ShowWarning(this, "لطفاً نقش کاربری را انتخاب کنید.");
                                return;
                            }

                            int roleId = (int)lueUserRoleCode.EditValue;
                            var existingPermissionsResult = await _efRolePermissionService.EfGetAsync(x => x.RoleId == roleId);
                            if (!existingPermissionsResult.Success)
                                AlertHelper.ShowError(this, string.Join("\n", existingPermissionsResult.Errors));

                            var existingPermissions = existingPermissionsResult.Data;

                            var checkedPermissions = new List<int>();
                            var uncheckedPermissions = new List<int>();
                            foreach (TreeListNode node in trvUserControl.Nodes)
                                GetCheckedAndUncheckedNodes(node, checkedPermissions, uncheckedPermissions);

                            var toDelete = existingPermissions
                                .Where(x => uncheckedPermissions.Contains(x.PermissionId) && x.RoleId == roleId)
                                .ToList();

                            var toInsert = checkedPermissions
                                .Where(pid => !existingPermissions.Any(x => x.PermissionId == pid && x.RoleId == roleId))
                                .Select(pid => new RolePermission { RoleId = roleId, PermissionId = pid })
                                .ToList();

                            if (toDelete.Any())
                                saveResult = await _repoRolePermissionService.RepoDeleteBulkAsync(toDelete);

                            if (toInsert.Any())
                                saveResult = await _repoRolePermissionService.RepoInsertBulkAsync(toInsert);

                            if ((toDelete.Any() || toInsert.Any()) && saveResult?.Success == true)
                            {
                                AlertHelper.ShowSuccess(this, "عملیات تخصیص دسترسی با موفقیت انجام شد.");
                            }
                            else if (saveResult != null && !saveResult.Success)
                            {
                                AlertHelper.ShowError(this, "خطا در تخصیص دسترسی : " + saveResult.Message);
                            }
                        }
                        else
                        {
                            if (lueUserUserCode.EditValue == null)
                            {
                                AlertHelper.ShowWarning(this, "لطفاً کاربر را انتخاب کنید.");
                                return;
                            }

                            int userId = (int)lueUserUserCode.EditValue;
                            var existingPermissionsResult = await _efUserPermissionService.EfGetAsync(x => x.UserId == userId);
                            if (!existingPermissionsResult.Success)
                                AlertHelper.ShowError(this, string.Join("\n", existingPermissionsResult.Errors));

                            var existingPermissions = existingPermissionsResult.Data;

                            var checkedPermissions = new List<int>();
                            var uncheckedPermissions = new List<int>();
                            foreach (TreeListNode node in trvUserControl.Nodes)
                                GetCheckedAndUncheckedNodes(node, checkedPermissions, uncheckedPermissions);

                            var toDelete = existingPermissions
                                .Where(x => uncheckedPermissions.Contains(x.PermissionId) && x.UserId == userId)
                                .ToList();

                            var toInsert = checkedPermissions
                                .Where(pid => !existingPermissions.Any(x => x.PermissionId == pid && x.UserId == userId))
                                .Select(pid => new UserPermission { UserId = userId, PermissionId = pid })
                                .ToList();

                            if (toDelete.Any())
                                saveResult = await _repoUserPermissionService.RepoDeleteBulkAsync(toDelete);

                            if (toInsert.Any())
                                saveResult = await _repoUserPermissionService.RepoInsertBulkAsync(toInsert);

                            if ((toDelete.Any() || toInsert.Any()) && saveResult?.Success == true)
                            {
                                AlertHelper.ShowSuccess(this, "عملیات تخصیص دسترسی با موفقیت انجام شد.");
                                await LoadSelectedNodeUsers();
                            }
                            else if (saveResult != null && !saveResult.Success)
                            {
                                AlertHelper.ShowError(this, "خطا در تخصیص دسترسی : " + string.Join(",", saveResult.Errors));
                            }
                        }
                    }
                    else
                    {
                        await AddUserInRole();
                    }
                }
                catch (Exception ex)
                {
                    AlertHelper.ShowError(this, $"خطای غیرمنتظره:\n{ex.Message}");
                }
            });
        }
        public override async Task SetTitle(GridView grid)
        {
            await base.SetTitle(grid);
            if (grid.Columns["Id"] != null)
                grid.Columns["Id"].Visible = false;

            if (grid.Columns["UserFullName"] != null)
                grid.Columns["UserFullName"].Caption = "نام کاربر";

        }
        public override async Task ActionDelete()
        {
            try
            {
                var selectedNode = trvUserControl.FocusedNode;
                if (selectedNode == null)
                {
                    AlertHelper.ShowError(this, "لطفاً یک دسترسی را انتخاب کنید.");
                    return ;
                }

                var permissionId = Convert.ToInt32(selectedNode.GetValue("Id"));
                var selectedUserId = gridViewUser.GetFocusedRowCellValue("Id");

                if (selectedUserId == null)
                {
                    AlertHelper.ShowError(this, "لطفاً یک کاربر جهت حذف انتخاب کنید.");
                    return ;
                }

                var result = await _efUserPermissionService.EfGetAsync(
                    a => a.UserId == (int)selectedUserId && a.PermissionId == permissionId
                );

                if (!result.Success || !result.Data.Any())
                {
                    AlertHelper.ShowError(this, "کاربر انتخاب شده برای این دسترسی موجود نیست.");
                    return ;
                }

                var entity = result.Data.First();

                var confirm = ConfirmDialogHelper.Show(
                    message: "آیا مایل به حذف دسترسی از کاربر انتخاب شده هستید؟",
                    title: "درخواست حذف"
                );

                if (confirm != DialogResult.Yes)
                    return ;

                var deleteResult = await _repoUserPermissionService.RepoDeleteAsync(entity.Id);

                if (deleteResult.Success)
                {
                    AlertHelper.ShowSuccess(this, "عملیات حذف با موفقیت انجام شد.");
                    await LoadSelectedNodeUsers();
                }
                else
                {
                    AlertHelper.ShowError(this, "خطا در حذف اطلاعات." + deleteResult.Message);
                }
            }
            catch (Exception ex)
            {
                AlertHelper.ShowError(this, $"خطای غیرمنتظره:\n{ex.Message}");
            }
        }


        private async Task<bool> AddUserInRole()
        {
            try
            {
                if (lueRoleCode_user.EditValue == null)
                {
                    AlertHelper.ShowError(this, "لطفاً نقش کاربری را انتخاب کنید.");
                    return false;
                }

                if (lueUserCode_user.EditValue == null)
                {
                    AlertHelper.ShowError(this, "لطفاً کاربر مدنظر را انتخاب کنید.");
                    return false;
                }

                int roleId = (int)lueRoleCode_user.EditValue;
                int userId = (int)lueUserCode_user.EditValue;

                // دریافت دسترسی‌های نقش
                var rolePermissionsResult = await _efRolePermissionService.EfGetAsync(x => x.RoleId == roleId);
                if (!rolePermissionsResult.Success)
                {
                    AlertHelper.ShowError(this, "خطا در دریافت دسترسی‌های نقش:\n" + string.Join("\n", rolePermissionsResult.Errors));
                    return false;
                }

                var rolePermissionIds = rolePermissionsResult.Data.Select(x => x.PermissionId).ToList();

                if (!rolePermissionIds.Any())
                {
                    AlertHelper.ShowWarning(this, "این نقش هیچ دسترسی‌ای ندارد.");
                    return false;
                }

                // دریافت دسترسی‌های کاربر
                var userPermissionsResult = await _efUserPermissionService.EfGetAsync(x => x.UserId == userId);
                if (!userPermissionsResult.Success)
                {
                    AlertHelper.ShowError(this, "خطا در دریافت دسترسی‌های کاربر:\n" + string.Join("\n", userPermissionsResult.Errors));
                    return false;
                }

                var existingPermissionIds = userPermissionsResult.Data.Select(x => x.PermissionId).ToList();

                // فقط دسترسی‌هایی که کاربر ندارد
                var permissionsToAdd = rolePermissionIds
                    .Where(rolePermissionId => !existingPermissionIds.Contains(rolePermissionId))
                    .Select(permissionId => new UserPermission
                    {
                        UserId = userId,
                        PermissionId = permissionId
                    }).ToList();

                if (!permissionsToAdd.Any())
                {
                    AlertHelper.ShowWarning(this, "این کاربر قبلاً همه‌ی دسترسی‌های این نقش را داشته است.");
                    return false;
                }

                var insertResult = await _repoUserPermissionService.RepoInsertBulkAsync(permissionsToAdd);

                if (!insertResult.Success)
                {
                    AlertHelper.ShowError(this, "خطا در تخصیص دسترسی:\n" + string.Join("\n", insertResult.Errors));
                    return false;
                }

                AlertHelper.ShowSuccess(this, "دسترسی‌های نقش با موفقیت به کاربر تخصیص یافت.");
                await LoadSelectedNodeUsers();
                return true;
            }
            catch (Exception ex)
            {
                AlertHelper.ShowError(this, $"خطای غیرمنتظره:\n{ex.Message}");
                return false;
            }
        }
        private async Task<bool> LoadSelectedNodeUsers()
        {
            var selectedNode = trvUserControl.FocusedNode;
            if (selectedNode != null)
            {
                var permissionId = Convert.ToInt32(selectedNode.GetValue("Id"));
                return await LoadGridUser(permissionId);
            }
            return false;
        }
        private async Task<IQueryable> GetQueryablUserPermission(int id)
        {
            var result = await _efUserPermissionService.EfGetQueryable(null);
            if (!result.Success)
            {
                AlertHelper.ShowError(this, string.Join("\n", result.Errors));
                return null;
            }

            return result.Data
                .Where(a => a.PermissionId == id)
                .Select(a => a.User)
                .Select(u => new
                {
                    u.Id,
                    UserFullName = u.FirstName + " " + u.LastName + $" [{u.UserName}]"
                });
        }
        private async Task<bool> LoadGridUser(int id)
        {
            var serverModeSource = new LinqServerModeSource()
            {
                KeyExpression = "Id",
                QueryableSource = await GetQueryablUserPermission(id)
            };

            FillFormGirdProperties(serverModeSource, typeof(UserPermission));
             await FillerHelper.SetData(gridControlUser, serverModeSource);
            GridHelper.ReDesignColumns(gridViewUser);
            await SetTitle(gridViewUser);

            return true;
        }
        private void GetCheckedAndUncheckedNodes(TreeListNode node, List<int> checkedPersmissions, List<int> uncheckedPersmissions)
        {
            var id = Convert.ToInt32(node.GetValue("Id"));
            if (node.CheckState == CheckState.Checked)
                checkedPersmissions.Add(id);
            else
                uncheckedPersmissions.Add(id);

            foreach (TreeListNode child in node.Nodes)
                GetCheckedAndUncheckedNodes(child, checkedPersmissions, uncheckedPersmissions);
        }
        private void CheckAllChildNodes(TreeListNode node, CheckState checkState)
        {
            foreach (TreeListNode child in node.Nodes)
            {
                child.CheckState = checkState;
                CheckAllChildNodes(child, checkState);
            }
        }
        private void UpdateParentNodes(TreeListNode node, CheckState checkState)
        {
            TreeListNode parent = node.ParentNode;
            while (parent != null)
            {
                bool hasCheckedChild = parent.Nodes.Cast<TreeListNode>().Any(child => child.CheckState == CheckState.Checked);
                parent.CheckState = hasCheckedChild ? CheckState.Checked : CheckState.Unchecked;
                parent = parent.ParentNode;
            }
        }
        private void ClearAllNodes(TreeListNode node)
        {
            node.CheckState = CheckState.Unchecked;
            foreach (TreeListNode child in node.Nodes)
                ClearAllNodes(child);
        }
        private void UpdateNodeCheckState(TreeListNode node, IQueryable<int> data)
        {
            var permissionId = Convert.ToInt32(node.GetValue("Id"));
            node.CheckState = data.Contains(permissionId) ? CheckState.Checked : CheckState.Unchecked;

            foreach (TreeListNode child in node.Nodes)
                UpdateNodeCheckState(child, data);
        }



        private void tabPaneMain_SelectedPageChanged(object sender, SelectedPageChangedEventArgs e)
        {
            if (tabPaneMain.SelectedPage == tabPaneMain.Pages[0])
            {
                InitializeList().GetAwaiter();
                barButtonItemDelete.Visibility = BarItemVisibility.Always;
            }
            else
            {
                barButtonItemDelete.Visibility = BarItemVisibility.Never;
            }
        }
        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            if (lueUserCodeAdd.EditValue == null)
            {
                AlertHelper.ShowError(this, "کاربر را انتخاب کنید");
                return;
            }

            var userId = (int)lueUserCodeAdd.EditValue;
            var userResult = await _repoUserService.RepoGetByIdAsync(userId);
            if (!userResult.Success || userResult.Data == null)
            {
                AlertHelper.ShowError(this, "کاربری جهت تخصیص دسترسی انتخاب نشده است");
                return;
            }

            var selectedNode = trvUserControl.FocusedNode;
            if (selectedNode == null)
            {
                AlertHelper.ShowError(this, "لطفاً یک دسترسی جهت تخصیص انتخاب کنید.");
                return;
            }

            var permissionId = Convert.ToInt32(selectedNode.GetValue("Id"));

            var checkResult = await _repoUserPermissionService.RepoAnyAsync(x => x.UserId == userId && x.PermissionId == permissionId);
            if (!checkResult.Success)
            {
                AlertHelper.ShowError(this, "خطا در بررسی وجود دسترسی قبلی: " + checkResult.Message);
                return;
            }

            if (checkResult.Data)
            {
                AlertHelper.ShowError(this, "کاربر قبلاً به این دسترسی تخصیص داده شده است");
                return;
            }

            var entity = new UserPermission
            {
                UserId = userId,
                PermissionId = permissionId
            };

            var insertResult = await _repoUserPermissionService.RepoInsertAsync(entity);

            if (insertResult.Success)
            {
                AlertHelper.ShowSuccess(this, "کاربر به دسترسی انتخابی تخصیص یافت.");
                await LoadSelectedNodeUsers();
            }
            else
            {
                AlertHelper.ShowError(this, "خطا در تخصیص دسترسی: " + insertResult.Message);
            }
        }
        private void TrvUserControl_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            CheckAllChildNodes(e.Node, e.Node.CheckState);
            UpdateParentNodes(e.Node, e.Node.CheckState);
        }
        private async void LueUserUserCode_EditValueChanged(object sender, EventArgs e)
        {
            if (lueUserUserCode.EditValue != null && tgsUser.IsOn)
            {
                int userId = (int)lueUserUserCode.EditValue;

                var resultUserPermission =  await _efUserPermissionService.EfGetQueryable(a => a.UserId == userId);
                if (!resultUserPermission.Success)
                {
                    AlertHelper.ShowError(this, string.Join("\n", resultUserPermission.Errors));
                    return;
                }

                // 1. پاکسازی همه‌ی نودها
                foreach (TreeListNode node in trvUserControl.Nodes)
                {
                    ClearAllNodes(node);
                }

                // 2. بروزرسانی چک‌ها فقط با دسترسی‌های کاربر انتخابی
                var data = resultUserPermission.Data.Select(a => a.PermissionId);
                foreach (TreeListNode node in trvUserControl.Nodes)
                {
                    UpdateNodeCheckState(node, data);
                }
            }
        }
        private async void LueUserRoleCode_EditValueChanged(object sender, EventArgs e)
        {
            if (lueUserRoleCode.EditValue != null && !tgsUser.IsOn)
            {
                int roleId = (int)lueUserRoleCode.EditValue;

                var resultRolePermission = await _efRolePermissionService.EfGetQueryable(a => a.RoleId == roleId);
                if (!resultRolePermission.Success)
                {
                    AlertHelper.ShowError(this, string.Join("\n", resultRolePermission.Errors));
                    return;
                }
                // 1. پاکسازی همه‌ی نودها
                foreach (TreeListNode node in trvUserControl.Nodes)
                {
                    ClearAllNodes(node);
                }
                // 2. بروزرسانی چک‌ها فقط با دسترسی‌های کاربر انتخابی
                var data = resultRolePermission.Data.Select(a => a.PermissionId);
                foreach (TreeListNode node in trvUserControl.Nodes)
                {
                    UpdateNodeCheckState(node, data);
                }
            }
        }
        private void trvUserControl_SelectionChanged(object sender, EventArgs e)
        {
            LoadSelectedNodeUsers().GetAwaiter();
        }
        private void tgsUser_Toggled(object sender, EventArgs e)
        {
            if (tgsUser.IsOn)
            {
                // حالت کاربر
                lueUserRoleCode.EditValue = null;
                this.lciUserUserCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.lciUserRoleCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                // حالت نقش
                lueUserUserCode.EditValue = null;
                this.lciUserRoleCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.lciUserUserCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            // پاک‌سازی همه نودها
            foreach (TreeListNode node in trvUserControl.Nodes)
            {
                ClearAllNodes(node);
            }
        }


    }
}
