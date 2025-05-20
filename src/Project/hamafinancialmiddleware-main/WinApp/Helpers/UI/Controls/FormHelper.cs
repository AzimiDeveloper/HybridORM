using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Hama.WinApp.Helpers.UI.Controls
{
    public class AppForm
    {
        public string FullName { get; set; }
        public string Name { get; set; }
    }

    public class FormHelper
    {
		public static List<Form> GetAllForms()
		{
            try
            {
                var formType = typeof(Form);
                var assembly = Assembly.GetExecutingAssembly();

                var formTypes = assembly.GetTypes()
                                        .Where(t => t.IsSubclassOf(formType) && !t.IsAbstract)
                                        .ToList();

                var forms = new List<Form>();
                foreach (var type in formTypes)
                {
                    // بررسی وجود سازنده بدون پارامتر
                    var constructor = type.GetConstructor(Type.EmptyTypes);
                    if (constructor != null)
                    {
                        var form = (Form)Activator.CreateInstance(type);

                        // بررسی بلک لیست
                        string[] blackListForm = new string[] { "test", "xtra", "calendar", "base", "applications", "main", "login" };
                        if (!string.IsNullOrEmpty(form.Name) &&
                            !blackListForm.Any(bl => form.Name.ToLower().Contains(bl)))
                        {
                            forms.Add(form);
                        }

                    }
                    else
                    {
                        // فرم‌هایی که سازنده بدون پارامتر ندارند را به لیست خطا اضافه کنید یا لاگ کنید
                         //MessageBox.Show($"Form '{type.Name}' does not have a parameterless constructor");
                    }
                }

                return forms.DistinctBy(f => f.Name).OrderBy(a => a.Name).ToList();
            }
            catch 
            { 
                return null;
            }
		}



		public static IList<T> GetAllControlsRecusrvive<T>(Control root) where T : Control
        {
            var result = new List<T>();
            foreach (Control item in root.Controls)
            {
                var control = item as T;
                if (control != null)
                {
                    result.Add(control);
                }
                else
                {
                    result.AddRange(GetAllControlsRecusrvive<T>(item));
                }

            }
            return result;
        }

        public static void ShowForm(string formName)
        {
            Form form = Application.OpenForms[formName];
            if (form != null)
            {
                form.Show();
            } 
        }

        public static Form FindForm(string formName)
        {
            Form form = Application.OpenForms[formName];
            return form;
        }

        public static void CloseForm(string formName)
        {
            Form formToClose = Application.OpenForms[formName];
            if (formToClose != null)
            {
                formToClose.Hide();
            }
        }

        public static void  ShowMdiForm( Form child, Form parent , bool down = false)
        {

            if (parent == null)
                child.Show();

            if (down)
            {
                child.MdiParent = parent;
                child.Show();
            }
            else
            {
                child.ShowInTaskbar = true;
                child.Show();
            }
        }
    }

    public class FormGirdProperties
    {
        public string FormName { get; set; }
        public string EntityType { get; set; }
        public List<PropertyInfo> Properties { get; set; }
    }
}
