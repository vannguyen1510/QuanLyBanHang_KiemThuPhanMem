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
using System.Globalization;

namespace QLBH_KiemThuPhanMem
{
	public partial class Frm_Bill : Form
	{
		// SQL CONNECTION
		//SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["QLBH_KiemThuPhanMem.Properties.Settings.KTPMConnectionString"].ToString());
		//SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
		SqlConnection sqlcon = new SqlConnection("Data Source= VAN;Initial Catalog=KTPM;Integrated Security=True");
		
		//---------------------------------------------------------------------------------------------------------------------------------------------------------
		// RANDOM BILL NO
		private const String allChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private readonly char[] allCharArray = (allChar + allChar.ToUpper() + "0123456789").ToCharArray();

		public Frm_Bill()
		{
			InitializeComponent();
		}

		private void Frm_Bill_Load(object sender, EventArgs e)
		{
			Collumn_Load();
			Load_combobPro_No();
			Load_combobShipper();
			Load_combobCus_ID();
			Load_combobEmp_ID();

		}
		// Chỉ được nhập số
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
		// Kiểm tra textbox rỗng
		public void CheckNullTextbox()
		{
			if (txtPro_SoLuong.Text == "")
			{
				errorProvider1.SetError(txtPro_SoLuong, "Do not accept blank field !");
			}
		}
		private void combobEmp_ID_TextChanged(object sender, EventArgs e)
		{
			if (combobCus_ID.Text == "")
			{
				errorProvider1.SetError(combobCus_ID, "Please enter employee ID!");
			}
		}
		private void combobShipper_TextChanged(object sender, EventArgs e)
		{
			if (combobShipper.Text == "")
			{
				errorProvider1.SetError(combobShipper, "Please enter shipper!");
			}
		}
		private void combobCus_ID_TextChanged(object sender, EventArgs e)
		{
			if (combobCus_ID.Text == "")
			{
				errorProvider1.SetError(combobCus_ID, "Please enter customer ID!");
			}
		}
		private void combobPro_No_TextChanged(object sender, EventArgs e)
		{
			if (combobPro_No.Text == "")
			{
				errorProvider1.SetError(combobPro_No, "Please enter product ID!");
			}
		}

		// Load cột Listview
		public void Collumn_Load()
		{
			listView1.View = View.Details;
			listView1.Columns.Add("Number", 60, HorizontalAlignment.Center);
			listView1.Columns.Add("Product ID", 115, HorizontalAlignment.Center);
			listView1.Columns.Add("Product Name", 172, HorizontalAlignment.Center);
			listView1.Columns.Add("Quantity", 70, HorizontalAlignment.Center);
			listView1.Columns.Add("Unit Price", 120, HorizontalAlignment.Center);
			listView1.Columns.Add("Sub total", 160, HorizontalAlignment.Center);
			timer1.Enabled = true;
			this.Opacity = 1;
		}
		

		//---------------------------------------------------------------------------------
		// Function - Random Bill No
		private string RandomString(int count)
		{
			StringBuilder result = new StringBuilder();
			Random rd = new Random();
			for (int i = 0; i < count; i++)
			{
				result.Append(allCharArray[rd.Next(allCharArray.Length)]);
			}
			return result.ToString();
		}
		// Checkbox Bill No
		private void cbRandomBillNo_CheckedChanged(object sender, EventArgs e)
		{
			if (cbRandomBillNo.Checked == true)
			{
				txtBillNo.Text = RandomString(Convert.ToInt32(5));
				txtBillNo.Enabled = false;
			}
			else
			{
				txtBillNo.Enabled = false;
			}
		}
		//---------------------------------------------------------------------------------
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
				sqlcon.Close();
				sqlcon.Open();
				string sql = "SELECT FirstName_Emp FROM Info_Emp WHERE ID_Emp = '" + combobEmp_ID.Text + "'COLLATE SQL_Latin1_General_CP1_CS_AS";
				SqlCommand cmd = new SqlCommand(sql, sqlcon);
				cmd.ExecuteNonQuery();
				SqlDataReader dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					string name = (string)dr["FirstName_Emp"].ToString();
					txtEmp_Name.Text = name;
				}

			}
			catch (Exception)
			{
				MessageBox.Show("Error Connection emp. Please try again !", "ERROR");
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
		//------------------------------------------------------------------------------------
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
				sqlcon.Close();
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
			}
			catch (Exception)
			{
				MessageBox.Show("Error Connection cus. Please try again !", "ERROR");
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
		//-----------------------------------------------------------------------------------
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
			try
			{
				sqlcon.Close();
				sqlcon.Open();
				for (int i = 0; i <= combobShipper.Items.Count - 1; i++)
				{
					if (combobShipper.Text.Equals(combobShipper.GetItemText(combobShipper.Items[i].ToString())))
					{

						string sql = "SELECT Company FROM Shippers WHERE Company = N'" + combobShipper.Text + "'";
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

			}
			catch (Exception)
			{
				MessageBox.Show("Error Connection shipper. Please try again !", "ERROR");
			}
		}
		private void combobShipper_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(combobShipper.Text))
			{
				e.Cancel = true;
				combobShipper.Focus();
				errorProvider1.SetError(combobShipper, " Do not accept blank field !");
			}
			else
			{
				e.Cancel = false;
				errorProvider1.SetError(combobShipper, null);
			}
		}
		//-----------------------------------------------------------------------------------
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
			try
			{
				sqlcon.Close();
				sqlcon.Open();
				for (int i = 0; i <= combobPro_No.Items.Count - 1; i++)
				{
					if (combobPro_No.Text.Equals(combobPro_No.GetItemText(combobPro_No.Items[i].ToString())))
					{
						string sql = "SELECT ProductName, UnitPrice FROM Products WHERE ProductID = '" + combobPro_No.Text +"'";
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
			}
			catch (Exception)
			{
				MessageBox.Show("Error Connection product. Please try again !", "ERROR");
			}
		}
		private void combobPro_No_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(combobPro_No.Text))
			{
				e.Cancel = true;
				combobPro_No.Focus();
				errorProvider1.SetError(combobPro_No, " Do not accept blank field !");
			}
			else
			{
				e.Cancel = false;
				errorProvider1.SetError(combobPro_No, null);
			}
		}

		//---------------------------------------------------------------------------------

		// SUB TOTAL
		// Thay đổi số lượng thì tính lại SUB TOTAL
		private void txtPro_SoLuong_TextChanged(object sender, EventArgs e)
		{
			double total, quantity, price;
			if (txtPro_SoLuong.Text == "")
				quantity = 0;
			else
				quantity = Convert.ToDouble(txtPro_SoLuong.Text);
			if (txtPro_UnitPrice.Text == "")
				price = 0;
			else
				price = Convert.ToDouble(txtPro_UnitPrice.Text);
			total = quantity * price;
			txtTamTinh.Text = total.ToString();
		}
		// Thay đổi giá tiền thì tính lại SUBTOTAL
		private void txtPro_UnitPrice_TextChanged(object sender, EventArgs e)
		{
			double total, quantity, price;
			if (txtPro_SoLuong.Text == "")
				quantity = 0;
			else
				quantity = Convert.ToDouble(txtPro_SoLuong.Text);
			if (txtPro_UnitPrice.Text == "")
				price = 0;
			else
				price = Convert.ToDouble(txtPro_UnitPrice.Text);
			total = quantity * price;
			txtTamTinh.Text = total.ToString();
			

		}
		// TOTAL COST
		// Thay đổi disount thì tính lại TOTAL COST
		private void txtDiscount_TextChanged(object sender, EventArgs e)
		{
			double total=0, quantity, price, discount;
			string dis = txtDiscount.Text;
			if (txtPro_SoLuong.Text == "")
				quantity = 0;
			else
				quantity = Convert.ToDouble(txtPro_SoLuong.Text);
			if (txtPro_UnitPrice.Text == "")
				price = 0;
			else
				price = Convert.ToDouble(txtPro_UnitPrice.Text);
			foreach (ListViewItem i in listView1.Items)
			{
				total += double.Parse(i.SubItems[5].Text);
			}
			txtsum.Text = total.ToString();
			double.TryParse(dis, NumberStyles.Any, CultureInfo.CurrentCulture, out discount);
			txtTotalCost.Text = (total - total * (discount / 100)).ToString();
			Class_ChuyenSoThanhChu ch = new Class_ChuyenSoThanhChu();
			txtTotalInWord.Text = ch.changeToWords(txtTotalCost.Text).ToString();
		}
		private void txtTamTinh_TextChanged(object sender, EventArgs e)
		{
			double temp = double.Parse(txtTamTinh.Text.Replace(".", ""));
			txtTamTinh.Text = temp.ToString("0,0.#");
			txtTamTinh.Select(txtTamTinh.TextLength, 0);
		}
		private void txtsum_TextChanged(object sender, EventArgs e)
		{
			Class_ChuyenSoThanhChu ch = new Class_ChuyenSoThanhChu();
			txtTotalInWord.Text = ch.changeToWords(txtTotalCost.Text).ToString();
		}
		//-----------------------------------------------------------------------------------

		// Function - Add in to Listview
		public void AddListview()
		{
			int counter;
			string BillNo = txtBillNo.Text.ToUpper().Trim(); // Mã hóa đơn
			string quantity = txtPro_SoLuong.Text.Trim(); // số lượng sản phẩm
			//try
			//{
				// Kiểm tra Mã sản phẩm
				if (combobPro_No.SelectedValue != "")
				{
					// kiểm tra số lượng sản phẩm
					if (quantity != "")
					{
						// kiểm tra Mã hóa đơn rỗng
						if (BillNo != "")
						{
							for(counter = 1; counter <= listView1.Items.Count - 1; counter ++)
							{
								listView1.Items[counter].Text = (counter + 1).ToString();
								
							}
							string[] data = { counter.ToString(), combobPro_No.SelectedItem.ToString(), txtPro_Name.Text, quantity, txtPro_UnitPrice.Text, txtTamTinh.Text };
							ListViewItem item = new ListViewItem(data);
							listView1.Items.Add(item);
							double total = 0;
							string dis = txtDiscount.Text;
							double discount;
							foreach (ListViewItem i in listView1.Items)
							{
								total += double.Parse(i.SubItems[5].Text);
							}
							double.TryParse(dis, NumberStyles.Any, CultureInfo.CurrentCulture, out discount);
							txtsum.Text = total.ToString();
							txtTotalCost.Text = (total - total * (discount / 100)).ToString();
						}
						else
						{
							txtBillNo.Focus();
							errorProvider1.SetError(txtBillNo, "Do not accept blank field !");
						}
					}
					else
					{
						txtPro_SoLuong.Focus();
						errorProvider1.SetError(txtPro_SoLuong, "Do not accept blank field !");
					}
				}
				else
				{
					combobPro_No.Focus();
					errorProvider1.SetError(combobPro_No, " Product ID does not exist !");
				}

			//}
			//catch
			//{
				//MessageBox.Show("Error connection. Pplease try again !");
			//}
		}

		// btn Thêm sản phẩm vào listview
		private void btnThem_Click(object sender, EventArgs e)
		{
			CheckNullTextbox();
			AddListview();
		}
		// btn Out
		private void btnOut_Click(object sender, EventArgs e)
		{
			Frm_Main_Admin admin = new Frm_Main_Admin();
			admin.Show();
			this.Hide();
			Visible = false;
		}
		
	}
}
