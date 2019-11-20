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
using System.Security.Cryptography;

namespace QLBH_KiemThuPhanMem
{
	public partial class Frm_SignIn : Form
	{
		SqlConnection sqlcon = new SqlConnection(@"Data Source=VAN;Initial Catalog=KTPM;Integrated Security=True");
		//SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-LFN81CO\MINHLINH;Initial Catalog=KTPM;Integrated Security=True");
		//SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["QLBH_KiemThuPhanMem.Properties.Settings.KTPMConnectionString"].ToString());
		MD5 md = MD5.Create();
        public Frm_SignIn()
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------------------------------------------
		// kiểm tra form ForgotPassword và ChangePassword đã mở hay chưa 
		private bool CheckExistFrm_ForgotPassword(string name)
		{
			bool check = false;
			foreach (Form Frm_ForgotPassword in this.MdiChildren)
			{
				if (Frm_ForgotPassword.Name == name)
				{
					check = true;
					break;
				}
			}
			return check;
		}
		private bool CheckExistFrm_ChangePassword(string name)
		{
			bool check = false;
			foreach (Form Frm_ChangePassword in this.MdiChildren)
			{
				if (Frm_ChangePassword.Name == name)
				{
					check = true;
					break;
				}
			}
			return check;
		}

		// kích hoạt form ForgotPassword và ChangePassword hiển thị lên trên cùng - KHÔNG PHẢI TẠO MỚI FORM CON
		private void ActiveChildFrm_ForgotPassword(string name)
		{
			foreach (Form Frm_ForgotPassword in this.MdiChildren)
			{
				if (Frm_ForgotPassword.Name == name)
				{
					Frm_ForgotPassword.Activate();
					break;
				}
			}
		}
		private void ActiveChildFrm_ChangePassword(string name)
		{
			foreach (Form Frm_ChangePassword in this.MdiChildren)
			{
				if (Frm_ChangePassword.Name == name)
				{
					Frm_ChangePassword.Activate();
					break;
				}
			}
		}

		

		//-------------------------------------------------------------------------------------------------------------

		// LOAD FORM
		private void Frm_SignIn_Load(object sender, EventArgs e)
		{
			this.IsMdiContainer = true;
			// Làm trong suốt Nút quên MK
			btnForgotPW.TabStop = false;
			btnForgotPW.FlatStyle = FlatStyle.Flat;
			btnForgotPW.FlatAppearance.BorderSize = 0;
			btnForgotPW.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
		}

		// Chỉ nhận ký tự chữ
		private void txtFName_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(Char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
			string Ten = txtFName.Text.Trim();
			while (Ten.IndexOf("  ") != -1)
			{
				Ten = Ten.Replace("  ", " ");
			}
		}
		private void txtLName_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(Char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
			string Ho = txtLName.Text.Trim();
			while (Ho.IndexOf("  ") != -1)
			{
				Ho = Ho.Replace("  ", " ");
			}
		}

		// Chỉ nhận ký tự số
		//private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
		//{
		//	if ((e.KeyChar > (char)47) && (e.KeyChar < (char)58) // 0-9
		//		|| (e.KeyChar == (char)8)) // backspace
		//	{
		//		txtPhone.ShortcutsEnabled = false;
		//		e.Handled = false;
		//	}
		//	else
		//	{
		//		errorProvider1.SetError(txtPhone, "Accept only numbers!");
		//		e.Handled = true;
		//	}
		//}

		// ẨN HIỆN PASSWORD
		private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
				txtMatKhau.UseSystemPasswordChar = false;
			else
				txtMatKhau.UseSystemPasswordChar = true;

		}
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked)
				txtPw.UseSystemPasswordChar = true;
			else
				txtPw.UseSystemPasswordChar = false;
		}
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox3.Checked)
				txtCPw.UseSystemPasswordChar = true;
			else
				txtCPw.UseSystemPasswordChar = false;
		}

        //-----------------------------------------------------------------------------------------------
        // ĐĂNG NHẬP - SIGN IN
        public static bool LoginFlag = true;
        public void DangNhap()
        {
            try
            {
                sqlcon.Open();
                string user = txtTenDangNhap.Text;
                string pass = txtMatKhau.Text;

				// Mã hóa mật khẩu 
				string str = "";
				Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(pass);
				MD5CryptoServiceProvider md = new MD5CryptoServiceProvider();
				buffer = md.ComputeHash(buffer);
				foreach (Byte b in buffer)
				{
					str += b.ToString("X2");
				}
				// Dò tìm SĐT khách hàng và ID nhân viên
				string sql = "SELECT COUNT (*) FROM [KTPM].[dbo].[Info_Secret] WHERE (Phone_Cus=@phone COLLATE SQL_Latin1_General_CP1_CS_AS AND Password=@pass COLLATE SQL_Latin1_General_CP1_CS_AS) OR (ID_Emp=@id COLLATE SQL_Latin1_General_CP1_CS_AS AND Password=@pass COLLATE SQL_Latin1_General_CP1_CS_AS)";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                cmd.Parameters.Add(new SqlParameter("@phone", user));
                cmd.Parameters.Add(new SqlParameter("@id", user));
                cmd.Parameters.Add(new SqlParameter("@pass", str));
                int x = (int)cmd.ExecuteScalar();
                if (x == 1)
                {
                    string sql_Permision = "SELECT COUNT (*) FROM [KTPM].[dbo].[Info_Secret] WHERE Phone_Cus=@phone AND Permision=@per";
                    SqlCommand cmd_Permision = new SqlCommand(sql_Permision, sqlcon);
                    cmd_Permision.Parameters.Add(new SqlParameter("@phone", user));
                    cmd_Permision.Parameters.AddWithValue("@per", "Guess");
                    int y = (int)cmd_Permision.ExecuteScalar();
                    if (y == 1)
                    {
                        LoginFlag = true;
                        this.Hide();
                        Frm_Main_Customers cus = new Frm_Main_Customers();
                        cus.Show();
                    }
                    else
                    {
                        LoginFlag = true;
                        this.Hide();
                        Frm_Main_Admin admin = new Frm_Main_Admin(txtTenDangNhap.Text);
                        admin.Show();
                    }
                }
                else
                {
                    LoginFlag = false;
                    MessageBox.Show(" User or Password is incorrect . \n Please try again!", "ERROR");
                }
            }
            catch (Exception)
            {
                LoginFlag = false;
                MessageBox.Show("Error Connection!", "Try Again");
            }
            finally
            {
                sqlcon.Close();
            }

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
		{
			DangNhap();
		}

        // ĐỔI MẬT KHẨU - CHANGE PASSWORD
        public static bool PassFlag = true;
        public void DoiPW()
        {
            try
            {
                sqlcon.Open();
                string id = txtTenDangNhap.Text.ToUpper().Trim();
                if (id != null) // Textbox không bỏ trống
                {
                    string sql = "Select Count(*) From [KTPM].[dbo].[Info_Secret] Where ID_Emp=@id COLLATE SQL_Latin1_General_CP1_CS_AS";
                    SqlCommand cmd = new SqlCommand(sql, sqlcon);
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    int x = (int)cmd.ExecuteScalar();
                    if (x == 1) // đúng id thì mới mở form đổi mật khẩu
                    {
                        this.Hide();
                        Frm_ChangePassword change = new Frm_ChangePassword(txtTenDangNhap.Text);
                        change.Show();
                    }
                    else
                    {
                        PassFlag = false;
                        MessageBox.Show("Wrong log in information. \n Please try again!", "ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else
                {
                    PassFlag = false;
                    errorProvider1.SetError(txtTenDangNhap, "Do not accept blank fields !");
                }
            }
            catch (Exception)
            {
                PassFlag = false;
                MessageBox.Show("Error connection!", "Try Again");
            }
            finally
            {
                sqlcon.Close();
            }
        }
        private void btnDoipw_Click(object sender, EventArgs e)
		{
			DoiPW();
		}

		// QUÊN MẬT KHẨU - FORGOT PASSWORD
		private void btnForgotPW_Click(object sender, EventArgs e)
		{
			this.Hide();
			Frm_ForgotPassword forgot = new Frm_ForgotPassword(txtTenDangNhap.Text);
			forgot.Show();
		}

		//-----------------------------------------------------------------------------------------------
		string gender = string.Empty;
        // ĐĂNG KÝ - SIGN UP
        public static bool DKFlag = true;
        public void DangKy()
        {
            sqlcon.Close();
            sqlcon.Open();
			string I = txtID.Text.Trim();
            string F = txtFName.Text.Trim();
            while (F.IndexOf("  ") != -1)
                F = F.Replace("  ", " ");
            string L = txtLName.Text.Trim();
            while (L.IndexOf("  ") != -1)
                L = L.Replace("  ", " ");
            //string P = txtPhone.Text.Trim();
            string pw = txtPw.Text;
            string cpw = txtCPw.Text;
            //string A = txtAddress.Text.Trim();
            string ns = dateTimePicker1.Text;
            string gt = rdbNam.Checked ? "Male" : "Female";
            string[] data = {I, F, L, ns, gt };
            // Không cho phép để trống textbox nào
            if (F != "")
            {
                if (L != "")
                {
                    if (I != "")
                    {
						try
						{
							// vào SQL kiểm tra ID_Emp
							string sql = "SELECT COUNT (*) FROM [KTPM].[dbo].[Info_Emp] Where ID_Emp=@id COLLATE SQL_Latin1_General_CP1_CS_AS";
                            SqlCommand cmd = new SqlCommand(sql, sqlcon);
                            cmd.Parameters.Add(new SqlParameter("@id", I));
                            int x = (int)cmd.ExecuteScalar();
                            if (x == 1) // nếu SĐT trùng thì báo lỗi 
                            {
                                DKFlag = false;
                                errorProvider1.SetError(txtID, " ID is already existed. Please try again!");
                                I = string.Empty;
                            }
                            else // nếu ID không trùng thì kiểm tra tiếp MẬT KHẨU
                            {
                                if (pw != "")
                                {
                                    if (cpw != "")
                                    {
										try
										{
											int countSo = 0;
                                            int countHoa = 0;
                                            int countThuong = 0;
                                            int countDB = 0;
                                            int i = 0;
                                            // Kiểm soát chiều dài PW
                                            if (pw.Length < 6 || pw.Length > 8)
                                            {
                                                DKFlag = false;
                                                errorProvider1.SetError(txtPw, "Password must be at least 6 characters and no more than 8 !"); // [6,8]
                                                txtPw.Text = string.Empty;
                                                txtCPw.Text = string.Empty;
                                            }
                                            // Chiều dài hợp lệ thì kiểm tra ký tự bên trong
                                            else
                                            {
                                                string pattern = @"^[ \s]+|[ \s]+$ ";
                                                while (i < pw.Length)
                                                {
                                                    if (pw[i] >= 'a' && pw[i] <= 'z')
                                                    {
                                                        countThuong++;
                                                    }
                                                    else if (pw[i] >= 'A' && pw[i] <= 'Z')
                                                    {
                                                        countHoa++;
                                                    }
                                                    else if (pw[i] >= '0' && pw[i] <= '9')
                                                    {
                                                        countSo++;
                                                    }
                                                    else
                                                    {
                                                        Regex checkWhitespace = new Regex(pattern);
                                                        if (checkWhitespace.IsMatch(pw))
                                                        {
                                                            DKFlag = false;
                                                            errorProvider1.SetError(txtPw, "Your password can't start or end with a blank space");
                                                            txtPw.Text = string.Empty;
                                                        }
                                                        if (checkWhitespace.IsMatch(cpw))
                                                        {
                                                            DKFlag = false;
                                                            errorProvider1.SetError(txtCPw, "Your password can't start or end with a blank space");
                                                            txtCPw.Text = string.Empty;
                                                        }
                                                        countDB++;
                                                    }
                                                    i++;
                                                }
                                                // Ít nhất: 1 chữ Hoa +1 chữ Thường + 1 Số + 1 Ký tự đặc biệt
                                                if (countThuong >= 1 && countHoa >= 1 && countSo >= 1 && countDB >= 1 && (pw.Length >= 6 && pw.Length <= 8))
                                                {
                                                    // nếu hợp lệ + txtCpw không trống và trùng với PW thì báo ĐĂNG KÝ thành công
                                                    if (pw != "" && cpw != "" && String.Compare(cpw, pw, false) == 0)
                                                    {
                                                        sqlcon.Close();
                                                        sqlcon.Open();
                                                        if (rdbNam.Checked)
                                                            gender = "Male";
                                                        else
                                                            gender = "Female";
													// Thêm vào bảng Info_Emp
													string sql_emp = "INSERT INTO [KTPM].[dbo].[Info_Emp] (ID_Emp,FirstName_Emp,LastName_Emp,Birtday_Emp,Sex_Emp)"
																	+"VALUES (@ide,@fe,@le,@be,@se)";
													SqlCommand cmd_emp = new SqlCommand(sql_emp, sqlcon);
													cmd_emp.Parameters.AddWithValue("@ide",I);
													cmd_emp.Parameters.AddWithValue("@fe", F);
													cmd_emp.Parameters.AddWithValue("@le", L);
													cmd_emp.Parameters.AddWithValue("@be", ns);
													cmd_emp.Parameters.AddWithValue("@se", gender);
													cmd_emp.ExecuteNonQuery();
                                                        // Thêm vào bảng Info_Secret
                                                        sqlcon.Close();
                                                        sqlcon.Open();
														string str = "";
														Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(cpw);
														MD5CryptoServiceProvider md = new MD5CryptoServiceProvider();
														buffer = md.ComputeHash(buffer);
														foreach (Byte b in buffer)
														{
															str += b.ToString("X2");
														}
														string id_pw = "INSERT INTO [KTPM].[dbo].[Info_Secret] (ID_Emp,Password,Permision)"
                                                                                + " VALUES (@ide,@pass,@per)";
                                                        SqlCommand cmd_id_pw = new SqlCommand(id_pw, sqlcon);
                                                        cmd_id_pw.Parameters.AddWithValue("@ide", I);
                                                        cmd_id_pw.Parameters.AddWithValue("@pass", str);
                                                        cmd_id_pw.Parameters.AddWithValue("@per", "Admin");
                                                        cmd_id_pw.ExecuteNonQuery();
                                                        DKFlag = true;
                                                        MessageBox.Show(" WELCOME " + F + " " + L + " !", "Hello", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        tabPage_SignIn.Show();
                                                    }
                                                    else
                                                    {
                                                        DKFlag = false;
                                                        errorProvider1.SetError(txtCPw, "You need to confirm excactly!");
                                                        cpw = string.Empty;
                                                    }
                                                }
                                                else
                                                {
                                                    DKFlag = false;
                                                    errorProvider1.SetError(txtPw, "Please read the password setting instructions!");
                                                }
                                            }
										}
										catch (Exception)
										{
											DKFlag = false;
											MessageBox.Show("Error Connection at Password!", "Please Try Again");
										}
										finally
										{
											sqlcon.Close();
										}
									}
                                    else
                                    {
                                        DKFlag = false;
                                        errorProvider1.SetError(txtCPw, "Confirm your Password please !");
                                    }
                                }
                                else
                                {
                                    DKFlag = false;
                                    errorProvider1.SetError(txtPw, "Enter your Password please !");
                                }
                            }
						}
						catch (Exception)
						{
							DKFlag = false;
							MessageBox.Show("Error Connection !", "Try Again");
						}
						finally
						{
							sqlcon.Close();
						}
					}
                    else
                    {
                        DKFlag = false;
                        errorProvider1.SetError(txtID, "Enter Employee ID please !");
                    }
                }
                else
                {
                    DKFlag = false;
                    errorProvider1.SetError(txtLName, "Enter your Last Name please !");
                }
            }
            else
            {
                DKFlag = false;
                errorProvider1.SetError(txtFName, "Enter your First Name please !");
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
		{
			DangKy();
		}

		//-------------------------------------------------------------------------------------------------
		// ĐÓNG FORM
		private void btnDong_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// BẮT PHÍM
		protected override bool ProcessDialogKey(Keys keyData)
		{
			switch (keyData)
			{
				case Keys.Enter:
					DangNhap();
					break;
				case Keys.Escape:
					this.Close();
					break;
				case Keys.P:
					{
						DoiPW();
						break;
					}
				case Keys.Y:
					DangKy();
					break;
			}
			return base.ProcessDialogKey(keyData);
		}

		private void txtFName_TextChanged(object sender, EventArgs e)
		{

		}

		private void tabPage_SignUp_Click(object sender, EventArgs e)
		{

		}
	}
}
