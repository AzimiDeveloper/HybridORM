using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hama.WinApp.Interfaces
{
	public interface IBarItemInitializer
	{
		public void InitializeBarItemVisible(BarItem[] items);
	}

}
