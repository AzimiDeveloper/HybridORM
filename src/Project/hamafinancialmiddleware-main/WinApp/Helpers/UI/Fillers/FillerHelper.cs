using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Hama.Share.Attributes;
using Hama.WinApp.Helpers.UI.Controls;
using Hama.WinApp.Helpers.UI.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hama.WinApp.Helpers.UI.Fillers
{
    public static class FillerHelper
    {
        private static void _control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                (sender as TreeListLookUpEdit).ShowPopup();
        }

        //*********************************** Set *************************************
        public static async Task SetData(GridControl _control, object _data, bool? Editable = false)
        {
            await Task.Yield();
            try
            {
                GridControl gridControl = _control;
                if (_data == null)
                {
                    _control.DataSource = null;
                }
                else
                {
                    if (_control.DataSource == null && _control.Views[0].GetType() == typeof(GridView))
                    {
                        if ((_control.Views[0] as GridView).Tag == null || (_control.Views[0] as GridView).Tag.ToString() != "true")
                        {
                            (_control.Views[0] as GridView).Tag = "true";
                            GridHelper.SetDefaultSetting(_control.Views[0] as GridView, Editable);
                        }
                    }
                    _control.DataSource = _data;

                }
            }
            catch
            {

            }
        }

        public static async Task SetData(CheckedListBoxControl _control, object _data, string ColumnValue = "", string ColumnDisplay = "")
        {
            await Task.Yield();
            CheckedListBoxControl control = _control;
            if (_data == null)
            {
                _control.DataSource = null;
            }
            else
            {
                _control.DataSource = _data;
                control.DisplayMember = ColumnDisplay;
                control.ValueMember = ColumnValue;
                GridHelper.SetDefaultSetting(_control);

            }
        }

        public static async Task SetData(TokenEdit _control, IEnumerable<object> _data, string ColumnValue = "", string ColumnDisplay = "", string v = null)
        {
            await Task.Yield();
            if (_data == null || _data.FirstOrDefault() == null)
            {
                _control.Properties.DataSource = null;
            }
            else
            {
                _control.Properties.ValueMember = ColumnValue;
                _control.Properties.DataSource = _data;
                _control.Properties.DisplayMember = ColumnDisplay;

                _control.EditValue = null;
            }
        }
        public static async Task SetData(RadioGroup _control, IEnumerable<dynamic> _data)
        {
            await Task.Yield();
            if (_data.FirstOrDefault() != null)
            {
                var listName = "Name";
                var dataType = (Type)_data.FirstOrDefault().GetType();
                if (dataType.GetProperties().Where(d => d.GetCustomAttribute<CustomListNameAttribute>() != null).Count() > 0)
                    listName = dataType.GetProperties().Where(d => d.GetCustomAttribute<CustomListNameAttribute>() != null).First().Name;
                var d = _data.FirstOrDefault();
                var dd = _data.ToList().Select(a => a[1]);
                foreach (var item in _data)
                {
                    _control.Properties.Items.Add(new RadioGroupItem(d, "ii".ToString()));
                }
            }
        }
        public static async Task SetData(ListBoxControl _control, IEnumerable<object> _data, string ColumnValue = "", string ColumnDisplay = "", string ColumnNames = "")
        {
            await Task.Yield();
            if (_data == null || _data.FirstOrDefault() == null)
            {
                _control.DataSource = null;
            }
            else
            {
                _control.ValueMember = ColumnValue;
                _control.DataSource = _data;
                _control.DisplayMember = ColumnNames;
            }

        }

        public static async Task SetData(LookUpEdit _control, IEnumerable<object> _data, string ColumnValue = "", string ColumnDisplay = "", string ColumnNames = "", SearchMode? searchMode = SearchMode.AutoSearch)
        {
            await Task.Yield();
            if (_data == null || _data.FirstOrDefault() == null)
            {
                _control.Properties.DataSource = null;
            }
            else
            {

                _control.Properties.ValueMember = ColumnValue;
                _control.Properties.DataSource = _data.ToList();
                _control.Properties.SearchMode = (SearchMode)searchMode;

                if (!string.IsNullOrEmpty(ColumnNames))
                {
                    _control.Properties.Columns.Clear();
                    var Columns = ColumnNames.Split(",");
                    foreach (string column in Columns)
                    {
                        _control.Properties.DisplayMember = column;
                        _control.Properties.Columns.Add(new LookUpColumnInfo(_control.Properties.DisplayMember));
                    }
                }
                _control.Properties.DisplayMember = ColumnDisplay;
            }
            LookUpEditHelper.SetDefaultSetting(_control);
        }
        public static async Task SetData(LookUpEdit _control, object _data, string ColumnValue = "", string ColumnDisplay = "", string ColumnNames = "", SearchMode? searchMode = SearchMode.AutoSearch)
        {
            await Task.Yield();
            if (_data == null)
            {
                _control.Properties.DataSource = null;
            }
            else
            {

                _control.Properties.ValueMember = ColumnValue;
                _control.Properties.DataSource = _data;
                _control.Properties.SearchMode = (SearchMode)searchMode;
                if (!string.IsNullOrEmpty(ColumnNames))
                {
                    _control.Properties.Columns.Clear();
                    var Columns = ColumnNames.Split(",");
                    foreach (string column in Columns)
                    {
                        _control.Properties.DisplayMember = column;
                        _control.Properties.Columns.Add(new LookUpColumnInfo(_control.Properties.DisplayMember));
                    }
                }
                _control.Properties.DisplayMember = ColumnDisplay;
            }
            LookUpEditHelper.SetDefaultSetting(_control);
        }

        public static async Task SetData(SearchLookUpEdit _control, object _data, string ColumnValue = "", string ColumnDisplay = "", string ColumnNames = "")
        {
            await Task.Yield();
            if (_data == null)
            {
                _control.Properties.DataSource = null;
            }
            else
            {

                _control.Properties.ValueMember = ColumnValue;
                _control.Properties.DataSource = _data;
                _control.Properties.DisplayMember = ColumnDisplay;
                if (!string.IsNullOrEmpty(ColumnNames))
                {
                    // پاک کردن ستون‌های قبلی و تنظیم ستون‌های جدید
                    _control.Properties.View.Columns.Clear();
                    var columns = ColumnNames.Split(",");

                    foreach (string column in columns)
                    {
                        // ساخت GridColumn برای هر ستون
                        var gridColumn = new GridColumn
                        {
                            FieldName = column,
                            Caption = column,
                            Visible = true
                        };
                        _control.Properties.View.Columns.Add(gridColumn);
                    }
                }
            }
            LookUpEditHelper.SetDefaultSetting(_control);
        }

        public static async Task SetData(RepositoryItemLookUpEdit _control, IEnumerable<object> _data, string ColumnValue = "", string ColumnDisplay = "", string ColumnNames = "", SearchMode? searchMode = SearchMode.AutoSearch)
        {
            await Task.Yield();
            if (_data == null || _data.FirstOrDefault() == null)
            {
                _control.DataSource = null;
            }
            else
            {
                _control.ValueMember = ColumnValue;
                _control.DataSource = _data;
                _control.SearchMode = (SearchMode)searchMode;

                if (!string.IsNullOrEmpty(ColumnNames))
                {
                    _control.Columns.Clear();
                    var Columns = ColumnNames.Split(",");
                    foreach (string column in Columns)
                    {
                        _control.DisplayMember = column;
                        _control.Columns.Add(new LookUpColumnInfo(_control.DisplayMember));
                    }
                }
                _control.DisplayMember = ColumnDisplay;
            }
            LookUpEditHelper.SetDefaultSetting(_control);
        }
        public static async Task SetData(RepositoryItemSearchLookUpEdit _control, object _data, string ColumnValue = "", string ColumnDisplay = "", string ColumnNames = "")
        {
            await Task.Yield();
            if (_data == null)
            {
                _control.DataSource = null;
            }
            else
            {

                _control.ValueMember = ColumnValue;
                _control.DataSource = _data;
                _control.DisplayMember = ColumnDisplay;
                if (!string.IsNullOrEmpty(ColumnNames))
                {
                    // پاک کردن ستون‌های قبلی و تنظیم ستون‌های جدید
                    _control.View.Columns.Clear();
                    var columns = ColumnNames.Split(",");

                    foreach (string column in columns)
                    {
                        // ساخت GridColumn برای هر ستون
                        var gridColumn = new GridColumn
                        {
                            FieldName = column,
                            Caption = column,
                            Visible = true
                        };
                        _control.View.Columns.Add(gridColumn);
                    }
                }
            }
            LookUpEditHelper.SetDefaultSetting(_control);
        }


        public static async Task SetData(TreeListLookUpEdit _control, IEnumerable<dynamic> _data, string ColumnValue = "", string ColumnDisplay = "", string ParentFieldName = "")
        {
            await Task.Yield();

            if (_data == null)
            {
                _control.Properties.DataSource = null;
                _control.Properties.TreeList.DataSource = null;
            }
            else
            {
                // تنظیم DataSource
                _control.Properties.DataSource = _data;

                // تنظیم TreeList
                var treeList = _control.Properties.TreeList;

                treeList.DataSource = _data;
                treeList.KeyFieldName = ColumnValue;
                treeList.ParentFieldName = ParentFieldName;



                // تنظیم ویژگی‌های TreeList
                _control.Properties.DisplayMember = ColumnDisplay;
                _control.Properties.ValueMember = ColumnValue;
                _control.Properties.ShowFooter = true;
                _control.Properties.AllowMouseWheel = true;

                treeList.OptionsFilter.AllowFilterEditor = true;
                treeList.OptionsFind.AllowFindPanel = true;
                treeList.OptionsFind.AlwaysVisible = true;
                treeList.OptionsFind.Behavior = FindPanelBehavior.Filter;
                treeList.OptionsFind.Condition = DevExpress.Data.Filtering.FilterCondition.Contains;
                treeList.OptionsFind.FindMode = DevExpress.XtraTreeList.FindMode.Always;

                // بازسازی ستون‌ها
                treeList.PopulateColumns();
                var ccc = treeList.Columns;

            }

            // تنظیمات عمومی
            _control.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            _control.Properties.NullValuePrompt = "";
            _control.Properties.NullText = "";
            LookUpEditHelper.SetDefaultSetting(_control);
        }
        public static async Task SetData(RepositoryItemTreeListLookUpEdit _control, object _data, string ColumnValue = "", string ColumnDisplay = "", string ParentFieldName = "")
        {
            await Task.Yield();

            if (_control == null)
            {
                throw new ArgumentNullException(nameof(_control), "کنترل ورودی نمی‌تواند null باشد");
            }

            if (_data == null)
            {
                _control.DataSource = null;
                _control.TreeList.DataSource = null;
            }
            else
            {
                // تنظیم DataSource
                _control.DataSource = _data;

                // تنظیم TreeList
                var treeList = _control.TreeList;
                treeList.DataSource = _data;

                // تنظیم KeyFieldName و ParentFieldName
                if (!string.IsNullOrEmpty(ColumnValue))
                {
                    treeList.KeyFieldName = ColumnValue;
                }

                if (!string.IsNullOrEmpty(ParentFieldName))
                {
                    treeList.ParentFieldName = ParentFieldName;
                }

                // بازسازی ستون‌ها
                treeList.PopulateColumns();
                var cc = _control.TreeList.Columns;

                // تنظیم ویژگی‌های TreeList
                if (!string.IsNullOrEmpty(ColumnDisplay))
                {
                    _control.DisplayMember = ColumnDisplay;
                }

                if (!string.IsNullOrEmpty(ColumnValue))
                {
                    _control.ValueMember = ColumnValue;
                }

                _control.ShowFooter = true;
                _control.AllowMouseWheel = true;

                treeList.OptionsFilter.AllowFilterEditor = true;
                treeList.OptionsFind.AllowFindPanel = true;
                treeList.OptionsFind.AlwaysVisible = true;
                treeList.OptionsFind.Behavior = FindPanelBehavior.Filter;
                treeList.OptionsFind.Condition = DevExpress.Data.Filtering.FilterCondition.Contains;
                treeList.OptionsFind.FindMode = DevExpress.XtraTreeList.FindMode.Always;

                _control.KeyDown += _control_KeyDown;
                LookUpEditHelper.SetDefaultSetting(_control);
            }
        }

        //*********************************** Get *************************************
        /// <summary>
        /// GetRow(rowNumber)
        /// </summary>
        /// <param name="_control"></param>
        /// <param name="rowNumber"></param>
        /// <returns></returns>
        public static object GetData(GridView _control, int rowNumber)
        {
            return _control.GetRow(rowNumber);
        }
        /// <summary>
        /// GetRowCellValue(rowNumber, ColumnName)
        /// </summary>
        /// <param name="_control"></param>
        /// <param name="rowNumber"></param>
        /// <param name="ColumnName"></param>
        /// <returns></returns>
        public static object GetData(GridView _control, int rowNumber, string ColumnName)
        {
            return _control.GetRowCellValue(rowNumber, ColumnName);
        }
        /// <summary>
        /// GetFocusedRowCellValue(ColumnName)
        /// </summary>
        /// <param name="_control"></param>
        /// <param name="ColumnName"></param>
        /// <returns></returns>
        public static object GetData(GridView _control, string ColumnName)
        {
            return _control.GetFocusedRowCellValue(ColumnName);
        }

        /// <summary>
        /// Properties.Items[selectionID].Description
        /// </summary>
        /// <param name="_control"></param>
        /// <returns></returns>
        public static object GetData(RadioGroup _control)
        {
            int selectionID = _control.SelectedIndex;
            return _control.Properties.Items[selectionID].Description;
        }
        /// <summary>
        /// Properties.Items[selectionID].Value
        /// </summary>
        /// <param name="_control"></param>
        /// <returns></returns>
        public static object GetData_Value(RadioGroup _control)
        {
            int selectionID = _control.SelectedIndex;
            return _control.Properties.Items[selectionID].Value;
        }

        /// <summary>
        /// GetSelectedDataRow
        /// </summary>
        /// <param name="_control"></param>
        /// <returns></returns>
        public static object GetData(LookUpEdit _control)
        {
            return _control.GetSelectedDataRow();
        }
        /// <summary>
        /// EditValue
        /// </summary>
        /// <param name="_control"></param>
        /// <returns></returns>
        public static object GetData_Value(LookUpEdit _control)
        {
            return _control.EditValue;
        }

        /// <summary>
        /// EditValue
        /// </summary>
        /// <param name="_control"></param>
        /// <returns></returns>
        public static object GetData(BarEditItem _control)
        {
            return _control.EditValue;
        }




    }




}
