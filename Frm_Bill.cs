using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Configuration;

namespace QLBH_KiemThuPhanMem
{
	public partial class Frm_Bill : Form
	{
		// SQL CONNECTION
        //SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["QLBH_KiemThuPhanMem.Properties.Settings.KTPMConnectionString"].ToString());
		SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());

		// RANDOM BILL NO
		private const String allChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private readonly char[] allCharArray = (allChar + allChar.ToUpper() + "0123456789").ToCharArray();

		public Frm_Bill()
		{
			InitializeComponent();
		}

		private void Frm_Bill_Load(object sender, EventArgs e)
		{
			Load_combobCus_ID();
			Load_combobEmp_ID();
		}

		// Function - Random Bill No
		private string RandomString(int count)
		{
			StringBuilder result = new StringBuilder();
			Random rd = new Random();
			for(int i = 0; i< count; i++)
			{
				result.Append(allCharArray[rd.Next(allCharArray.Length)]);
			}
			return result.ToString();
		}
		// Checkbox Bill No
		private void cbRandomBillNo_CheckedChanged(object sender, EventArgs e)
		{
			if(cbRandomBillNo.Checked == true)
			{
				txtBillNo.Text = RandomString(Convert.ToInt32(5));
			}
			else
			{
				txtBillNo.Text = string.Empty;
			}
		}

		// Function - Load Employee ID
		public void Load_combobEmp_ID()
		{
			combobEmp_ID.Items.Clear();
			string sql = "SELECT ID_Emp FROM Info_Emp";
			SqlCommand cmd = new SqlCommand(sql, sqlcon);
			cmd.ExecuteNonQuery();
			SqlDataAdapter data = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			data.Fill(dt);
			foreach (DataRow dr in dt.Rows)
			{
				combobEmp_ID.Items.Add(dr["ID_Emp"].ToString());
			}
		}
		// Kiểm tra Employee
		private void combobEmp_ID_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
			string sql = "SELECT FirstName_Emp FROM Info_Emp WHERE ID_Emp = '" + combobEmp_ID.Text + "'COLLATE SQL_Latin1_General_CP1_CS_AS"; 
				SqlCommand cmd = new SqlCommand(sql, sqlcon);
				cmd.ExecuteNonQuery();
				SqlDataReader dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					string name = (string)dr["FirstName_Emp"].ToString();
					txtEmp_Name.Text = name;
				}
				sqlcon.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error Connection. Please try again !", "ERROR");
			}
			
		}
		private void combobEmp_ID_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(combobEmp_ID.Text))
			{
				e.Cancel = true;
				combobEmp_ID.Focus();
				errorProvider1.SetError(combobEmp_ID, " Do not accept blank field !");
			}
			else
			{
				e.Cancel = false;
				errorProvider1.SetError(combobEmp_ID, null);
			}
		}

		// Function - Load Customer ID
		public void Load_combobCus_ID()
		{
			combobCus_ID.Items.Clear();
			sqlcon.Open();
			string sql = "SELECT ID_Cus FROM Info_Cus";
			SqlCommand cmd = new SqlCommand(sql, sqlcon);
			cmd.ExecuteNonQuery();
			SqlDataAdapter data = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			data.Fill(dt);
			foreach (DataRow dr in dt.Rows)
			{
				combobCus_ID.Items.Add(dr["ID_Cus"].ToString());
			}
		}
		// Kiểm tra Customer
		private void combobCus_ID_SelectedIndexChanged(object sender, EventArgs e)
		{
			//try
			//{
			sqlcon.Open();
			for (int i = 0; i <= combobCus_ID.Items.Count - 1; i++)
				{
					if (combobCus_ID.Text.Equals(combobCus_ID.GetItemText(combobCus_ID.Items[i].ToString())))
					{
					
					string sql = "SELECT FirstName_Cus, Address_Cus, Phone_Cus FROM Info_Cus WHERE ID_Cus = " + combobCus_ID.Text ;
						SqlCommand cmd = new SqlCommand(sql, sqlcon);
						cmd.ExecuteNonQuery();
						SqlDataReader dr = cmd.ExecuteReader();
						while (dr.Read())
						{
							string name = (string)dr["FirstName_Cus"].ToString();
							string address = (string)dr["Address_Cus"].ToString();
							string phone = (string)dr["Phone_Cus"].ToString();
							txtCus_Name.Text = name;
							txtCus_Address.Text = address;
							txtCus_Phone.Text = phone;
						}
					}
				}
			sqlcon.Close();
			//}
			//catch (Exception ex)
			//{
				//MessageBox.Show("Error Connection. Please try again !", "ERROR");
			//}
		}
		private void combobCus_ID_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(combobCus_ID.Text))
			{
				e.Cancel = true;
				combobCus_ID.Focus();
				errorProvider1.SetError(combobCus_ID, " Do not accept blank field !");
			}
			else
			{
				e.Cancel = false;
				errorProvider1.SetError(combobCus_ID, null);
			}
		}
	}
}
