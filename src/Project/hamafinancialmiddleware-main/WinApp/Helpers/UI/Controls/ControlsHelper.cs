using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraLayout;
using Hama.WinApp.Views.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace Hama.WinApp.Helpers.UI.Controls
{
	public static class ControlsHelper
	{

        public static void TextNumber(object sender, KeyPressEventArgs e)
        {
            // اگر ورودی کاراکتر عددی نباشد و یا Backspace نباشد، آن را لغو می‌کند
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public static IList<T> GetAllBarItems<T>(BarManager barManager) where T : BarItem
		{
			return barManager.Items.OfType<T>().ToList();
		}

		public static BarManager GetBarManager(Form form)
		{
			var barManagerField = form.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
									   .FirstOrDefault(f => typeof(BarManager).IsAssignableFrom(f.FieldType));
			if (barManagerField != null)
			{
				return (BarManager)barManagerField.GetValue(form);
			}
			return null;
		}

		public static List<CustomGridControl> GetEllastixGridControls(Form form)
		{
			var fields = form.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
							   .Where(f => typeof(CustomGridControl).IsAssignableFrom(f.FieldType));

			List<CustomGridControl> gridControls = new List<CustomGridControl>();

			foreach (var field in fields)
			{
				var gridControl = field.GetValue(form) as CustomGridControl;
				if (gridControl != null)
				{
					gridControls.Add(gridControl);
				}
			}

			return gridControls;
		}



		public static List<Type> CrudControls
		{
			get
			{
				return new List<Type> { typeof(TreeListLookUpEdit), typeof(LookUpEdit), typeof(TextEdit), typeof(SpinEdit), typeof(ButtonEdit), typeof(DateTimeOffsetEdit), typeof(MemoEdit), typeof(TokenEdit), typeof(RadioGroup) };
			}
		}

		// دریافت نام نمایشی کنترل
		public static string GetControlDisplayName(BaseEdit control)
		{
			var layoutItem = FindLayoutControlItem(control);
			return layoutItem != null ? layoutItem.Text : string.Empty;
		}

		// پیدا کردن LayoutControlItem که کنترل در آن قرار دارد
		private static LayoutControlItem FindLayoutControlItem(Control control)
		{
			if (control == null)
				return null;

			// والدین کنترل را پیمایش می‌کنیم تا به LayoutControl برسیم
			Control parent = control.Parent;
			while (parent != null && !(parent is LayoutControl))
			{
				parent = parent.Parent;
			}

			// اگر والد LayoutControl پیدا شد، آیتم‌های آن را بررسی می‌کنیم
			if (parent != null)
			{
				LayoutControl layoutControl = parent as LayoutControl;
				foreach (BaseLayoutItem item in layoutControl.Items)
				{
					if (item is LayoutControlItem layoutItem && layoutItem.Control == control)
					{
						return layoutItem;
					}
				}
			}

			return null;
		}


		// دریافت کنترل بر اساس نام
		public static Control GetControl(Form form, string controlName)
		{
			var controls = GetAllControls(form);
			var control = controls.Where(a => a.Name.ToLower().Trim() == "control_" + controlName.ToLower().Trim()).FirstOrDefault();
			return control;
		}

		// دریافت تمامی کنترل‌ها
		public static IEnumerable<Control> GetAllControls(Control control)
		{
			var controls = control.Controls.Cast<Control>();
			return controls.SelectMany(ctrl => GetAllControls(ctrl)).Concat(controls);
		}

		// دریافت تمامی کنترل‌ها بر اساس نوع
		public static IEnumerable<Control> GetAll(Control control, List<Type> types)
		{
			var controls = control.Controls.Cast<Control>();
			return controls.SelectMany(ctrl => GetAll(ctrl, types))
									  .Concat(controls)
									  .Where(c => types.Contains(c.GetType()));
		}

		// دریافت تمامی کنترل‌ها، آیتم‌های نوار ابزار و آیتم‌های چیدمان
		public static (IEnumerable<Control> controls, IEnumerable<BarItem> barItems, IEnumerable<BaseLayoutItem> layouts) GetAll(this Control control)
		{
			List<Control> controls = new();
			List<BarItem> barItems = new();
			List<BaseLayoutItem> layouts = new();

			controls.Add(control);
			if (control is BarDockControl)
			{
				var barDocControl = (BarDockControl)control;
				var barManager = barDocControl.Manager as BarManager;
				barItems.AddRange(barManager.Items);
			}
			else if (control is LayoutControl)
			{
				layouts.AddRange(((LayoutControl)control).Items.ToList());
			}
			else
			{
				foreach (var item in control.Controls)
				{
					var result = ((Control)item).GetAll();
					controls.AddRange(result.controls);
					barItems.AddRange(result.barItems);
					layouts.AddRange(result.layouts);
				}
			}

			return (controls, barItems, layouts);
		}

		// تنظیم Mask برای RepositoryItemCalcEdit
		public static void InitiliazeMaskRepositoryItemCalcEdit(RepositoryItemCalcEdit repositoryItemCalcEdit, int lenghtCurrency)
		{
			if (lenghtCurrency < 1)
			{
				repositoryItemCalcEdit.MaskSettings.Configure<MaskSettings.Numeric>(settings => { settings.MaskExpression = "n0"; });
				repositoryItemCalcEdit.Mask.MaskType = MaskType.Numeric;
				repositoryItemCalcEdit.Mask.EditMask = "N0";
				repositoryItemCalcEdit.Mask.UseMaskAsDisplayFormat = true;
			}
			else
			{
				var mask = "###,###,###,###,###,###,#.";
				for (int i = 1; i <= lenghtCurrency; i++)
				{
					mask += "#";
				}
				repositoryItemCalcEdit.MaskSettings.Configure<MaskSettings.Numeric>(settings => { settings.MaskExpression = mask; });
				repositoryItemCalcEdit.Mask.MaskType = MaskType.Numeric;
				repositoryItemCalcEdit.Mask.EditMask = mask;
				repositoryItemCalcEdit.Mask.UseMaskAsDisplayFormat = true;
			}
		}
	}

	// افزودن افکت Blur به عناصر UI
	public static class BlurElementExtension
	{
		public static void BlurApply(this UIElement element, double blurRadius, TimeSpan duration, TimeSpan beginTime)
		{
			BlurEffect blur = new BlurEffect() { Radius = 0 };
			DoubleAnimation blurEnable = new DoubleAnimation(0, blurRadius, duration)
			{ BeginTime = beginTime };
			element.Effect = blur;
			blur.BeginAnimation(BlurEffect.RadiusProperty, blurEnable);
		}

		public static void BlurDisable(this UIElement element, TimeSpan duration, TimeSpan beginTime)
		{
			BlurEffect blur = element.Effect as BlurEffect;
			if (blur == null || blur.Radius == 0)
			{
				return;
			}
			DoubleAnimation blurDisable = new DoubleAnimation(blur.Radius, 0, duration) { BeginTime = beginTime };
			blur.BeginAnimation(BlurEffect.RadiusProperty, blurDisable);
		}
	}
}
