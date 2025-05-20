using DevExpress.XtraGrid;
using Hama.Share.Tools;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Hama.WinApp.Helpers.UI.Grid
{
    public static class ExportGridHelper
    {
        #region EXCEL
        /// <summary>
        ///  Devx خروجی اکسل برای جداول
        /// </summary>
        /// <param name="grid">جـدول</param>

        public static void ToExcel(this GridControl grid, string headerText)
        {
            new ExportGrid(grid, headerText).ToExcel();

        }

        public static void ToWord(this GridControl grid, string headerText)
        {
            new ExportGrid(grid, headerText).ToWord();

        }

        public static void ToCSV(this GridControl grid, string headerText)
        {
            new ExportGrid(grid, headerText).ToCSV();
        }


        #endregion

        #region PDF
        /// <summary>
        /// DevX برای جداول PDF خـروجی
        /// </summary>
        /// <param name="gridControl">جـدول</param>
        public static void ToPDF(this GridControl gridControl)
        {
            new ExportGrid(gridControl).ToPDF();
        }
        /// <summary>
        /// DevX برای جداول PDF خـروجی
        /// </summary>
        /// <param name="gridControl">جـدول</param>
        /// <param name="headerText">عنـوان فـرم</param>
        public static void ToPDF(this GridControl gridControl, string headerText)
        {
            new ExportGrid(gridControl, headerText).ToPDF();

        }
        #endregion

        #region RTF
        /// <summary>
        /// DevX برای جداول RTF خـروجی
        /// </summary>
        /// <param name="gridControl">جـدول</param>
        public static void ToRTF(this GridControl gridControl)
        {
            new ExportGrid(gridControl).ToRTF();

        }
        /// <summary>
        /// DevX برای جداول RTF خـروجی
        /// </summary>
        /// <param name="gridControl">جـدول</param>
        /// <param name="headerText">عنـوان فـرم</param>
        public static void ToRTF(this GridControl gridControl, string headerText)
        {
            new ExportGrid(gridControl, headerText).ToRTF();
        }
        #endregion

        #region Preview
        /// <summary>
        /// نمایش
        /// </summary>
        /// <param name="control">جـدول</param>
        /// <param name="headerText">عنـوان فـرم</param>
        public static void ToPreview(this GridControl control, string headerText)
        {
            new ExportGrid(control, headerText).ToPreview();
        }

        #endregion
    }
    public class ExportGrid
    {
        GridControl grid;
        string headerText;
        public ExportGrid(GridControl _grid)
        {
            grid = _grid;
        }

        public ExportGrid(GridControl _grid, string _headerText)
        {
            grid = _grid;
            headerText = _headerText;
        }

        public void ToRTF()
        {
            grid.MainView.OptionsPrint.RtfPageHeader = headerText;
            grid.MainView.OptionsPrint.RtfPageFooter = "نسخه پیش نمایش";
            SaveFileDialog SavePath = new SaveFileDialog();
            SavePath.Filter = "RTF Files |*.rtf";
            SavePath.ShowDialog();
            if (SavePath.FileName != "")
            {
                grid.Invoke(() =>
                {
                    grid.ExportToRtf(SavePath.FileName);
                });
                Process.Start(new ProcessStartInfo { FileName = SavePath.FileName, UseShellExecute = true });
            }
            else
            {

                MessageBox.Show(MessageHelper.GetMessage(152), MessageHelper.GetMessage(139), MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

            }
        }

        public void ToPDF()
        {
            grid.MainView.OptionsPrint.RtfPageHeader = headerText;
            grid.MainView.OptionsPrint.RtfPageFooter = "نسخه پیش نمایش";
            SaveFileDialog SavePath = new SaveFileDialog();
            SavePath.Filter = "PDF Files |*.pdf";
            SavePath.ShowDialog();
            if (SavePath.FileName != "")
            {
                grid.Invoke(() =>
                {
                    grid.ExportToPdf(SavePath.FileName);
                });
                Process.Start(new ProcessStartInfo { FileName = SavePath.FileName, UseShellExecute = true });
            }
            else
            {
                MessageBox.Show(MessageHelper.GetMessage(154), MessageHelper.GetMessage(139), MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        public void ToExcel()
        {



            grid.MainView.OptionsPrint.RtfPageHeader = headerText;
            grid.MainView.OptionsPrint.RtfPageFooter = "نسخه پیش نمایش";
            SaveFileDialog SavePath = new SaveFileDialog();
            if (grid.DefaultView.RowCount > 65500)
            {
                SavePath.Filter = "Excel Files |*.xlsx";
            }
            else
            {
                SavePath.Filter = "Excel Files |*.xls";
            }
            SavePath.ShowDialog();
            if (SavePath.FileName != "")
            {
                if (grid.InvokeRequired)
                {
                    grid.Invoke(() =>
                    {
                        grid.ExportToXlsx(SavePath.FileName);

                    });
                }

                Process.Start(new ProcessStartInfo { FileName = SavePath.FileName, UseShellExecute = true });
            }
            else
            {
                MessageBox.Show(MessageHelper.GetMessage(154), MessageHelper.GetMessage(139), MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

        }

        public void ToCSV()
        {
            grid.MainView.OptionsPrint.RtfPageHeader = headerText;
            grid.MainView.OptionsPrint.RtfPageFooter = "نسخه پیش نمایش";
            SaveFileDialog SavePath = new SaveFileDialog();
            SavePath.Filter = "Excel Files |*.CSV";
            SavePath.ShowDialog();
            if (SavePath.FileName != "")
            {
                grid.Invoke(() =>
                {
                    grid.ExportToCsv(SavePath.FileName);
                });
                Process.Start(new ProcessStartInfo { FileName = SavePath.FileName, UseShellExecute = true });
            }
            else
            {
                MessageBox.Show(MessageHelper.GetMessage(154), MessageHelper.GetMessage(139), MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

        }

        public void ToWord()
        {
            grid.MainView.OptionsPrint.RtfPageHeader = headerText;
            grid.MainView.OptionsPrint.RtfPageFooter = "نسخه پیش نمایش";
            SaveFileDialog SavePath = new SaveFileDialog();
            SavePath.Filter = "Excel Files |*.docx";
            SavePath.ShowDialog();
            if (SavePath.FileName != "")
            {
                if (grid.InvokeRequired)
                {
                    grid.Invoke(() =>
                    {
                        grid.ExportToDocx(SavePath.FileName);
                    });

                    Process.Start(new ProcessStartInfo { FileName = SavePath.FileName, UseShellExecute = true });
                }
                else
                {
                    MessageBox.Show(MessageHelper.GetMessage(152), MessageHelper.GetMessage(139), MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }

            }
        }

        public void ToPreview()
        {
            grid.MainView.OptionsPrint.RtfPageHeader = headerText;
            grid.MainView.OptionsPrint.RtfPageFooter = "نسخه پیش نمایش";
            grid.ShowPrintPreview();
        }

    }
}
