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
	public partial class Frm_Print : Form
	{
		public Frm_Print()
		{
			InitializeComponent();
		}

		private void crystalReportViewer1_Load(object sender, EventArgs e)
		{
			PrintBill pr = new PrintBill();
			crystalReportViewer1.ReportSource = pr;
		}
	}
}
