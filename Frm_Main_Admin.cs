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
	
	public partial class Frm_Main_Admin : Form
	{
		//SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
		public Frm_Main_Admin()
		{
			InitializeComponent();
            //btnEmp.Click += btnEmp_Click;
		}

		private void btnBill_Click(object sender, EventArgs e)
		{
			Frm_Bill bill = new Frm_Bill();
			bill.Show();
		}
        // Function Open tab Employee in Frm_List_Cus_Emp

        //protected void OnOpenTab_Emp()
        //{
        //    if (OnOpenTab_Emp != null)
        //    {
        //        OnOpenTab_Emp(this, EventArgs.Empty);
        //    }
        //}
        private void btnEmp_Click(object sender, EventArgs e)
        {
            Frm_List_Cus_Emp evc = new Frm_List_Cus_Emp();
            evc.Show();
        }

        private void btnCus_Click(object sender, EventArgs e)
        {
            Frm_List_Cus_Emp evc = new Frm_List_Cus_Emp();
            evc.Show();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            Frm_SignIn sin = new Frm_SignIn();
            sin.Show();
        }
	}
}
