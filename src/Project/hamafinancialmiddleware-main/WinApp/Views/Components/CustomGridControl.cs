using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Hama.WinApp.Helpers.UI.Grid;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Hama.WinApp.Views.Components
{
    public partial class CustomGridControl : System.Windows.Forms.UserControl
    {

        public CustomGridControl()
        {
            InitializeComponent();
            RepositoryItemZoomTrackBar zoomTrackBar = (GridZoom.Edit as RepositoryItemZoomTrackBar);
            zoomTrackBar.Minimum = FontDeltaMin;
            zoomTrackBar.Maximum = FontDeltaMax;
            GridZoom.EditValue = 0;
            zoomTrackBar.EditValueChanged += ZoomTrackBar_EditValueChanged;


        }


        private void GridRealTimeDate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void GridPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var t = new Thread(() =>
                {
                    gridControl1.ToPreview(this.Text);
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
            catch
            {

            }
        }

        private void GridExportToExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                var t = new Thread(() =>
                {
                    gridControl1.ToExcel(this.Text);
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
            catch
            {

            }

        }
        private void GridExportToCSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var t = new Thread(() =>
                {
                    gridControl1.ToCSV(this.Text);
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
            catch
            {

            }

        }
        private void GridExportToPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var t = new Thread(() =>
                {
                    gridControl1.ToPDF(this.Text);
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
            catch
            {

            }

        }
        private void GridExportToImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var t = new Thread(() =>
                {
                    gridControl1.ToWord(this.Text);
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
            }
            catch
            {

            }

        }
        private void GridExportToDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var t = new Thread(() =>
                {
                    gridControl1.ToWord(this.Text);
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

            }
            catch
            {
            }
        }

        private void GridChart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void GridLayoutSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            //	TemplateService templateService = new TemplateService();

            //	var groupedColumns = gridView1.GroupedColumns.ToList();
            //	string name = "براساس";
            //	if (groupedColumns.Count() == 0)
            //	{
            //		name = "نمایه";
            //	}
            //	else
            //		foreach (var item in groupedColumns)
            //		{
            //			name += "_" + item.Caption;
            //		}

            //	MemoryStream ms = new MemoryStream();
            //	gridView1.SaveLayoutToStream(ms);
            //	byte[] buffer = ms.GetBuffer();

            //	templateService.Insert(new EllastixDataAccess.Models.GeneralsTemplate()
            //	{
            //		FormName = this.ParentForm.Name,
            //		UserCode = (Guid)EllastixLogService.Dto.ClientInformation.LogUserCode,
            //		GeneralsTemplateType = (int)TemplateTypes.GridLayout,
            //		GeneralsTemplateName = name,
            //		GeneralsTemplateValue = buffer
            //	});
            //	templateService.Save();
            //	AlertHelper.ShowSuccess(this.ParentForm, MessageHelper.GetMessage(149));
            //	InitializList();
            //}
            //catch (Exception ex)
            //{
            //	//MessageBox.Show(ex.Message);

            //}

        }

        private void GridLayoutClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            //	TemplateService templateService = new TemplateService();

            //	var data = templateService.Get(a => a.FormName == this.ParentForm.Name && a.GeneralsTemplateType == (int)TemplateTypes.GridLayout);
            //	if (data != null && data.Any())
            //	{
            //		templateService.DeleteRange(data);
            //		templateService.Save();
            //		AlertHelper.ShowSuccess(this.ParentForm, MessageHelper.GetMessage(148));
            //		InitializList();
            //	}
            //}
            //catch (Exception ex)
            //{
            //	//MessageBox.Show(ex.Message);

            //}
        }

        private void InitializList()
        {
            //try
            //{
            //	TemplateService templateService = new TemplateService();

            //	var repository = GridLayouts.Edit as RepositoryItemLookUpEdit;
            //	repository.NullText = "";
            //	repository.NullValuePrompt = "";
            //	repository.ShowNullValuePrompt = DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue;

            //	templateService = new TemplateService();
            //	var data = templateService.Get(a => a.FormName == this.ParentForm.Name && a.GeneralsTemplateType == (int)TemplateTypes.GridLayout);
            //	if (data != null && data.Any())
            //	{
            //		FillerHelper.SetData(repository, data, "GeneralsTemplateId", "GeneralsTemplateName", "GeneralsTemplateName");
            //	}
            //}
            //catch (Exception ex)
            //{
            //	// MessageBox.Show(ex.Message);

            //}
        }



        private void GridLayouts_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //	TemplateService templateService = new TemplateService();
            //	BarEditItem barEditItem = sender as BarEditItem;
            //	if (barEditItem != null && barEditItem.EditValue != null)
            //	{
            //		var data = templateService.Get(a => a.GeneralsTemplateId == Convert.ToInt32(barEditItem.EditValue)).FirstOrDefault();
            //		if (data != null)
            //		{
            //			byte[] bytes = data.GeneralsTemplateValue;
            //			if (bytes != null)
            //			{
            //				MemoryStream ms = new MemoryStream(bytes);
            //				if (ms != null)
            //				{
            //					gridView1.RestoreLayoutFromStream(ms);
            //				}
            //			}
            //		}

            //	}
            //}
            //catch (Exception ex)
            //{
            //	// MessageBox.Show(ex.Message);

            //}
        }

        private void EllastixGridControl_Load(object sender, EventArgs e)
        {
            try
            {
                InitializList();
                RepositoryItemZoomTrackBar zoomTrackBar = (GridZoom.Edit as RepositoryItemZoomTrackBar);
                GridZoom.EditValue = 0;
                zoomTrackBar.Minimum = -3;
                zoomTrackBar.Maximum = 15;
                zoomTrackBar.EditValueChanged += ZoomTrackBar_EditValueChanged;
            }
            catch
            {
            }


        }




        private void gridView1_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (ModifierKeys.HasFlag(Keys.Alt))
                {
                    int step = (e.Delta > 0) ? 1 : -1;
                    int next = _currentFontSizeDelta + step;

                    if (next >= FontDeltaMin && next <= FontDeltaMax)
                    {
                        ChangeFontSize(next);
                        GridZoom.EditValue = next; // هماهنگ کردن TrackBar
                    }

                }
            }
            catch
            {
            }
        }

        private int _currentFontSizeDelta = 0;
        private const int FontDeltaMin = -3;
        private const int FontDeltaMax = 15;
        private void ChangeFontSize(int newDelta)
        {
            if (newDelta < FontDeltaMin) newDelta = FontDeltaMin;
            if (newDelta > FontDeltaMax) newDelta = FontDeltaMax;

            int delta = newDelta - _currentFontSizeDelta;

            gridView1.Appearance.Row.FontSizeDelta += delta;
            gridView1.Appearance.HeaderPanel.FontSizeDelta += delta;
            gridView1.Appearance.FooterPanel.FontSizeDelta += delta;
            gridView1.Appearance.GroupPanel.FontSizeDelta += delta;
            gridView1.Appearance.FilterPanel.FontSizeDelta += delta;

            _currentFontSizeDelta = newDelta;
        }
        private void GridZoom_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (GridZoom.EditValue != null && int.TryParse(GridZoom.EditValue.ToString(), out int zoomValue))
                    ChangeFontSize(zoomValue);
            }
            catch
            {
            }
        }

        private void ZoomTrackBar_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (GridZoom.EditValue != null && int.TryParse(GridZoom.EditValue.ToString(), out int actualValue))
                {
                    int newValue = actualValue;

                    // ✅ معکوس دقیق فقط در حالت راست‌چین
                    if (this.RightToLeft == RightToLeft.Yes)
                    {
                        newValue = FontDeltaMax - (actualValue - FontDeltaMin);
                    }

                    ChangeFontSize(newValue);
                }
            }
            catch
            {
            }
        }
    }

}
