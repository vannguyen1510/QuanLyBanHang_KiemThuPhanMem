using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Collections;
using System.Globalization;
using System.Configuration;

namespace QLBH_KiemThuPhanMem
{
	public partial class Frm_List_Cus_Emp : Form
	{
		string gender = string.Empty;
        // ĐƯỜNG DẪN SQL
        SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-LFN81CO\MINHLINH;Initial Catalog=KTPM;Integrated Security=True");
        //SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
        ///SqlConnection sqlcon = new SqlConnection("Data Source= VAN;Initial Catalog=KTPM;Integrated Security=True");
		//SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["QLBH_KiemThuPhanMem.Properties.Settings.KTPMConnectionString"].ToString());

		public Frm_List_Cus_Emp()
		{
			InitializeComponent();
			//WaterMark
			this.txtTimKiem.Leave += new System.EventHandler(this.txtTimKiem_Leave);
			this.txtTimKiem.Enter += new System.EventHandler(this.txtTimKiem_Enter);
			this.txtTimKiem_KH.Leave += new System.EventHandler(this.txtTimKiem_KH_Leave);
			this.txtTimKiem_KH.Enter += new System.EventHandler(this.txtTimKiem_KH_Enter);
		}
		public Frm_List_Cus_Emp(String id) : this()
		{
			label14.Text = id;
		}
		// Open tab Employee
		//protected override void OnShown(EventArgs e)
		//{
		//    base.OnShown(e);
		//    Frm_Main_Admin admin = new Frm_Main_Admin();
		//    admin.OnOpenTab_Emp += admin_OnOpenTab_Emp;
		//    admin.ShowDialog(this);
		//}
		//void admin_OnOpenTab_Emp(Object sender, EventArgs e)
		//{
		//    tabControl_Emp.SelectedTab = tabPage_Emp;
		//}

		private void txtTimKiem_Leave(object sender, EventArgs e)
		{
			if (txtTimKiem.Text == "")
			{
				txtTimKiem.Text = "ENTER ID (EX: NV01)";
				txtTimKiem.ForeColor = Color.LightGray;
			}
		}
		private void txtTimKiem_Enter(object sender, EventArgs e)
		{
			if (txtTimKiem.Text == "ENTER ID (EX: NV01)")
			{
				txtTimKiem.Text = "";
				txtTimKiem.ForeColor = Color.Black;
			}
		}
		private void txtTimKiem_KH_Leave(object sender, EventArgs e)
		{
			if (txtTimKiem_KH.Text == "")
			{
				txtTimKiem_KH.Text = "ENTER ID (EX: NV01)";
				txtTimKiem_KH.ForeColor = Color.LightGray;
			}
		}
		private void txtTimKiem_KH_Enter(object sender, EventArgs e)
		{
			if (txtTimKiem_KH.Text == "ENTER ID (EX: NV01)")
			{
				txtTimKiem_KH.Text = "";
				txtTimKiem_KH.ForeColor = Color.Black;
			}
		}

		// LOAD CỘT LISTVIEW
		public void Collumn_Load()
		{
			listView1.View = View.Details;
			listView1.Columns.Add("ID", 100, HorizontalAlignment.Center);
			listView1.Columns.Add("First Name", 120, HorizontalAlignment.Center);
			listView1.Columns.Add("Last Name", 120, HorizontalAlignment.Center);
			listView1.Columns.Add("Birthday", 100, HorizontalAlignment.Center);
			listView1.Columns.Add("Gender", 80, HorizontalAlignment.Center);
			timer1.Enabled = true;
			this.Opacity = 1;
			dataLoad();
		}
		public void Collumn_Load_KH()
		{
			listView2.View = View.Details;
			listView2.Columns.Add("ID", 70, HorizontalAlignment.Center);
			listView2.Columns.Add("First Name", 100, HorizontalAlignment.Center);
			listView2.Columns.Add("Last Name", 100, HorizontalAlignment.Center);
			listView2.Columns.Add("Phone", 100, HorizontalAlignment.Center);
			listView2.Columns.Add("Birthday", 100, HorizontalAlignment.Center);
			listView2.Columns.Add("Gender", 80, HorizontalAlignment.Center);
			timer1.Enabled = true;
			this.Opacity = 1;
			dataLoad_KH();
		}
		private void Frm_List_Cus_Emp_Load(object sender, EventArgs e)
		{
			Collumn_Load();
			Collumn_Load_KH();
		}

		// TẢI DỮ LIỆU LÊN LISTVIEW
		private void dataLoad()
		{
			CloseConnect();
			OpenConnect();
			String sql = "Select * From [KTPM].[dbo].[Info_Emp] ";
			SqlCommand cmd = new SqlCommand(sql, sqlcon);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			//Tải dữ liệu lên ListView
			int i = 0;
			foreach (DataRow dr in dt.Rows)
			{
				listView1.Items.Add(dr["ID_Emp"].ToString());
				listView1.Items[i].SubItems.Add(dr["FirstName_Emp"].ToString());
				listView1.Items[i].SubItems.Add(dr["LastName_Emp"].ToString());
				listView1.Items[i].SubItems.Add(dr["Birtday_Emp"].ToString());
				listView1.Items[i].SubItems.Add(dr["Sex_Emp"].ToString());
				i++;
			}
			listView1.View = View.Details;
			
		}
		private void dataLoad_KH()
		{
			OpenConnect();
			String sql = "Select * From [KTPM].[dbo].[Info_Cus] ";
			SqlCommand cmd = new SqlCommand(sql, sqlcon);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			//Tải dữ liệu lên ListView
			int i = 0;
			foreach (DataRow dr in dt.Rows)
			{
				listView2.Items.Add(dr["ID_Cus"].ToString());
				listView2.Items[i].SubItems.Add(dr["FirstName_Cus"].ToString());
				listView2.Items[i].SubItems.Add(dr["LastName_Cus"].ToString());
				listView2.Items[i].SubItems.Add(dr["Phone_Cus"].ToString());
				listView2.Items[i].SubItems.Add(dr["Birthday_Cus"].ToString());
				listView2.Items[i].SubItems.Add(dr["Sex_Cus"].ToString());
				i++;
			}
			listView2.View = View.Details;
		}

		// TẢI LẠI DỮ LIỆU
		private void btnTaiLai_Click(object sender, EventArgs e)
		{
			listView1.Clear();
			Collumn_Load();
			lbXuatTenDangNhap.Text = string.Empty;
		}
		private void btnTaiLai_KH_Click(object sender, EventArgs e)
		{
			listView2.Clear();
			Collumn_Load_KH();
			lbXuatTenDangNhap_KH.Text = string.Empty;
		}

		// BỎ TRỐNG textbox
		// Form Employee
		public void CheckNullTextBox()
		{
			if (txtMa.Text == "")
			{
				errorProvider1.SetError(txtMa, "Do not accept blank field !");
			}
			if (txtHo.Text == "")
			{
				errorProvider1.SetError(txtHo, "Do not accept blank field !");
			}
			if (txtTen.Text == "")
			{
				errorProvider1.SetError(txtTen, "Do not accept blank field !");
			}
		}
		private void txtMa_TextChanged(object sender, EventArgs e)
		{
			errorProvider1.SetError(txtMa, "");
		}
		private void txtHo_TextChanged(object sender, EventArgs e)
		{
			errorProvider1.SetError(txtHo, "");
		}
		private void txtTen_TextChanged(object sender, EventArgs e)
		{
			errorProvider1.SetError(txtTen, "");
		}
		// Form Customer
		public void CheckNullTextBox_KH()
		{
			if (txtMa_KH.Text == "")
			{
				errorProvider2.SetError(txtMa_KH, "Do not accept blank field !");
			}
			if (txtHo_KH.Text == "")
			{
				errorProvider2.SetError(txtHo_KH, "Do not accept blank field !");
			}
			if (txtTen_KH.Text == "")
			{
				errorProvider2.SetError(txtTen_KH, "Do not accept blank field !");
			}
			if (txtSDT_KH.Text == "")
			{
				errorProvider2.SetError(txtTen_KH, "Do not accept blank field !");
			}
		}

		private void txtMa_KH_TextChanged(object sender, EventArgs e)
		{
			errorProvider2.SetError(txtMa_KH, "");
		}
		private void txtTen_KH_TextChanged(object sender, EventArgs e)
		{
			errorProvider2.SetError(txtTen_KH, "");
		}
		private void txtHo_KH_TextChanged(object sender, EventArgs e)
		{
			errorProvider2.SetError(txtHo_KH, "");
		}
		private void txtSDT_KH_TextChanged(object sender, EventArgs e)
		{
			errorProvider2.SetError(txtSDT_KH, "");
		}


		// Xóa trắng Textbox + DateTimePicker + RadioButton
		public void XoaFullTextbox()
		{
			foreach (Control ct in this.Controls)
			{
				if (ct is TextBox)
				{
					ct.Text = string.Empty;
					dateTimePicker1.Value = DateTime.Today;
					rdbNam.Checked = true;
				}
			}
		}
		public void XoaFullTextbox_KH()
		{
			foreach (Control ct in this.Controls)
			{
				if (ct is TextBox)
				{
					ct.Text = string.Empty;
					dateTimePicker2.Value = DateTime.Today;
					rdbNam_KH.Checked = true;
				}
			}
		}

		// Không nhận ký tự đặc biệt
		private void txtMa_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (((e.KeyChar > (char)47) && (e.KeyChar < (char)58) // 0-9
				|| (e.KeyChar > (char)64) && (e.KeyChar < (char)91) // A - Z
				|| (e.KeyChar > (char)96) && (e.KeyChar < (char)123)) // a- z
				|| (e.KeyChar == (char)8)) // backspace
			{
				txtMa.ShortcutsEnabled = false;
				e.Handled = false;
			}
			else
			{
				MessageBox.Show("Accept only numbers and letters!");
				e.Handled = true;
			}
		}
		private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (((e.KeyChar > (char)47) && (e.KeyChar < (char)58) // 0-9
				|| (e.KeyChar > (char)64) && (e.KeyChar < (char)91) // A - Z
				|| (e.KeyChar > (char)96) && (e.KeyChar < (char)123)) // a - z
				|| (e.KeyChar == (char)8)) // backspace
			{
				txtTimKiem.ShortcutsEnabled = false;
				e.Handled = false;
			}
			else
			{
				MessageBox.Show("Accept only numbers and letters!");
				e.Handled = true;
			}
		}
		private void txtMa_KH_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (((e.KeyChar > (char)47) && (e.KeyChar < (char)58) // 0-9
				|| (e.KeyChar > (char)64) && (e.KeyChar < (char)91) // A - Z
				|| (e.KeyChar > (char)96) && (e.KeyChar < (char)123)) // a- z
				|| (e.KeyChar == (char)8)) // backspace
			{
				txtMa_KH.ShortcutsEnabled = false;
				e.Handled = false;
			}
			else
			{
				MessageBox.Show("Accept only numbers and letters!");
				e.Handled = true;
			}
		}
		private void txtTimKiem_KH_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (((e.KeyChar > (char)47) && (e.KeyChar < (char)58) // 0-9
				|| (e.KeyChar > (char)64) && (e.KeyChar < (char)91) // A - Z
				|| (e.KeyChar > (char)96) && (e.KeyChar < (char)123)) // a - z
				|| (e.KeyChar == (char)8)) // backspace
			{
				txtTimKiem_KH.ShortcutsEnabled = false;
				e.Handled = false;
			}
			else
			{
				MessageBox.Show("Accept only numbers and letters!");
				e.Handled = true;
			}
		}

		// Chỉ nhận ký tự số
		private void txtSDT_KH_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar > (char)47) && (e.KeyChar < (char)58) // 0-9
				|| (e.KeyChar == (char)8)) // backspace
			{
				txtSDT_KH.ShortcutsEnabled = false;
				e.Handled = false;
			}
			else
			{
				MessageBox.Show("Accept only numbers!");
				e.Handled = true;
			}
		}

		// Chỉ nhận ký tự chữ
		private void txtHo_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(Char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
			string Ho = txtHo.Text.Trim();
			while (Ho.IndexOf("  ") != -1)
			{
				Ho = Ho.Replace("  ", " ");
			}
		}
		private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(Char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
			string Ten = txtTen.Text.Trim();
			while (Ten.IndexOf("  ") != -1)
			{
				Ten = Ten.Replace("  ", " ");
			}
		}
		private void txtTen_KH_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(Char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
			string Ten = txtTen_KH.Text.Trim();
			while (Ten.IndexOf("  ") != -1)
			{
				Ten = Ten.Replace("  ", " ");
			}
		}
		private void txtHo_KH_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(Char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
			string Ho = txtHo_KH.Text.Trim();
			while (Ho.IndexOf("  ") != -1)
			{
				Ho = Ho.Replace("  ", " ");
			}
		}

		// Hiển thị  MaNV lên textbox
		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			foreach (ListViewItem item in listView1.SelectedItems)
			{
				txtTimKiem.ForeColor = Color.Black;
				txtTimKiem.Text = item.SubItems[0].Text;
			}
		}
		private void listView2_SelectedIndexChanged(object sender, EventArgs e)
		{
			foreach (ListViewItem item in listView2.SelectedItems)
			{
				txtTimKiem_KH.ForeColor = Color.Black;
				txtTimKiem_KH.Text = item.SubItems[0].Text;
			}
		}

        // Function - Thêm mới 
        public static bool themFlag = true;
        public void AddNew()
        {
            string ma = txtMa.Text.ToUpper().Trim();
            string ho = txtHo.Text.Trim();
            while (ho.IndexOf("  ") != -1)
            {
                ho = ho.Replace("  ", " ");
            }
            string ten = (txtTen.Text).Trim();
            while (ten.IndexOf("  ") != -1)
            {
                ten = ten.Replace("  ", " ");
            }
            string ns = dateTimePicker1.Text;
            string gt = rdbNam.Checked ? "Male" : "Female";
            string[] data = { ma, ho, ten, ns, gt };
            if (ma != "")
            {
                if (ho != "")
                {
                    if (ten != "")
                    {
                        ListViewItem item1 = listView1.FindItemWithText(txtMa.Text); // tìm Mã trùng với txtMa
                        if (item1 == null) // nếu Mã chưa có trong Listview thì thêm mới
                        {
                            // Thêm vào listview
                            ListViewItem item = new ListViewItem(data);
                            listView1.Items.Add(item);
                            item.ImageIndex = rdbNam.Checked ? 0 : 1;
                            // Thêm vào SQL
                            try
                            {
                                if (rdbNam.Checked)
                                    gender = "Male";
                                else
                                    gender = "Female";
                                string sql = "INSERT INTO [KTPM].[dbo].[Info_Emp] (ID_Emp,FirstName_Emp,LastName_Emp,Birtday_Emp,Sex_Emp)"
                                                + "VALUES (@ma,@ho,@ten,@ngaysinh,@gt)";
                                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                                cmd.Parameters.AddWithValue("@ma", ma);
                                cmd.Parameters.AddWithValue("@ho", ho);
                                cmd.Parameters.AddWithValue("@ten", ten);
                                cmd.Parameters.AddWithValue("@ngaysinh", ns);
                                cmd.Parameters.AddWithValue("@gt", gender);
                                cmd.ExecuteNonQuery(); // kết quả trả về là số dòng bị ảnh hưởng
                                lbXuatTenDangNhap.Text = " DATA ADDED SUCCESSFUL !";
                                XoaFullTextbox();
                                themFlag = true;
                                CloseConnect();
                            }
                            catch (Exception)
                            {
                                themFlag = false;

                                lbXuatTenDangNhap.Text = "Error connection. Please try again!";
                            }
                            finally
                            {
                                CloseConnect();
                            }
                        }
                        else
                        {
                            themFlag = false;

                            lbXuatTenDangNhap.Text = " ID Employee is already exist ! Please try again.";
                            txtMa.Text = string.Empty;
                        }
                    }
                    else
                    {
                        themFlag = false;

                        lbXuatTenDangNhap.Text = string.Empty;
                        errorProvider1.SetError(txtTen, " Do not accept blank field !");
                    }
                }
                else
                {
                    themFlag = false;

                    lbXuatTenDangNhap.Text = string.Empty;
                    errorProvider1.SetError(txtHo, "Do not accept blank field !");
                }
            }
            else
            {
                themFlag = false;
                lbXuatTenDangNhap.Text = string.Empty;
                errorProvider1.SetError(txtMa, "Do not accept blank field !");
            }

        }
        // test


        ///// -----------------------------------
        //public void AddNew_KH()
        //{
        //	string ma = txtMa_KH.Text.ToUpper().Trim();
        //	string ho = txtHo_KH.Text.Trim();
        //	while (ho.IndexOf("  ") != -1)
        //	{
        //		ho = ho.Replace("  ", " ");
        //	}
        //	string ten = txtTen_KH.Text.Trim();
        //	while (ten.IndexOf("  ") != -1)
        //	{
        //		ten = ten.Replace("  ", " ");
        //	}
        //	string sdt = txtSDT_KH.Text;
        //	string ns = dateTimePicker2.Text;
        //	string gt = rdbNam_KH.Checked ? "Male" : "Female";
        //	string[] data_2 = { ma, ho, ten, sdt, ns, gt };
        //	if (ma != "")
        //	{
        //		if (ho != "")
        //		{
        //			if (ten != "")
        //			{
        //				if (sdt != "")
        //				{
        //					ListViewItem item2 = listView1.FindItemWithText(txtMa_KH.Text); // tìm Mã trùng với txtMa_KH
        //					if (item2 == null) // nếu Mã chưa có trong Listview thì thêm mới
        //					{
        //						// Thêm vào listview
        //						ListViewItem item_2 = new ListViewItem(data_2);
        //						listView2.Items.Add(item_2);
        //						// Thêm vào SQL
        //						try
        //						{
        //							if (rdbNam.Checked)
        //								gender = "Male";
        //							else
        //								gender = "Female";
        //							string sql = "INSERT INTO [KTPM].[dbo].[Info_Cus] (ID_Cus,FirstName_Cus,LastName_Cus,Phone_Cus,Birthday_Cus,Sex_Cus)"
        //											+ "VALUES (@ma,@ho,@ten,@dt,@ngaysinh,@gt)";
        //							SqlCommand cmd = new SqlCommand(sql, sqlcon);
        //							cmd.Parameters.AddWithValue("@ma", ma);
        //							cmd.Parameters.AddWithValue("@ho", ho);
        //							cmd.Parameters.AddWithValue("@ten", ten);
        //							cmd.Parameters.AddWithValue("@dt", sdt);
        //							cmd.Parameters.AddWithValue("@ngaysinh", ns);
        //							cmd.Parameters.AddWithValue("@gt", gender);
        //							cmd.ExecuteNonQuery(); // kết quả trả về là số dòng bị ảnh hưởng
        //							lbXuatTenDangNhap_KH.Text = " DATA ADDED SUCCESSFUL !";
        //							XoaFullTextbox();
        //							CloseConnect();
        //						}
        //						catch (Exception)
        //						{
        //							lbXuatTenDangNhap_KH.Text = "Error connection. Please try again!";
        //						}
        //						finally
        //						{
        //							CloseConnect();
        //						}
        //					}
        //					else
        //					{
        //						lbXuatTenDangNhap_KH.Text = " ID Customer is already exist ! Please try again.";
        //						txtMa_KH.Text = string.Empty;
        //					}
        //				}
        //				else
        //				{
        //					lbXuatTenDangNhap_KH.Text = string.Empty;
        //					errorProvider2.SetError(txtSDT_KH, " Do not accept blank field !");
        //				}
        //			}
        //			else
        //			{
        //				lbXuatTenDangNhap_KH.Text = string.Empty;
        //				errorProvider2.SetError(txtTen_KH, " Do not accept blank field !");
        //			}
        //		}
        //		else
        //		{
        //			lbXuatTenDangNhap_KH.Text = string.Empty;
        //			errorProvider2.SetError(txtHo_KH, "Do not accept blank field !");
        //		}
        //	}
        //	else
        //	{
        //		lbXuatTenDangNhap_KH.Text = string.Empty;
        //		errorProvider2.SetError(txtMa_KH, "Do not accept blank field !");
        //	}
        //}
        /// -----------------------------------

        // btn THÊM
        private void btnThem_Click(object sender, EventArgs e)
		{
			OpenConnect();
			// Bỏ trống textbox
			CheckNullTextBox();
			// Thêm mới
			AddNew();
		}

        // btn SỬA		
        public static bool suaFlag = true;
        public void UpDate()
        {
            ListViewItem item1 = listView1.FindItemWithText(txtMa.Text); // tìm Mã trùng với txtMa
            if (item1 != null) // nếu Mã có trong Listview thì sửa
            {
                if (rdbNam.Checked)
                    gender = "Male";
                else
                    gender = "Female";
                try
                {
                    suaFlag = true;
                    OpenConnect();
                    string sql = "UPDATE [KTPM].[dbo].[Info_Emp]"
                                + "SET LastName_Emp='" + txtHo.Text + "', FirstName_Emp='" + txtTen.Text + "', Birtday_Emp='" + dateTimePicker1.Text + "', Sex_Emp='" + gender + "'"
                                + "WHERE ID_Emp='" + txtMa.Text + "'";
                    SqlCommand cmdSua = new SqlCommand(sql, sqlcon);
                    SqlDataAdapter dap = new SqlDataAdapter(cmdSua);
                    DataTable dt = new DataTable();
                    dap.Fill(dt);
                    cmdSua.ExecuteNonQuery();
                    lbXuatTenDangNhap.Text = " DATA UPDATE SUCCESSFUL !";
                    CloseConnect();
                }
                catch (Exception)
                {
                    suaFlag = false;
                    lbXuatTenDangNhap.Text = " DATA UPDATE FAIL !";
                }
                finally
                {
                    CloseConnect();
                }
            }
            else
            {
                suaFlag = false;
                DialogResult dlr = MessageBox.Show("Code " + txtMa.Text + " does not exist in database! Do you want to add new ?", "HELP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    OpenConnect();
                    AddNew();
                    CloseConnect();
                }
                else
                {
                    suaFlag = false;
                    XoaFullTextbox();
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            UpDate();
        }

        public bool Update1(string LastName_Emp, string FirstName_Emp, string Birtday_Emp, string Sex_Emp, string ID_Emp)
        {
            bool tamp = true;
            //ListViewItem item1 = listView1.FindItemWithText(txtMa.Text); // tìm Mã trùng với txtMa
            if (ID_Emp != null) // nếu Mã có trong Listview thì sửa
            {
                if (rdbNam.Checked)
                    gender = "Male";
                else
                    gender = "Female";
                try
                {
                    //MessageBox.Show("Inside Try_" + ID_Emp);
                    OpenConnect();
                    string sql = "UPDATE [KTPM].[dbo].[Info_Emp]"
                                + "SET LastName_Emp='" + LastName_Emp + "', FirstName_Emp='" + FirstName_Emp + "', Birtday_Emp='" + Birtday_Emp + "', Sex_Emp='" + Sex_Emp + "'"
                                + "WHERE ID_Emp='" + ID_Emp + "'";
                    SqlCommand cmdSua = new SqlCommand(sql, sqlcon);
                    SqlDataAdapter dap = new SqlDataAdapter(cmdSua);
                    DataTable dt = new DataTable();
                    dap.Fill(dt);
                    cmdSua.ExecuteNonQuery();
                    lbXuatTenDangNhap.Text = " DATA UPDATE SUCCESSFUL !";
                    CloseConnect();
                }
                catch (Exception)
                {
                    //MessageBox.Show("Inside Catch");
                    tamp = false;
                    lbXuatTenDangNhap.Text = " DATA UPDATE FAIL !";
                }
                finally
                {
                    CloseConnect();
                }
            }
            else
            {

                DialogResult dlr = MessageBox.Show("Code " + txtMa.Text + " does not exist in database! Do you want to add new ?", "HELP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    OpenConnect();
                    AddNew();
                    CloseConnect();
                }
                else // xóa trắng textbox
                {
                    tamp = false;
                    XoaFullTextbox();
                }

            }
            //MessageBox.Show("Tam: "+tamp);
            return tamp;
        }
        // Function - Xoa

        public static bool DelFlag = true;
        public void Del()
        {
            lbXuatTenDangNhap.Text = string.Empty;
            string ma = txtTimKiem.Text;
            //try
            //{
            CloseConnect();
            OpenConnect();
            // Xóa trong SQL
            string sql = "DELETE FROM [KTPM].[dbo].[Info_Emp] WHERE ID_Emp= '" + ma + "';";
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            SqlDataReader myReader;
            string sql_detail = "DELETE FROM [KTPM].[dbo].[Info_Secret] WHERE ID_Emp= '" + ma + "';";
            SqlCommand cmd_detail = new SqlCommand(sql_detail, sqlcon);
            SqlDataReader myReader_detail;

            string sqlMa = "SELECT COUNT (*) FROM [KTPM].[dbo].[Info_Emp] WHERE ID_Emp= '" + ma + "';";
            SqlCommand cmdMa = new SqlCommand(sqlMa, sqlcon);
            int x = (int)cmdMa.ExecuteScalar(); // Tồn tại mã NV trong Bảng Info_Emp	
            string sqlorder = "SELECT COUNT (*) FROM [KTPM].[dbo].[Orders] WHERE ID_Emp= '" + ma + "';";
            SqlCommand cmdorder = new SqlCommand(sqlorder, sqlcon);
            int y = (int)cmdorder.ExecuteScalar(); // Tồn tại mã NV trong bảng Orders
            string secret = "SELECT COUNT (*) FROM [KTPM].[dbo].[Orders] WHERE ID_Emp= '" + ma + "';";
            SqlCommand cmdsecret = new SqlCommand(secret, sqlcon);
            int z = (int)cmdsecret.ExecuteScalar(); // Tồn tại mã NV trong bảng Info_Secret
            if (x == 1)
            {
                if (y == 1)
                {
                    if (z == 1)
                    {
                        //if (listView1.Items.Count <= 0)
                        //	return;
                        //for (int i = 0; i < listView1.Items.Count; i++)
                        //{
                        //	if (txtTimKiem.Text == listView1.Items[i].SubItems[0].Text)
                        //		MessageBox.Show("You can not delete yourself", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //	else
                        //		MessageBox.Show("This employee have already exist in Database \n Can not delete information !", "SORRY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}
                        if (txtTimKiem.Text == label14.Text)
                        {
                            DelFlag = true;
                            MessageBox.Show("You can not delete yourself", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        else
                        {
                            DelFlag = true;
                            MessageBox.Show("This employee have already exist in Database \n Can not delete information !", "SORRY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else // không tồn tại mã NV trong bảng Secret thì không cho xóa và yêu cầu đăng ký tài khoản 
                    {
                        DelFlag = true;
                        MessageBox.Show("You have no permission \n Please sign up to countinue ! ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Frm_SignIn sin = new Frm_SignIn();
                        sin.Show();
                        this.Hide();
                    }
                }
                else // nếu mã NV không tồn tại trong bảng Orders
                {
                    if (z == 1) // tồn tại trong bảng Secret thì XÓA sạch tại bảng Emp và Secret
                    {
                        foreach (ListViewItem item in listView1.SelectedItems)
                        {
                            listView1.Items.Remove(item);
                            myReader = cmd.ExecuteReader();
                            while (myReader.Read()) { }
                            myReader_detail = cmd_detail.ExecuteReader();
                            while (myReader_detail.Read()) { }
                            lbXuatTenDangNhap.Text = " DELETE SUCCESSFUL " + ma;
                            ma = string.Empty;
                        }
                    }
                    else // XÓA sạch tại bảng Emp
                    {
                        foreach (ListViewItem item in listView1.SelectedItems)
                        {
                            listView1.Items.Remove(item);
                            myReader = cmd.ExecuteReader();
                            while (myReader.Read()) { }
                            lbXuatTenDangNhap.Text = " DELETE SUCCESSFUL " + ma;
                            ma = string.Empty;
                        }
                    }
                }
            }
            else // không tồn tại mã NV trong bảng NV
            {
                DelFlag = false;
                MessageBox.Show(" This ID does not exist! \n Please try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //}
            //catch (Exception)
            //{
            //	lbXuatTenDangNhap.Text = " DELETE " + ma + " FAIL ! ";
            //}
            //finally
            //{
            //	CloseConnect();
            //}
        }
        public void Del_KH()
		{
			lbXuatTenDangNhap_KH.Text = string.Empty;
			string ma = txtTimKiem_KH.Text;
			try
			{
				CloseConnect(); 
				OpenConnect();
				// Xóa trong SQL
				string sql = "DELETE FROM [KTPM].[dbo].[Info_Cus] WHERE ID_Cus= '" + ma + "';";
				SqlCommand cmd = new SqlCommand(sql, sqlcon);
				SqlDataReader myReader;
				string sqlMa = "SELECT COUNT (*) FROM [KTPM].[dbo].[Info_Cus] WHERE ID_Cus=@ma";
				SqlCommand cmdMa = new SqlCommand(sqlMa, sqlcon);
				cmdMa.Parameters.Add(new SqlParameter("@ma", ma));
				int x = (int)cmdMa.ExecuteScalar(); // kết quả trả về là 1 giá trị			
				if (x == 1)
				{
					// Xóa trong ListView
					foreach (ListViewItem item_2 in listView2.SelectedItems)
					{
						listView2.Items.Remove(item_2);
						myReader = cmd.ExecuteReader(); // kết quả trả về là 1 tập các dòng
						while (myReader.Read())
						{ }
						lbXuatTenDangNhap_KH.Text = " DELETE SUCCESSFUL " + ma;
						ma = string.Empty;
					}
				}
				else
				{
					MessageBox.Show(" This ID does not exist! \n Please try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch (Exception)
			{
				lbXuatTenDangNhap_KH.Text = " DELETE " + ma + " FAIL ! ";
			}
			finally
			{
				CloseConnect();
			}
		}

		// btn XÓA
		private void btnXoa_Click(object sender, EventArgs e)
		{
			Del();
		}
		private void btnXoa_KH_Click(object sender, EventArgs e)
		{
			Del_KH();
		}

        // Function - Tìm kiếm 
        public static bool TiemKiemFlag = true;
        public void Find()
        {
            string maTimKiem = txtTimKiem.Text.Trim().ToUpper();
            while (maTimKiem.IndexOf("  ") != -1)
            {
                maTimKiem = maTimKiem.Replace("  ", "");
            }
            if (maTimKiem != null) // Textbox không bỏ trống
            {
                ListViewItem item2 = listView1.FindItemWithText(maTimKiem); // tìm Mã trùng với txtTimKiem
                if (item2 == null) // Mã không có trong Listview 
                {
                    TiemKiemFlag = false;
                    lbXuatTenDangNhap.Text = "ID " + maTimKiem + " does not exist !";
                    maTimKiem = string.Empty;
                }
                else // Mã có trong Listview 
                {
                    string temp1 = maTimKiem;
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        if (temp1 == listView1.Items[i].SubItems[0].Text)
                        {
                            lbXuatTenDangNhap.Text = "ID " + temp1 + " is available!";
                            maTimKiem = string.Empty;
                            txtMa.Text = listView1.Items[i].SubItems[0].Text;
                            txtHo.Text = listView1.Items[i].SubItems[1].Text;
                            txtTen.Text = listView1.Items[i].SubItems[2].Text;
                            // hiển thị Date trong listView lên DateTimePicker
                            DateTime time = DateTime.ParseExact(listView1.Items[i].SubItems[3].Text, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                            dateTimePicker1.Value = time;
                            // hiển thị giới tính trong listview lên RadioButton
                            string gd = listView1.Items[i].SubItems[4].Text.ToString();
                            if (gd.Trim() == "Male")
                                rdbNam.Checked = true;
                            else
                                rdbNu.Checked = true;
                        }
                        //else
                        //{
                        //	lbXuatTenDangNhap.Text = "Mã " + temp1 + " không tồn tại !";
                        //	maTimKiem = string.Empty;
                        //}
                    }
                }
            }
            else
            {
                TiemKiemFlag = false;
                errorProvider1.SetError(txtTimKiem, "Please enter ID Employee first !");
            }
        }
        public void Find_KH() // chua chay duoc
		{
			string maTimKiem = txtTimKiem_KH.Text.Trim().ToUpper();
			while (maTimKiem.IndexOf("  ") != -1)
			{
				maTimKiem = maTimKiem.Replace("  ", "");
			}
			if (maTimKiem != null) // Textbox không bỏ trống
			{
				ListViewItem item_2 = listView2.FindItemWithText(maTimKiem); // tìm Mã trùng với txtTimKiem
				if (item_2 == null) // Mã không có trong Listview 
				{
					lbXuatTenDangNhap_KH.Text = "ID " + maTimKiem + " does not exist !";
					maTimKiem = string.Empty;
				}
				else // Mã có trong Listview 
				{
					string temp2 = maTimKiem;
					for (int i = 0; i < listView2.Items.Count; i++)
					{
						if (temp2 == listView2.Items[i].SubItems[0].Text)
						{
							lbXuatTenDangNhap_KH.Text = "ID " + temp2 + " is available!";
							maTimKiem = string.Empty;
							txtMa_KH.Text = listView2.Items[i].SubItems[0].Text;
							txtHo_KH.Text = listView2.Items[i].SubItems[1].Text;
							txtTen_KH.Text = listView2.Items[i].SubItems[2].Text;
							txtSDT_KH.Text = listView2.Items[i].SubItems[3].Text;
							// hiển thị Date trong listView lên DateTimePicker
							DateTime time = DateTime.ParseExact(listView2.Items[i].SubItems[4].Text, @"dd/MM/yyyy", CultureInfo.InvariantCulture);
							dateTimePicker2.Value = time;
							// hiển thị giới tính trong listview lên RadioButton
							string gd = listView2.Items[i].SubItems[5].Text.ToString();
							if (gd.Trim() == "Male")
								rdbNam_KH.Checked = true;
							else
								rdbNu_KH.Checked = true;
						}
					}
				}
			}
			else
			{
				errorProvider2.SetError(txtTimKiem_KH, "Please enter ID Employee first !");
			}
		}

		// btn TÌM KIẾM
		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			if(txtTimKiem.Text == "ENTER ID (VD: NV01)")
			{
				errorProvider1.SetError(txtTimKiem, "Please enter ID Employee first !");
			}
			else 
			{
				Find();
			}		
		}
		private void btnTimKiem_KH_Click(object sender, EventArgs e)
		{
			if (txtTimKiem_KH.Text == "ENTER ID (VD: NV01)")
			{
				errorProvider2.SetError(txtTimKiem_KH, "Please enter ID Employee first !");
			}
			else
			{
				Find_KH();
			}
		}

		// btn CLEAR
		
		private void btnClear_KH_Click(object sender, EventArgs e)
		{
			XoaFullTextbox_KH();
		}


		// ĐÓNG FORM
		private void Frm_List_Cus_Emp_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult = MessageBox.Show("Do you really wanna exit?", ":(", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
			if (DialogResult == DialogResult.OK)
			{
				Application.Exit();
			}
		}

		// ĐÓNG MỞ KẾT NỐI SQL
		private void OpenConnect()
		{
			if (sqlcon.State == ConnectionState.Closed)
				sqlcon.Open();
		}
		private void CloseConnect()
		{
			if (sqlcon.State == ConnectionState.Open)
				sqlcon.Close();
		}

		// SỰ KIỆN PHÍM
		protected override bool ProcessDialogKey(Keys keyData)
		{
			switch (keyData)
			{
				case Keys.A: // Thêm mới
					{
						CheckNullTextBox();
						AddNew();
						break;
					}
				case Keys.U: // Sửa
					{
						break;
					}
				case Keys.Delete: // Xóa
					{
						Del();
						break;
					}
				case Keys.F: // Tìm kiếm
					{
						Find();
						break;
					}
				case Keys.C: // Clear
					{
						XoaFullTextbox();
						break;
					}
			}
			return base.ProcessDialogKey(keyData);
		}


		private void btnThoat_Click(object sender, EventArgs e)
		{
			this.Hide();
			Frm_Main_Admin Ad = new Frm_Main_Admin(label14.Text);
			Ad.Show();
		}

		private void btnOut_Click(object sender, EventArgs e)
		{
			this.Hide();
			Frm_SignIn sin = new Frm_SignIn();
			sin.Show();
		}

		private void ClearTextBoxes()
		{
			Action<Control.ControlCollection> func = null;

			func = (controls) =>
			{
				foreach (Control control in controls)
					if (control is TextBox)
						(control as TextBox).Clear();
					else
						func(control.Controls);
			};

			func(Controls);
		}
		private void btnClear_Click(object sender, EventArgs e)
		{
			ClearTextBoxes();
		}
	}
}
