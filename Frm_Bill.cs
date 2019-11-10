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
			Load_combobPro_No();
			Load_combobShipper();
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
			//sqlcon.Open();
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
			try
			{
				sqlcon.Open();
				for (int i = 0; i <= combobCus_ID.Items.Count - 1; i++)
				{
					if (combobCus_ID.Text.Equals(combobCus_ID.GetItemText(combobCus_ID.Items[i].ToString())))
					{

						string sql = "SELECT FirstName_Cus, Address_Cus, Phone_Cus FROM Info_Cus WHERE ID_Cus = " + combobCus_ID.Text;
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
				//sqlcon.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error Connection. Please try again !", "ERROR");
			}
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

		// Function - Load Shipper
		public void Load_combobShipper()
		{
			combobShipper.Items.Clear();
			//sqlcon.Open();
			string sql = "SELECT Company FROM Shippers";
			SqlCommand cmd = new SqlCommand(sql, sqlcon);
			cmd.ExecuteNonQuery();
			SqlDataAdapter data = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			data.Fill(dt);
			foreach (DataRow dr in dt.Rows)
			{
				combobShipper.Items.Add(dr["Company"].ToString());
			}
		}
		// Kiểm tra Shipper
		private void combobShipper_SelectedIndexChanged(object sender, EventArgs e)
		{
			//sqlcon.Open();
			try
			{
				
				for (int i = 0; i <= combobShipper.Items.Count - 1; i++)
				{
					if (combobShipper.Text.Equals(combobShipper.GetItemText(combobShipper.Items[i].ToString())))
					{

						string sql = "SELECT Company FROM Shippers WHERE Company = " + combobShipper.Text;
						SqlCommand cmd = new SqlCommand(sql, sqlcon);
						cmd.ExecuteNonQuery();
						SqlDataReader dr = cmd.ExecuteReader();
						while (dr.Read())
						{
							string shipper = (string)dr["Company"].ToString();
							combobShipper.Text = shipper;
						}
					}
				}
				sqlcon.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error Connection. Please try again !", "ERROR");
			}
		}

		// Function - Load Products
		public void Load_combobPro_No()
		{
			combobPro_No.Items.Clear();
			sqlcon.Open();
			string sql = "SELECT ProductID FROM Products";
			SqlCommand cmd = new SqlCommand(sql, sqlcon);
			cmd.ExecuteNonQuery();
			SqlDataAdapter data = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			data.Fill(dt);
			foreach (DataRow dr in dt.Rows)
			{
				combobPro_No.Items.Add(dr["ProductID"].ToString());
			}
		}
		// Kiểm tra Product
		private void combobPro_No_SelectedIndexChanged(object sender, EventArgs e)
		{
			//sqlcon.Open();
			//try
			//{
				for (int i = 0; i <= combobPro_No.Items.Count - 1; i++)
				{
					if (combobPro_No.Text.Equals(combobPro_No.GetItemText(combobPro_No.Items[i].ToString())))
					{

						string sql = "SELECT ProductName, UnitPrice FROM Products WHERE ProductID = " + combobPro_No.Text;
						SqlCommand cmd = new SqlCommand(sql, sqlcon);
						cmd.ExecuteNonQuery();
						SqlDataReader dr = cmd.ExecuteReader();
						while (dr.Read())
						{
							string proName = (string)dr["ProductName"].ToString();
							string proUnitPrice = (string)dr["UnitPrice"].ToString();
							txtPro_Name.Text = proName;
							txtPro_UnitPrice.Text = proUnitPrice;
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

		private void txtPro_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar > (char)47) && (e.KeyChar < (char)58) // 0-9
				|| (e.KeyChar == (char)8)) // backspace
			{
				txtPro_SoLuong.ShortcutsEnabled = false;
				e.Handled = false;
			}
			else
			{
				errorProvider1.SetError(txtPro_SoLuong, "Accept only numbers!");
				e.Handled = true;
			}
		}

		private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar > (char)47) && (e.KeyChar < (char)58) // 0-9
				|| (e.KeyChar == (char)8)) // backspace
			{
				txtDiscount.ShortcutsEnabled = false;
				e.Handled = false;
			}
			else
			{
				errorProvider1.SetError(txtDiscount, "Accept only numbers!");
				e.Handled = true;
			}
		}

		// Thay đổi số lượng thì tính lại tiền
		private void txtPro_SoLuong_TextChanged(object sender, EventArgs e)
		{
			double total, quantity, price, dis;
			if (txtPro_SoLuong.Text == "")
				quantity = 0;
			else
				quantity = Convert.ToDouble(txtPro_SoLuong.Text);
			if (txtDiscount.Text == "")
				dis = 0;
			else
				dis = Convert.ToDouble(txtDiscount.Text);
			if (txtPro_UnitPrice.Text == "")
				price = 0;
			else
				price = Convert.ToDouble(txtPro_UnitPrice.Text);
			total = quantity * price - quantity * price * dis / 100;
			txtTamTinh.Text = total.ToString();
		}
		// Thay đổi disount thì tính lại tiền
		private void txtDiscount_TextChanged(object sender, EventArgs e)
		{
			double total, quantity, price, dis;
			if (txtPro_SoLuong.Text == "")
				quantity = 0;
			else
				quantity = Convert.ToDouble(txtPro_SoLuong.Text);
			if (txtDiscount.Text == "")
				dis = 0;
			else
				dis = Convert.ToDouble(txtDiscount.Text);
			if (txtPro_UnitPrice.Text == "")
				price = 0;
			else
				price = Convert.ToDouble(txtPro_UnitPrice.Text);
			total = quantity * price - quantity * price * dis / 100;
			txtTamTinh.Text = total.ToString();
		}
	}
}
