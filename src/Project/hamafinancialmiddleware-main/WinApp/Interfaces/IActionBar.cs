using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hama.WinApp.Interfaces
{
    public interface IActionBar
    {
        public Task<bool> ValidateForm();
        public Task<bool> ActionReload();
        public Task InitializeForm();
        public Task ClearForm();
        public Task ClearValidation();
        public Task InitializeGrid();
        public Task SetTitle(DevExpress.XtraGrid.Views.Grid.GridView grid);
        public Task InitializeList();
        public Task ActionNew();
        public Task ActionSave();
        public Task ActionEdit();
        public Task ActionDelete();
        public Task ActionDoubleCheck();
        public Task ActionSelectAll();
        public Task ActionFastEntry();
        public Task ActionCopy();
        public Task ActionImportExcel();
        public Task ActionState();
        public Task ActionQRCode();
        public Task ActionSend();
        public Task ActionFirst();
        public Task ActionPrevious();
        public Task ActionNext();
        public Task ActionLast();
        public Task ActionLock();
        public Task ActionBookmark();
        public Task ActionAttachment();
        public Task ActionComment();
        public Task ActionNavigation();
        public Task ActionDownload();
        public Task ActionUpload();
        public Task ActionPrint();
        public Task ActionLTR();
        public Task ActionRTL();
        public Task ActionAlignLeft();
        public Task ActionAlignCenter();
        public Task ActionAlignRight();
        public Task ActionRowPositionTop();
        public Task ActionRowPositionBottom();
        public Task ActionSimulation();

    }
}
