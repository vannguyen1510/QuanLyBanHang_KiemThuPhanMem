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
	public partial class Frm_SignIn : Form
	{
		SqlConnection sqlcon = new SqlConnection(@"Data Source=VAN;Initial Catalog=QLBH;Integrated Security=True");

		public Frm_SignIn()
		{
			InitializeComponent();
			//string connectionString = ConfigurationManager.ConnectionStrings["Data Source=VAN;Initial Catalog=QLBH;Integrated Security=True"].ConnectionString;
		}
		//-------------------------------------------------------------------------------------------------------------
		// kiểm tra form ForgotPassword và ChangePassword đã mở hay chưa 
		private bool CheckExistFrm_ForgotPassword (string name)
		{
			bool check = false;
			foreach(Form Frm_ForgotPassword in this.MdiChildren)
			{
				if(Frm_ForgotPassword.Name == name)
				{
					check = true;
					break;
				}
			}
			return check;
		}
		private bool CheckExistFrm_ChangePassword (string name)
		{
			bool check = false;
			foreach(Form Frm_ChangePassword in this.MdiChildren)
			{
				if(Frm_ChangePassword.Name == name)
				{
					check = true;
					break;
				}
			}
			return check;
		}

		// kích hoạt form ForgotPassword và ChangePassword hiển thị lên trên cùng - KHÔNG PHẢI TẠO MỚI FORM CON
		private void ActiveChildFrm_ForgotPassword (string name)
		{
			foreach(Form Frm_ForgotPassword in this.MdiChildren)
			{
				if(Frm_ForgotPassword.Name == name)
				{
					Frm_ForgotPassword.Activate();
					break;
				}
			}
		}
		private void ActiveChildFrm_ChangePassword(string name)
		{
			foreach(Form Frm_ChangePassword in this.MdiChildren)
			{
				if(Frm_ChangePassword.Name == name)
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
		private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar > (char)47) && (e.KeyChar < (char)58) // 0-9
				|| (e.KeyChar == (char)8)) // backspace
			{
				txtPhone.ShortcutsEnabled = false;
				e.Handled = false;
			}
			else
			{
				errorProvider1.SetError(txtPhone, "Accept only numbers!");
				e.Handled = true;
			}
		}

		// ẨN HIỆN PASSWORD
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
				txtMatKhau.UseSystemPasswordChar = true;
			else
				txtMatKhau.UseSystemPasswordChar = false;
		}

		//-----------------------------------------------------------------------------------------------
		// ĐĂNG NHẬP - SIGN IN
		public void DangNhap()
		{
			try
			{
				sqlcon.Open();
				string user = txtTenDangNhap.Text;
				string pass = txtMatKhau.Text;
				// Dò tìm SĐT khách hàng và ID nhân viên
				string sql = "SELECT COUNT (*) FROM [QLBH].[dbo].[Info_Secret] WHERE (Phone_Cus=@phone AND Password=@pass) OR (ID_Emp=@id AND Password=@pass)";
				SqlCommand cmd = new SqlCommand(sql, sqlcon);
				cmd.Parameters.Add(new SqlParameter("@phone", user));
				cmd.Parameters.Add(new SqlParameter("@id", user));
				cmd.Parameters.Add(new SqlParameter("@pass", pass));
				int x = (int)cmd.ExecuteScalar();
				if (x == 1)
				{
					string sql_Permision = "SELECT COUNT (*) FROM [QLBH].[dbo].[Info_Secret] WHERE Phone_Cus=@phone AND Permision=@per";
					SqlCommand cmd_Permision = new SqlCommand(sql_Permision, sqlcon);
					cmd_Permision.Parameters.Add(new SqlParameter("@phone", user));
					cmd_Permision.Parameters.AddWithValue("@per","Guess");
					int y = (int)cmd_Permision.ExecuteScalar();
					if (y == 1)
					{
						this.Hide();
						Frm_Main_Customers cus = new Frm_Main_Customers();
						cus.Show();
					}
					else
					{
						this.Hide();
						Frm_List_Cus_Emp f = new Frm_List_Cus_Emp();
						f.Show();
					}
				}
				else
				{
					MessageBox.Show(" User or Password is incorrect . \n Please try again!", "ERROR");
				}
			}
			catch (Exception)
			{
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
		public void DoiPW()
		{
			try
			{
				sqlcon.Open();
				string id = txtTenDangNhap.Text.ToUpper().Trim();
				if (id != null) // Textbox không bỏ trống
				{
					string sql = "Select Count(*) From [QLBH].[dbo].[Info_SignIn] Where ID_Sin=@id ";
					SqlCommand cmd = new SqlCommand(sql, sqlcon);
					cmd.Parameters.Add(new SqlParameter("@id", id));
					int x = (int)cmd.ExecuteScalar();
					if (x == 1) // đúng id thì mới mở form đổi mật khẩu
					{
							Frm_ChangePassword change = new Frm_ChangePassword(txtTenDangNhap.Text);
							change.Show();
					}
					else
					{
						MessageBox.Show("Thông tin đăng nhập không đúng. \n Vui lòng nhập lại!", "ERROR");
					}
				}
				else
				{
					if (txtTenDangNhap.Text == "")
					{
						errorProvider1.SetError(txtTenDangNhap, "Bạn chưa nhập ID !");
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Lỗi kết nối!", "Try Again");
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
			Frm_ForgotPassword forgot = new Frm_ForgotPassword();
			forgot.Show();
		}

		//-----------------------------------------------------------------------------------------------
		// ĐĂNG KÝ - SIGN UP
		public void DangKy()
		{
			string F = txtFName.Text.Trim();
			string L = txtLName.Text.Trim();
			string P = txtPhone.Text.Trim();
			string pw = txtPw.Text;
			string cpw = txtCPw.Text;
			string A = txtAddress.Text.Trim();
			// Không cho phép để trống textbox nào
			if (F != "")
			{
				if (L != "")
				{
					if (P != "")
					{
						try
						{
							// vào SQL kiểm tra SĐT 
							sqlcon.Open();
							string sql = "SELECT COUNT (*) FROM [QLBH].[dbo].[Info_Cus] Where Phone_Cus=@sdt";
							SqlCommand cmd = new SqlCommand(sql, sqlcon);
							cmd.Parameters.Add(new SqlParameter("@sdt", P));
							int x = (int)cmd.ExecuteScalar();
							if (x == 1) // nếu SĐT trùng thì báo lỗi 
							{
								errorProvider1.SetError(txtPhone, " Phone number is already existed. Please try again!");
								P = string.Empty;
							}
							else // nếu SĐT không trùng thì kiểm tra tiếp MẬT KHẨU
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
												errorProvider1.SetError(txtPw, "Password must be at least 6 characters and no more than 8 !"); // [6,8]
												txtPw.Text = string.Empty;
												txtCPw.Text = string.Empty;
											}
											// Chiều dài hợp lệ thì kiểm tra ký tự bên trong
											else
											{
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
														countDB++;
													}
													i++;
												}
												// Ít nhất: 1 chữ Hoa +1 chữ Thường + 1 Số + 1 Ký tự đặc biệt
												if (countThuong >= 1 && countHoa >= 1 && countSo >= 1 && countDB >= 1 && (pw.Length >= 6 || pw.Length <= 8))
												{
													// nếu hợp lệ + txtCpw không trống và trùng với PW thì báo ĐĂNG KÝ thành công
													if (pw != "" && cpw != "" && String.Compare(cpw, pw, false) == 0)
													{
														string id_pw = "INSERT INTO [QLBH].[dbo].[Info_Secret] (Phone_Cus,Password,Permision)"
																		+ " VALUES (@phone, @pass, @per)";
														SqlCommand cmd_id_pw = new SqlCommand(id_pw, sqlcon);
														cmd_id_pw.Parameters.Add(new SqlParameter("@phone", P));
														cmd_id_pw.Parameters.Add(new SqlParameter("@pass", cpw));
														cmd_id_pw.Parameters.AddWithValue("@per", "Guess");
														cmd_id_pw.ExecuteNonQuery(); // kết quả trả về là số dòng bị ảnh hưởng
														MessageBox.Show(" WELCOME " + L + " " + P + " !");
														tabPage_SignIn.Show();
														txtTenDangNhap.Text = txtPhone.Text;
													}
													else
													{
														errorProvider1.SetError(txtCPw, "You need to confirm excactly!");
														cpw = string.Empty;
													}
												}
												else
												{
													errorProvider1.SetError(txtCPw, "Please enter the password and confirm password!");
												}
											}
										}
										catch (Exception)
										{
											MessageBox.Show("Error Connection Password!", "Please Try Again");
										}
										finally
										{
											sqlcon.Close();
										}
									}
									else
									{
										errorProvider1.SetError(txtCPw, "Confirm your Password please !");
									}
								}
								else
								{
									errorProvider1.SetError(txtPw, "Enter your Password please !");
								}

							}
						}
						catch (Exception)
						{
							MessageBox.Show("Error Connection Phone!", "Try Again");
						}
						finally
						{
							sqlcon.Close();
						}
					}
					else
					{
						errorProvider1.SetError(txtPhone, "Enter your Phone please !");
					}
				}
				else
				{
					errorProvider1.SetError(txtLName, "Enter your Last Name please !");
				}
			}
			else
			{
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
			}
			return base.ProcessDialogKey(keyData);
		}

		
	}
}
