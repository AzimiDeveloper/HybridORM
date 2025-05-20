using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Hama.Core.Models;
using Hama.Service.Interfaces.ORM;

namespace Hama.WinApp.Views.Forms.Documents
{
	public partial class VocucherPreviewForm: BaseForm
	{
        public VocucherPreviewForm()
        {
            InitializeComponent();

            _visibleBarItems = new[]
            {
                barButtonItemSave,
            };

            InitializeBarItemVisible(_visibleBarItems);
        }

    }
}