using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_KiemThuPhanMem
{
	public partial class Frm_Main_Customers : Form
	{
		public Frm_Main_Customers()
		{
			InitializeComponent();
			panel4.HorizontalScroll.Maximum = 50000;
		}

		private void Frm_Main_Customers_Load(object sender, EventArgs e)
		{

		}
		//public int scrollValue = 0;
		//public int ScrollValue
		//{
		//	get
		//	{
		//		return scrollValue;
		//	}
		//	set 
		//	{
		//		scrollValue = value;
			
		//		if(scrollValue < flpSunG.VerticalScroll.Minimum)
		//		{
		//			scrollValue = flpSunG.VerticalScroll.Minimum;
		//		}
		//		if(scrollValue > flpSunG.VerticalScroll.Maximum)
		//		{
		//			scrollValue = flpSunG.VerticalScroll.Maximum;
		//		}
		//		flpSunG.VerticalScroll.Value = scrollValue;
		//		flpSunG.PerformLayout();
		//	}
		//}

		private const int VerticalStep = 40;
		

		private void btnNext_SunG_Click(object sender, EventArgs e)
		{
			//int change = flpSunG.VerticalScroll.Value + flpSunG.VerticalScroll.SmallChange * 30;
			//flpSunG.AutoScrollPosition = new Point(0,change);

			//scrollValue -= flpSunG.VerticalScroll.LargeChange;

			//flpSunG.Right -= VerticalStep;

			if ((panel4.HorizontalScroll.Value + panel4.HorizontalScroll.SmallChange) >= panel4.HorizontalScroll.Maximum)
				panel4.HorizontalScroll.Value = panel4.HorizontalScroll.Maximum;
			else
				panel4.HorizontalScroll.Value += panel4.HorizontalScroll.SmallChange;
		}

		private void btnBack_SunG_Click(object sender, EventArgs e)
		{
			//int change = flpSunG.VerticalScroll.Value - flpSunG.VerticalScroll.SmallChange * 30;
			//flpSunG.AutoScrollPosition = new Point(0, change);

			//scrollValue += flpSunG.VerticalScroll.LargeChange;

			//flpSunG.Right += VerticalStep;

			if ((panel4.HorizontalScroll.Value + panel4.HorizontalScroll.SmallChange) < panel4.HorizontalScroll.Maximum)
				panel4.HorizontalScroll.Value = panel4.HorizontalScroll.Maximum;
			else
				panel4.HorizontalScroll.Value -= panel4.HorizontalScroll.SmallChange;
		}

	}
}
