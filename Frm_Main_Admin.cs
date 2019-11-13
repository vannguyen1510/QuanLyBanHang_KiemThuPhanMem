﻿using System;
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
		SqlConnection sqlcon = new SqlConnection("Data Source= VAN;Initial Catalog=KTPM;Integrated Security=True");
		public Frm_Main_Admin()
		{
			InitializeComponent();
		}

		private void btnBill_Click(object sender, EventArgs e)
		{
			this.Hide();
			Frm_Bill bill = new Frm_Bill();
			bill.Show();
			Visible = false;
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
			this.Hide();
            Frm_List_Cus_Emp evc = new Frm_List_Cus_Emp();
            evc.Show();
			Visible = false;
		}

        private void btnCus_Click(object sender, EventArgs e)
        {
			this.Hide();
            Frm_List_Cus_Emp evc = new Frm_List_Cus_Emp();
            evc.Show();
			Visible = false;
		}

        private void btnOut_Click(object sender, EventArgs e)
        {
			this.Hide();
            Frm_SignIn sin = new Frm_SignIn();
            sin.Show();
			Visible = false;
		}
	}
}
