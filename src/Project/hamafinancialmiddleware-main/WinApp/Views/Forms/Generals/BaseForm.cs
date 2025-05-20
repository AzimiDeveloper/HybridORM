using DevExpress.Data.Linq;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Hama.Core.Models;
using Hama.Log.Dto;
using Hama.Share.Tools;
using Hama.WinApp.Helpers.UI.Controls;
using Hama.WinApp.Helpers.UI.Notifications;
using Hama.WinApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace Hama.WinApp.Views.Forms
{
    public partial class BaseForm : DevExpress.XtraEditors.XtraForm, IBarItemInitializer, IActionBar
    {
        public User CurrentUser
        {
            get
            {
                try
                {
                    var user = (User)AppContext.GetData("CurrentUser");
                    return user;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public static List<FormGirdProperties> formGirdProperties { get; set; } = new();

        protected BarItem[] _visibleBarItems;
        public static Form CurrentMDI { get; set; }
        public bool IsModal { get; set; }

        protected LinqServerModeSource gridData { get; set; }

        public virtual BarItem[] GetVisibleBarItems()
        {
            var allowedNames = _visibleBarItems?.Select(b => b.Name).ToList() ?? new List<string>();

            return this.GetAll().barItems
                .Where(b => b.Visibility == BarItemVisibility.Always && allowedNames.Contains(b.Name))
                .ToArray();
        }
        protected void FillFormGirdProperties(LinqServerModeSource serverModeSource, Type type)
        {
            try
            {
                // بررسی اینکه آیا داده‌ای در LinqServerModeSource وجود دارد
                if (serverModeSource != null && serverModeSource.QueryableSource != null)
                {
                    // استخراج نوع ویژگی‌ها از LinqServerModeSource
                    var props = type.GetProperties().ToList();

                    // بررسی و اضافه کردن فرم به formGirdProperties در صورت عدم وجود
                    if (!formGirdProperties.Any(a => a.EntityType == type.Name))
                    {
                        formGirdProperties.Add(new FormGirdProperties()
                        {
                            FormName = this.Name,
                            EntityType = type.Name,
                            Properties = props
                        });
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        protected void FillFormGirdProperties(IEnumerable<object> list, Type type)
        {
            try
            {
                if (list != null && list.Any())
                {
                    var props = list.FirstOrDefault().GetType().GetProperties().ToList();
                    if (!formGirdProperties.Any(a => a.GetType() == list.FirstOrDefault().GetType()))
                        formGirdProperties.Add(new FormGirdProperties()
                        {
                            FormName = this.Name,
                            EntityType = type.Name,
                            Properties = props
                        });
                }
            }
            catch (Exception ex)
            {

            }
        }
        public string FulllAssemblyName
        {
            get
            {
                try
                {
                    return ((this.GetType().Namespace) + "." + this.Name);
                }
                catch (Exception ex)
                {


                    return null;
                }
            }

        }

        public void CashGeneralDataForm()
        {
            this.Tag = this.Name + "FinancialPeriod_" + Guid.NewGuid();
            // برای کش کردن سال مالی هر فرم یک متغیر سال مالی با اسم فرم نگهداری میکنیم
            AppContext.SetData(this.Tag.ToString(), AppContext.GetData("FinancialPeriod"));
        }

        public BaseForm()
        {
            if (!DesignMode && !LicenseManager.UsageMode.Equals(LicenseUsageMode.Designtime))
            {
                this.RightToLeft = RightToLeft.Yes;
                this.RightToLeftLayout = true;

                CashGeneralDataForm();
                InitializeComponent();
                BarButtonItemInitialize();
            }
            else
            {
                InitializeComponent();
            }
        }



        protected void ClearCrudValidation()
        {
            var CrudControls = ControlsHelper.GetAll(this, ControlsHelper.CrudControls);
            foreach (var item in CrudControls)
            {
                // برداشتن خطاهای قبلی
                dxError.SetError(item, null);

                // اگر لیست بایند نشده باشه نال نشون نشده
                if (item.GetType() == typeof(LookUpEdit))
                    (item as LookUpEdit).Properties.NullText = "";
                if (item.GetType() == typeof(TreeListLookUpEdit))
                    (item as TreeListLookUpEdit).Properties.NullText = "";
                if (item.GetType() == typeof(TokenEdit))
                    (item as TokenEdit).Properties.NullText = "";
                if (item.GetType() == typeof(RadioGroup))
                    (item as RadioGroup).Properties.NullText = "";

                //if (UserControlHelper.CheckUserInControlCodePermission(UserControlTypes.CrudControls, this.Name + "." + item.Name, CurrentUser, this.Name))
                //{
                item.Enabled = true;
                //}
                //else
                //{
                //	item.Enabled = false;
                //}

            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            System.Windows.Forms.KeyEventArgs e = new System.Windows.Forms.KeyEventArgs(keyData);
            switch (e.KeyCode)
            {
                //case Keys.F2:
                //    HandleMethodCall("ActionNew");
                //    return true;

                //case Keys.F3:
                //    HandleMethodCall("ActionEdit");
                //    return true;

                //case Keys.Delete:
                //    HandleMethodCall("ActionDelete");
                //    return true;

                //case Keys.F5:
                //    HandleMethodCall("ActionSave");
                //    return true;

                //case Keys.F6:
                //    HandleMethodCall("ActionReload");
                //    return true;

                case Keys.Escape:
                    {

                        if (!IsModal)
                        {
                            this.Close();
                            return true;
                        }
                        else
                            return false;
                    }
                case Keys.F12:
                    {
                        DebugView();
                        return true;
                    }
            }
            return false;
        }
        private void DebugView()
        {
            try
            {
                this.Text = this.GetType().Namespace + "." + this.Name;

                var gridControls = FormHelper.GetAllControlsRecusrvive<GridControl>(this);
                foreach (var gridControl in gridControls)
                {
                    if (gridControl.Views.Count > 0 && gridControl.Views[0].GetType() == typeof(DevExpress.XtraGrid.Views.Grid.GridView))
                    {
                        DevExpress.XtraGrid.Views.Grid.GridView gridView = gridControl.Views[0] as DevExpress.XtraGrid.Views.Grid.GridView;
                        for (int i = 0; i < gridView.Columns.Count; i++)
                        {
                            gridView.Columns[i].Visible = true;
                            gridView.Columns[i].Caption = gridView.Columns[i].FieldName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                //System.Windows.Forms.MessageBox.Show("DebugView" + ex.Message);
            }
        }
        protected void FillFormFooterItems()
        {
            try
            {

                barStatusCompanyName.Caption = "نام شرکت";
                barStatusFinancialPeriod.Caption = "نام دوره مالی";

                System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
                ToolTipTitleItem toolTipTitleItem = new ToolTipTitleItem();
                ToolTipItem toolTipItem1 = new ToolTipItem();
                ToolTipItem toolTipItem2 = new ToolTipItem();

                toolTipTitleItem.Text = "شناسه دوره مالی";
                toolTipItem1.Text = "تاریخ لاتین دوره مالی";
                toolTipItem2.Text = "تاریخ فارسی دوره مالی";

                SuperToolTip superToolTip = new SuperToolTip();
                superToolTip.Items.Add(toolTipTitleItem);
                superToolTip.Items.Add(toolTipItem1);
                superToolTip.Items.Add(toolTipItem2);
                barStatusFinancialPeriod.SuperTip = superToolTip;
            }
            catch
            {
            }
        }

        private void BarButtonItemInitialize()
        {
            try
            {
                List<BarItem> controls = this.GetAll().barItems.Distinct().ToList();
                foreach (var control in controls)
                {
                    control.ItemClick += Control_ItemClick;
                }
            }
            catch
            {
            }
        }
        private void Control_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var currectName = e.Item.Name.Replace("barMainMenu", "").Replace("barButtonItem", "").Replace("barTools", "").Replace("barStatus", "");
            HandleMethodCall("Action" + currectName);
        }
        private void HandleMethodCall(string name)
        {
            var method = this.GetType().GetMethod(name);
            if (method != null)
                try
                {
                    object data = null;

                    ClientInformation.FormMethod = method.Name;
                    data = ((MethodInfo)method).Invoke(this, null);

                }
                catch (NotImplementedException ex)
                {


                    AlertHelper.ShowWarning(this, MessageHelper.GetMessage(116));
                }
                catch (TargetInvocationException ex)
                {


                    AlertHelper.ShowWarning(this, MessageHelper.GetMessage(116));
                }
        }
        public void InitializeBarItemVisible(BarItem[] items)
        {

            try
            {
                var names = items.ToList().Select(a => a.Name).ToList();
                List<BarItem> controls = this.GetAll().barItems.Distinct().Where(a => a.Name.Contains("barButtonItem")).ToList();
                foreach (BarItem control in controls)
                {
                    if (!names.Contains(control.Name))
                        control.Visibility = BarItemVisibility.Never;

                    else
                    {
                        control.Visibility = BarItemVisibility.Always;

                        //if (UserControlHelper.CheckUserInControlCodePermission(UserControlTypes.FormBarButtonItem, this.Name + "." + control.Name, CurrentUser, this.Name))
                        //{
                        control.Enabled = true;
                        //}
                        //else
                        //{
                        //	control.Enabled = false;
                        //}
                    }
                }
            }
            catch (Exception e)
            {
            }


        }
        protected void textBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }
        private void BaseForm_Resize(object sender, EventArgs e)
        {
            if (IsModal)
            {
                BarMenu.Visible = false;
                bar2.Visible = false;
            }
        }
        private void BaseForm_Activated(object sender, EventArgs e)
        {
            ClientInformation.FormName = this.Name;
        }
        private void BaseForm_Shown(object sender, EventArgs e)
        {

        }
        private async void BaseForm_Load(object sender, EventArgs e)
        {
            await InitializeForm();
        }

        #region IActionBar
        public async virtual Task<bool> ValidateForm()
        {
            ClearCrudValidation();

            await Task.Yield();
            dxError.ClearErrors();
            return true;
        }
        public async virtual Task<bool> ActionReload()
        {
            await Task.Yield();
            return true;
        }
        public async virtual Task InitializeForm()
        {
            await ActionNew();
        }
        public async virtual Task ClearForm()
        {
            await Task.Yield();

            ClearValidation();
        }
        public async virtual Task ClearValidation()
        {
            await Task.Yield();

            ClearCrudValidation();
        }
        public async virtual Task InitializeGrid()
        {
            await Task.Yield();
        }
        public async virtual Task SetTitle(GridView grid)
        {
            await Task.Yield();
        }
        public async virtual Task InitializeList()
        {
            await Task.Yield();
        }
        public async virtual Task ActionNew()
        {
            await Task.Yield();

            ClearForm();
            InitializeGrid();
            InitializeList();
        }
        public async virtual Task ActionSave()
        {
            await Task.Yield();
        }
        public async virtual Task ActionEdit()
        {
            await Task.Yield();
        }
        public async virtual Task ActionDelete()
        {
            await Task.Yield();
        }
        public async virtual Task ActionDoubleCheck()
        {
            await Task.Yield();
        }
        public async virtual Task ActionSelectAll()
        {
            await Task.Yield();
        }
        public async virtual Task ActionFastEntry()
        {
            await Task.Yield();
        }
        public async virtual Task ActionCopy()
        {
           await Task.Yield();
        }
        public async virtual Task ActionImportExcel()
        {
           await Task.Yield();
        }
        public async virtual Task ActionState()
        {
           await Task.Yield();
        }
        public async virtual Task ActionQRCode()
        {
           await Task.Yield();
        }
        public async virtual Task ActionSend()
        {
           await Task.Yield();
        }
        public async virtual Task ActionFirst()
        {
           await Task.Yield();
        }
        public async virtual Task ActionPrevious()
        {
           await Task.Yield();
        }
        public async virtual Task ActionNext()
        {
           await Task.Yield();
        }
        public async virtual Task ActionLast()
        {
           await Task.Yield();
        }
        public async virtual Task ActionLock()
        {
           await Task.Yield();
        }
        public async virtual Task ActionBookmark()
        {
           await Task.Yield();
        }
        public async virtual Task ActionAttachment()
        {
           await Task.Yield();
        }
        public async virtual Task ActionComment()
        {
           await Task.Yield();
        }
        public async virtual Task ActionNavigation()
        {
           await Task.Yield();
        }
        public async virtual Task ActionDownload()
        {
           await Task.Yield();
        }
        public async virtual Task ActionUpload()
        {
           await Task.Yield();
        }
        public async virtual Task ActionPrint()
        {
           await Task.Yield();
        }
        public async virtual Task ActionLTR()
        {
           await Task.Yield();
        }
        public async virtual Task ActionRTL()
        {
           await Task.Yield();
        }
        public async virtual Task ActionAlignLeft()
        {
           await Task.Yield();
        }
        public async virtual Task ActionAlignCenter()
        {
           await Task.Yield();
        }
        public async virtual Task ActionAlignRight()
        {
           await Task.Yield();
        }
        public async virtual Task ActionRowPositionTop()
        {
           await Task.Yield();
        }
        public async virtual Task ActionRowPositionBottom()
        {
           await Task.Yield();
        }
        public async virtual Task ActionSimulation()
        {
           await Task.Yield();
        }
        #endregion
    }
}