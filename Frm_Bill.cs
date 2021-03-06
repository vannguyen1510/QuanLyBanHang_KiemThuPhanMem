﻿using System;
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
        //SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-LFN81CO\MINHLINH;Initial Catalog=KTPM;Integrated Security=True");
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
		public Frm_Bill(String id) : this()
		{
			label26.Text = id;
		}
		private void Frm_Bill_Load(object sender, EventArgs e)
		{
			Collumn_Load();
			Load_combobPro_No();
			Load_combobShipper();
			Load_combobCus_ID();
			Load_combobEmp_ID();
			sqlcon.Close();

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
		private void txtDiscount_Leave(object sender, EventArgs e)
		{
			if (txtDiscount.Text == "")
			{
				txtDiscount.Text = "0";
			}
			if (txtDiscount.Text == "0")
			{
				txtDiscount.Text = "0";
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
		// XÓA CONTROLS
		public void XoaFullTextbox()
		{
			foreach (Control ct in this.Controls)
			{
				if (ct is TextBox)
				{
					ct.Text = string.Empty;
					dateTimePicker1.Value = DateTime.Today;
				}
				txtBillNo.Text = "";
				txtDiscount.Text = "";
				txtPro_SoLuong.Text = "";
			}
		}
		public void XoaFullCombobox()
		{
			foreach (Control cb in this.Controls)
			{
				if (cb is ComboBox)
				{
					cb.Text = string.Empty;
				}
			}
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
						string sql = "SELECT ProductName, UnitPrice FROM Products WHERE ProductID = '" + combobPro_No.Text + "'";
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
			{
				quantity = 0;
			}
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
		// TOTAL 
		// Thay đổi sub total thì tính lại TOTAL
		public void Total()
		{
			double total = 0;
			foreach (ListViewItem i in listView1.Items)
			{
				total += double.Parse(i.SubItems[5].Text);
			}
		}
		// TOTAL COST
		// Thay đổi disount thì tính lại TOTAL COST
		private void txtDiscount_TextChanged(object sender, EventArgs e)
		{
			double total = 0, quantity, price, discount;
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
		// Thay đổi total và Discount thì tính lại TOTAL COST
		private void txtsum_TextChanged(object sender, EventArgs e)
		{
			Total();
			double total = 0, quantity, price, discount;
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

        //-----------------------------------------------------------------------------------

        // Function - Add into Listview
        public static bool ADDbill = true;
        public void AddListview()
        {
            int counter = 0;
            string BillNo = txtBillNo.Text.ToUpper().Trim(); // Mã hóa đơn
            string quantity = txtPro_SoLuong.Text.Trim(); // số lượng sản phẩm
			double subtotal = 0;
            try
            {
                // Kiểm tra Mã sản phẩm
                if ((string)combobPro_No.SelectedValue != "")
                {
					ListViewItem item1 = listView1.FindItemWithText(combobPro_No.Text); // tìm kiếm mã trùng
					if (item1 != null) // nếu mã co trong listview thì cộng dồn số lượng sản phẩm
					{
						foreach (ListViewItem im in listView1.Items)
						{
							subtotal += double.Parse(item1.SubItems[3].Text);
							subtotal = Convert.ToDouble(im.SubItems[3].Text);
						}

					}
					else // nếu mã không trùng
					{
						// kiểm tra số lượng sản phẩm
						if (quantity != "")
						{
							// kiểm tra Mã hóa đơn rỗng
							if (BillNo != null)
							{
								for (counter = 0; counter < listView1.Items.Count; counter++)
								{
									listView1.Items[counter].Text = (counter + 1).ToString();

								}
								string[] data = {(counter + 1).ToString() ,
												combobPro_No.SelectedItem.ToString(),
												txtPro_Name.Text, quantity,
												txtPro_UnitPrice.Text,
												txtTamTinh.Text };
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
								ADDbill = false;
								txtBillNo.Focus();
								errorProvider1.SetError(txtBillNo, "Do not accept blank field !");
							}
						}
						else if (quantity == "0")
						{
							ADDbill = false;
							txtPro_SoLuong.Focus();
							errorProvider1.SetError(txtPro_SoLuong, "Do not accept value 0 !");
						}
						else
						{
							ADDbill = false;
							txtPro_SoLuong.Focus();
							errorProvider1.SetError(txtPro_SoLuong, "Do not accept blank field !");
						}
					}
                }
                else
                {
                    ADDbill = false;
                    combobPro_No.Focus();
                    errorProvider1.SetError(combobPro_No, " Product ID does not exist !");
                }

            }
            catch
            {
                MessageBox.Show("Error connection. Pplease try again !");
            }
        }

        // btn Thêm sản phẩm vào listview
        private void btnThem_Click(object sender, EventArgs e)
		{
			CheckNullTextbox();
			AddListview();
		}

		//------------------------------------------------------------------------------------ 
		// Function - Update product in Listview
		public void UpdateListView()
		{
			ListViewItem item1 = listView1.FindItemWithText(combobPro_No.Text); // tìm Mã trùng với mã trong combobox Pro_ID
			if (item1 != null) // nếu Mã có trong Listview thì sửa
			{
				ListViewItem item2 = new ListViewItem();
				item2 = this.listView1.SelectedItems[0];
				item2.SubItems[0].Text = item1.SubItems[0].Text;
				item2.SubItems[1].Text = combobPro_No.SelectedItem.ToString();
				item2.SubItems[2].Text = txtPro_Name.Text;
				item2.SubItems[3].Text = txtPro_SoLuong.Text;
				item2.SubItems[4].Text = txtPro_UnitPrice.Text;
				item2.SubItems[5].Text = txtTamTinh.Text;
			}
			else // Nếu không có 
			{
				DialogResult dlr = MessageBox.Show("Code " + combobPro_No.Text + " does not exist in bill! Do you want to add new ?", "HELP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dlr == DialogResult.Yes)
				{
					AddListview();
				}
				else
				{
					combobPro_No.Text = string.Empty;
					txtPro_Name.Text = string.Empty;
					txtPro_SoLuong.Text = string.Empty;
					txtPro_UnitPrice.Text = string.Empty;
					txtTamTinh.Text = string.Empty;
				}
			}
		}

		// btn Sửa sản phẩm trong listview
		private void btnSua_Click(object sender, EventArgs e)
		{
			UpdateListView();
		}
		//------------------------------------------------------------------------------------
		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			foreach (ListViewItem item in listView1.SelectedItems)
			{
				int x;
				x = combobPro_No.FindString(item.SubItems[1].Text);
				combobPro_No.SelectedIndex = x;
				txtPro_Name.Text = item.SubItems[2].Text;
				txtPro_SoLuong.Text = item.SubItems[3].Text;
				txtPro_UnitPrice.Text = item.SubItems[4].Text;
				txtTamTinh.Text = item.SubItems[5].Text;
			}
		}
        //---------------------------------------------------------------------------------
        // Function - Add bill into Database
        public static bool ADDData = true;
        public void AddDatabase()
        {
            string BillNo = txtBillNo.Text.ToUpper().Trim(); // Mã hóa đơn
            string quantity = txtPro_SoLuong.Text.Trim(); // số lượng sản phẩm
            string odate = dateTimePicker1.Text;
            try
            {
                // Kiểm tra Mã sản phẩm
                if ((string)combobPro_No.SelectedValue != "")
                {
                    // kiểm tra số lượng sản phẩm
                    if (quantity != "" || quantity == "0")
                    {
                        // kiểm tra Mã hóa đơn rỗng
                        if (BillNo != null)
                        {
                            // THÊM VÀO DATABASE
                            try
                            {
                                // Kiểm tra Mã khách và Mã NV 
                                sqlcon.Close();
                                sqlcon.Open();
                                string e = combobEmp_ID.Text;
                                string cu = combobCus_ID.Text;
                                string ph = txtCus_Phone.Text;
                                string check = "SELECT COUNT (*) FROM [KTPM].[dbo].[Info_Emp] WHERE ID_Emp = @em";
                                string check1 = "SELECT COUNT (*) FROM [KTPM].[dbo].[Info_Cus] WHERE ID_Cus = @cus AND Phone_Cus = @phone";
                                SqlCommand c = new SqlCommand(check, sqlcon);
                                c.Parameters.AddWithValue("@em", e);
                                int x = Convert.ToInt32(c.ExecuteScalar());
                                if (x > 0)
                                {
                                    SqlCommand u = new SqlCommand(check1, sqlcon);
                                    u.Parameters.AddWithValue("@cus", cu);
                                    u.Parameters.AddWithValue("@phone", ph);
                                    int y = Convert.ToInt32(u.ExecuteScalar());
                                    if (y > 0)
                                    {
                                        // THÊM VÀO Order
                                        try
                                        {
                                            sqlcon.Close();
                                            sqlcon.Open();
                                            string sql = "INSERT INTO [KTPM].[dbo].[Orders] (OrderID,ID_Cus,ID_Emp,OrderDate,ShipVia,Name_Cus,Address_Cus)"
                                                            + "VALUES (@od,@cd,@ed,@date,@ship,@cn,@address)";
                                            //+ "WHERE(ID_Cus IN(SELECT Phone_Cus FROM[KTPM].[dbo].Info_Cus)) AND(ID_Emp IN(SELECT ID_Emp FROM[KTPM].[dbo].Info_Emp))";
                                            SqlCommand cmd = new SqlCommand(sql, sqlcon);
                                            cmd.Parameters.AddWithValue("@od", BillNo);
                                            cmd.Parameters.AddWithValue("@cd", txtCus_Phone.Text);
                                            cmd.Parameters.AddWithValue("@ed", combobEmp_ID.Text);
                                            cmd.Parameters.AddWithValue("@date", odate);
                                            cmd.Parameters.AddWithValue("@ship", combobShipper.Text);
                                            cmd.Parameters.AddWithValue("@cn", txtCus_Name.Text);
                                            cmd.Parameters.AddWithValue("@address", txtCus_Address.Text);
                                            cmd.ExecuteNonQuery();
                                            sqlcon.Close();
                                        }
                                        catch (Exception)
                                        {
                                            ADDData = false;
                                            MessageBox.Show("Error connection /Order/. Please try again !");
                                            sqlcon.Close();
                                        }
                                        // THÊM VÀO Order Details
                                        sqlcon.Close();
                                        sqlcon.Open();
                                        foreach (ListViewItem item1 in listView1.Items)
                                        {
                                            string sql_od = "INSERT INTO [KTPM].[dbo].[Order Details] (OrderID,ProductID,UnitPrice,Quantity,Discount)"
                                                        + "VALUES ('"
                                                        + txtBillNo.Text + "','"
                                                        + item1.SubItems[1].Text + "','"
                                                        + item1.SubItems[4].Text + "','"
                                                        + item1.SubItems[3].Text + "','"
                                                        + txtDiscount.Text + "');";
                                            SqlCommand cmd_od = new SqlCommand(sql_od, sqlcon);
                                            cmd_od.ExecuteNonQuery();
                                        }
                                        MessageBox.Show(" DATA ADDED SUCCESSFUL !");
                                        XoaFullTextbox();
                                        sqlcon.Close();
                                    }
                                    else
                                    {
                                        ADDData = false;
                                        MessageBox.Show("Employee ID does not exist !");
                                    }
                                }
                                else
                                {
                                    ADDData = false;
                                    MessageBox.Show("Customer ID does not exist !");
                                }
                            }
                            catch (Exception)
                            {
                                ADDData = false;
                                MessageBox.Show("Error connection /SQL/. Please try again !");
                                sqlcon.Close();
                            }
                            // TÍNH TIỀN
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
                            ADDData = false;
                            txtBillNo.Focus();
                            errorProvider1.SetError(txtBillNo, "Do not accept blank field !");
                        }
                    }
                    else if (quantity == "0")
                    {
                        ADDData = false;
                        txtPro_SoLuong.Focus();
                        errorProvider1.SetError(txtPro_SoLuong, "Do not accept value 0 !");
                    }
                    else
                    {
                        ADDData = false;
                        txtPro_SoLuong.Focus();
                        errorProvider1.SetError(txtPro_SoLuong, "Do not accept blank field !");
                    }
                }
                else
                {
                    ADDData = false;
                    combobPro_No.Focus();
                    errorProvider1.SetError(combobPro_No, " Product ID does not exist !");
                }
            }
            catch
            {
                ADDData = false;
                MessageBox.Show("Error connection. Please try again !");
            }
        }
        // btn Thêm vào CSDL
        private void btnAdd_Bill_Click(object sender, EventArgs e)
		{
			CheckNullTextbox();
			AddDatabase();
		}


		//--------------------------------------------------------------------------------
		// btn Out
		private void btnOut_Click(object sender, EventArgs e)
		{
			Frm_SignIn sin = new Frm_SignIn();
			sin.Show();
			this.Hide();
			Visible = false;
		}

		//-------------------------------------------------------------------------------
		// btn Reset
		private void btn_Reset_Click(object sender, EventArgs e)
		{
			XoaFullTextbox();
			XoaFullCombobox();
			for(int i =0; i<listView1.Items.Count;i++)
			{
				listView1.Items[i].Remove();
				i--;
			}
			Collumn_Load();
		}
		//------------------------------------------------------------------------------
		// btn Menu
		private void btnMenu_Click(object sender, EventArgs e)
		{
			Frm_Main_Admin admin = new Frm_Main_Admin(label26.Text);
			admin.Show();
			this.Hide();
			Visible = false;
		}
		//-------------------------------------------------------------------------------
		public void del()
		{
			int counter = 0;
			//string maxoa;
			//double subtotal, quantity, total;
			if (listView1.Items.Count == 0) // trong Listview không có dữ liệu 
			{
				MessageBox.Show("No data to delete \n Please try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			else
			{
				foreach (ListViewItem im in listView1.SelectedItems)
				{
					im.Remove();
					for (counter = 0; counter < listView1.Items.Count; counter++)
					{
						listView1.Items[counter].Text = (counter + 1).ToString();
					}
					ListViewItem item3 = new ListViewItem();
					item3 = this.listView1.SelectedItems[0];
					item3.SubItems[0].Text = (counter + 1).ToString();
				}
				
			}
		}
		// Double click delete data in listview
		private void listView1_DoubleClick(object sender, EventArgs e)
		{
			del();
		}

		private void btnPrint_Bill_Click(object sender, EventArgs e)
		{
			
		}

		private void txtTotalInWord_TextChanged(object sender, EventArgs e)
		{

		}

		private void txtTotalCost_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
