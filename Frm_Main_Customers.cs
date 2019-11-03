using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_KiemThuPhanMem
{
	//public static class PanelExtension
	//{
	//	public static void ScrollBack(this Panel pnl, int pos)
	//	{
	//		using (Control c = new Control() { Parent = pnl, Height = 1, Width = pnl.ClientSize.Width + pos })
	//		{
	//			pnl.ScrollControlIntoView(c);
	//		}
	//	}
	//	public static void ScrollNext(this Panel pnl, int pos)
	//	{
	//		using (Control c = new Control() { Parent = pnl, Height = 1, Width = pos })
	//		{
	//			pnl.ScrollControlIntoView(c);
	//		}
	//	}
	//}
	public partial class Frm_Main_Customers : Form
	{
		SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
		//private const int VerticalStep = 40;
		//private int location = 0;
		public Frm_Main_Customers()
		{
			InitializeComponent();
			//pnl_SunG.AutoScrollPosition = new Point(0,0);
			//pnl_SunG.VerticalScroll.Maximum = 200;
		}

		private void Frm_Main_Customers_Load(object sender, EventArgs e)
		{

		}
		
		


		int i = 0;
		private void btnNext_SunG_Click(object sender, EventArgs e)
		{
			//if ((pnl_SunG.HorizontalScroll.Value + pnl_SunG.HorizontalScroll.SmallChange) >= pnl_SunG.HorizontalScroll.Maximum)
			//	pnl_SunG.HorizontalScroll.Value = pnl_SunG.HorizontalScroll.Maximum;
			//else
			//	pnl_SunG.HorizontalScroll.Value += pnl_SunG.HorizontalScroll.SmallChange;
			//if (location - 20 > 0)
			//{
			//	location -= 20;
			//	pnl_SunG.VerticalScroll.Value = location;
			//}
			//else
			//{
			//	location = 0;
			//	pnl_SunG.AutoScrollPosition = new Point(0, 0);
			//}

			if (i >= 0)
				i = -1;
			//pnl_SunG.ScrollNext(i--);
		}

		private void btnBack_SunG_Click(object sender, EventArgs e)
		{
			//if ((pnl_SunG.HorizontalScroll.Value + pnl_SunG.HorizontalScroll.SmallChange) < pnl_SunG.HorizontalScroll.Maximum)
			//	pnl_SunG.HorizontalScroll.Value = pnl_SunG.HorizontalScroll.Maximum;
			//else
			//	pnl_SunG.HorizontalScroll.Value -= pnl_SunG.HorizontalScroll.SmallChange;
			//if (location + 20 < pnl_SunG.VerticalScroll.Maximum)
			//{
			//	location += 100;
			//	pnl_SunG.VerticalScroll.Value = location;
			//}
			//else
			//{
			//	location = pnl_SunG.VerticalScroll.Maximum;
			//	pnl_SunG.AutoScrollPosition = new Point(0, location);
			//}
			if (i < 0)
				i = 0;
			//pnl_SunG.ScrollBack(i++);
		}

	}
}
