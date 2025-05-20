using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Hama.WinApp.Views.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hama.WinApp.Helpers.UI.Grid
{

    public class GridHelper
    {
        public enum ColumnFooters
        {
            [AmbientValue(typeof(string), "None")]
            None = 0,
            [AmbientValue(typeof(string), "Min")]
            Min = 1,
            [AmbientValue(typeof(string), "Count")]
            Count = 2,
            [AmbientValue(typeof(string), "Average")]
            Average = 3,
            [AmbientValue(typeof(string), "Sum")]
            Sum = 4,
            [AmbientValue(typeof(string), "Max")]
            Max = 5
        }

        public static async Task ReDesignColumns(GridView gridView)
        {
            await Task.Yield();

            var columns = gridView.Columns.Cast<GridColumn>().ToList();
            var decimalTypes = new List<Type> { typeof(decimal), typeof(double) };

            foreach (var column in columns)
            {
                column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;

                if (column.Tag is SummaryItemType summaryType)
                {
                    var format = decimalTypes.Contains(column.ColumnType) ? "{0:N10}" : "{0:n0}";
                    GridHelper.AddSummeryColumn(gridView, summaryType, column.FieldName, format);
                }
                if (column.ColumnType == typeof(string))
                    column.Width = 150;
                else if (column.ColumnType == typeof(DateTime))
                    column.Width = 100;
                else if (column.ColumnType == typeof(bool))
                    column.Width = 100;
                else if (column.ColumnType == typeof(int) || column.ColumnType == typeof(decimal) || column.ColumnType == typeof(double))
                    column.Width = 120;
                else
                    column.Width = 80;
            }

        }



        public static void SetDefaultSetting(CheckedListBoxControl control)
        {
            control.CheckMode = CheckMode.Multiple;
            control.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
        }
        public static async void SetDefaultSetting(GridView gridView, bool? Editable = false)
        {
            await Task.Yield();

            if (gridView != null)
            {

                gridView.OptionsView.ColumnAutoWidth = true;

                gridView.GroupPanelText = "دسته بندی";
                gridView.Appearance.FooterPanel.TextOptions.HAlignment = HorzAlignment.Center;
                gridView.Appearance.FooterPanel.Options.UseTextOptions = true;


                gridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
                gridView.OptionsView.ShowFooter = true;
                gridView.OptionsView.EnableAppearanceOddRow = false;
                gridView.OptionsView.EnableAppearanceEvenRow = false;
                gridView.OptionsView.ColumnAutoWidth = false;
                gridView.OptionsCustomization.AllowColumnResizing = true;
                gridView.OptionsFind.AllowFindPanel = true;
                gridView.OptionsFind.FindPanelLocation = GridFindPanelLocation.Panel;
                gridView.OptionsFind.AlwaysVisible = true;
                gridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
                gridView.OptionsFind.FindNullPrompt = "جستجو";


                if ((bool)Editable)
                {
                    gridView.OptionsBehavior.AllowAddRows = DefaultBoolean.True;
                    gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
                    gridView.OptionsBehavior.AllowDeleteRows = DefaultBoolean.True;
                    gridView.OptionsBehavior.AllowAddRows = DefaultBoolean.True;
                    gridView.OptionsBehavior.Editable = true;
                    gridView.OptionsBehavior.ReadOnly = false;
                    gridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
                    gridView.OptionsNavigation.EnterMoveNextColumn = true;

                }
                // *********************************************************************************//
                else
                {
                    gridView.OptionsBehavior.AllowDeleteRows = DefaultBoolean.False;
                    gridView.OptionsBehavior.AllowAddRows = DefaultBoolean.False;
                    gridView.OptionsBehavior.Editable = false;
                    gridView.OptionsBehavior.ReadOnly = true;
                }
            }
        }


        public static void SaveLayout(GridView gridView)
        {
            if (gridView != null)
            {

                var GroupedColumns = gridView.GroupedColumns.ToList();
                string name = "By";
                if (GroupedColumns.Count() == 0)
                {
                    name = "Template";
                }
                else
                    foreach (var item in GroupedColumns)
                    {
                        name += "_" + item.Caption;
                    }



                MemoryStream ms = new MemoryStream();
                gridView.SaveLayoutToStream(ms);
                byte[] buffer = ms.GetBuffer();
                //TODO : Add Buffer To Database
            }

        }
        public static void LoadLayout(GridView gridView)
        {
            if (gridView != null)
            {
                // TODO : Get Data From Database
                byte[] bytes = null;
                if (bytes != null)
                {
                    MemoryStream ms = new MemoryStream(bytes);
                    if (ms != null)
                    {
                        gridView.RestoreLayoutFromStream(ms);
                    }
                }
            }

        }

        public static void SetZoomGrid(GridView gridView, bool ToUp)
        {

            if (ToUp)
            {
                gridView.Appearance.FilterPanel.FontSizeDelta++;
                gridView.Appearance.Row.FontSizeDelta++;
                gridView.Appearance.HeaderPanel.FontSizeDelta++;
                gridView.Appearance.FooterPanel.FontSizeDelta++;
                gridView.Appearance.GroupPanel.FontSizeDelta++;
                gridView.Appearance.FilterPanel.FontSizeDelta++;
            }
            else
            {
                if (gridView.Appearance.FilterPanel.FontSizeDelta > 0)
                {
                    gridView.Appearance.FilterPanel.FontSizeDelta--;
                    gridView.Appearance.Row.FontSizeDelta--;
                    gridView.Appearance.HeaderPanel.FontSizeDelta--;
                    gridView.Appearance.FooterPanel.FontSizeDelta--;
                    gridView.Appearance.GroupPanel.FontSizeDelta--;
                    gridView.Appearance.FilterPanel.FontSizeDelta--;
                }
            }
        }



 

        internal static void AddSummeryColumn(GridView grid, SummaryItemType itemType, string column, string format = "{0:n0}")
        {
            grid.Columns[column].Summary.Clear();
            grid.Columns[column].Summary.Add(
                new GridColumnSummaryItem()
                {
                    SummaryType = itemType,
                    DisplayFormat = format
                });

            grid.GroupSummary.Add(itemType, column, grid.Columns[column], format);

        }
    }

    public class ColumnProperty
    {
        public string Name { get; set; }
        public Type DataType { get; set; }
    }
}
