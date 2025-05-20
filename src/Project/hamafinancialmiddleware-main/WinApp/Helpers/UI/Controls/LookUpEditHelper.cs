using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Hama.WinApp.Helpers.UI.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hama.WinApp.Helpers.UI.Controls
{
	public class LookUpEditHelper
	{
		public static bool ValidateNodeChanged(Form form, GridView gridview,TreeListNode node, int nodeDepth, string columnName)
		{
			gridview.SetColumnError(gridview.Columns[columnName], null);
			// *********************************************************//
			if (node == null || node.Level < nodeDepth || node.HasChildren == true)
			{
				//gridview.SetFocusedRowCellValue(gridview.Columns[columnName], null);
				gridview.SetColumnError(gridview.Columns[columnName], $" سطح مجاز انتخاب از لیست " + $"{nodeDepth + 1}");
				AlertHelper.ShowError(form, $" سطح مجاز انتخاب از لیست " + $"{nodeDepth + 1}" + " میباشد ");
				return false;
			}
			return true;
		}

		public static void ValidateNodeChanged(Form form, ChangingEventArgs changingEventArgs, int nodeDepth, TreeListLookUpEdit AccountingCodingCode)
		{
			TreeList treeList = AccountingCodingCode.Properties.TreeList;
			var node = treeList.FindNodeByFieldValue("AccountingCodingCode", changingEventArgs.NewValue);
			// *********************************************************//
			if (node == null || node.Level < nodeDepth || node.HasChildren == true)
			{
				changingEventArgs.Cancel = true;
				changingEventArgs.NewValue = null;
				AccountingCodingCode.EditValue = null;
				AlertHelper.ShowError(form, $" سطح مجاز انتخاب از لیست " + $"{nodeDepth + 1}" + " میباشد ");
			}
		}

		public static void ValidateTreeListNodeChanging(Form form, DXErrorProvider dXError, ChangingEventArgs changingEventArgs, int nodeDepth, TreeListLookUpEdit accountingCodingCode)
		{

			var node = accountingCodingCode.Properties.TreeList.FindNodeByFieldValue("AccountingCodingCode", changingEventArgs.NewValue);

			// *********************************************************//
			if ((node == null || node.Level < nodeDepth || node.HasChildren == true) && accountingCodingCode.EditValue != null)
			{
				changingEventArgs.Cancel = true;
				changingEventArgs.NewValue = null;
				accountingCodingCode.EditValue = null;
				dXError.SetError(accountingCodingCode, $" سطح مجاز انتخاب از لیست کمتر از " + $"{nodeDepth + 1}");
				AlertHelper.ShowError(form, $" سطح مجاز انتخاب از لیست کمتر از " + $"{nodeDepth + 1}" + " میباشد ");
			}
			else
			{
				dXError.SetError(accountingCodingCode, "");
			}
		}

		public static void List_KeyDownOpen_Handle(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.ControlKey)
			{
				if (sender.GetType() == typeof(TreeListLookUpEdit))
					((TreeListLookUpEdit)sender).ShowPopup();
				else
				if (sender.GetType() == typeof(LookUpEdit))
					((LookUpEdit)sender).ShowPopup();
			}
		}

		public static void SetDefaultSetting(LookUpEdit lookUpEdit)
		{
			try
			{
				lookUpEdit.Properties.TextEditStyle = TextEditStyles.Standard;
				lookUpEdit.Properties.AllowNullInput = DefaultBoolean.True;
				lookUpEdit.Properties.NullValuePrompt = "";
				lookUpEdit.Properties.NullText = "";
				lookUpEdit.Properties.ShowNullValuePrompt = ShowNullValuePromptOptions.EmptyValue;
				lookUpEdit.Properties.PopupWidth = lookUpEdit.Properties.BestFit();
				lookUpEdit.Properties.UseCtrlScroll = true;
				lookUpEdit.Properties.ValidateOnEnterKey = true;

				lookUpEdit.Properties.NullText = string.Empty;
				lookUpEdit.Properties.KeyDown += List_KeyDownOpen_Handle;
			}
			catch
			{

			}
		}

		public static void SetDefaultSetting(RepositoryItemSearchLookUpEdit lookUpEdit)
		{
			try
			{
				lookUpEdit.TextEditStyle = TextEditStyles.Standard;
				lookUpEdit.AllowNullInput = DefaultBoolean.True;
				lookUpEdit.NullValuePrompt = "";
				lookUpEdit.NullText = "";
				lookUpEdit.ShowNullValuePrompt = ShowNullValuePromptOptions.EmptyValue;
				lookUpEdit.UseCtrlScroll = true;
				lookUpEdit.ValidateOnEnterKey = true;

				lookUpEdit.NullText = string.Empty;
				lookUpEdit.KeyDown += List_KeyDownOpen_Handle;
			}
			catch
			{

			}
		}

		public static void SetDefaultSetting(SearchLookUpEdit lookUpEdit)
		{
			try
			{
				lookUpEdit.Properties.TextEditStyle = TextEditStyles.Standard;
				lookUpEdit.Properties.AllowNullInput = DefaultBoolean.True;
				lookUpEdit.Properties.NullValuePrompt = "";
				lookUpEdit.Properties.NullText = "";
				lookUpEdit.Properties.ShowNullValuePrompt = ShowNullValuePromptOptions.EmptyValue;
				lookUpEdit.Properties.UseCtrlScroll = true;
				lookUpEdit.Properties.ValidateOnEnterKey = true;

				lookUpEdit.Properties.NullText = string.Empty;
				lookUpEdit.Properties.KeyDown += List_KeyDownOpen_Handle;
			}
			catch
			{

			}
		}

		public static void SetDefaultSetting(RepositoryItemLookUpEdit lookUpEdit)
		{
			lookUpEdit.TextEditStyle = TextEditStyles.Standard;
			lookUpEdit.AllowNullInput = DefaultBoolean.True;
			lookUpEdit.NullValuePrompt = "";
			lookUpEdit.NullText = "";
			//lookUpEdit.PopupWidth = lookUpEdit.BestFit();
			lookUpEdit.UseCtrlScroll = true;
			lookUpEdit.ValidateOnEnterKey = true;
			lookUpEdit.NullText = string.Empty;
			lookUpEdit.KeyDown += List_KeyDownOpen_Handle;
		}

		public static void SetDefaultSetting(RepositoryItemTreeListLookUpEdit treeListlookUpEdit)
		{
			treeListlookUpEdit.NullValuePrompt = "";
			treeListlookUpEdit.NullText = "";
			treeListlookUpEdit.UseCtrlScroll = true;
			treeListlookUpEdit.ValidateOnEnterKey = true;

			treeListlookUpEdit.NullText = string.Empty;
			treeListlookUpEdit.KeyDown += List_KeyDownOpen_Handle;
		}

		public static void SetDefaultSetting(TreeListLookUpEdit lookUpEdit)
		{
			try
			{
				lookUpEdit.Properties.TextEditStyle = TextEditStyles.Standard;
				lookUpEdit.Properties.AllowNullInput = DefaultBoolean.True;
				lookUpEdit.Properties.NullValuePrompt = "";
				lookUpEdit.Properties.NullText = "";
				lookUpEdit.Properties.ShowNullValuePrompt = ShowNullValuePromptOptions.EmptyValue;
				lookUpEdit.Properties.UseCtrlScroll = true;
				lookUpEdit.Properties.ValidateOnEnterKey = true;

				lookUpEdit.Properties.NullText = string.Empty;
				lookUpEdit.Properties.KeyDown += List_KeyDownOpen_Handle;

			}
			catch
			{

			}
		}
		

	}
}
