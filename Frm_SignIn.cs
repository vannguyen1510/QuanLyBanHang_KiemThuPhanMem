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

namespace QLBH_KiemThuPhanMem
{
	public partial class Frm_SignIn : Form
	{
		SqlConnection sqlcon = new SqlConnection(@"Data Source=VAN;Initial Catalog=QLBH;Integrated Security=True");

		public Frm_SignIn()
		{
			InitializeComponent();
			string connectionString = ConfigurationManager.ConnectionStrings["Data Source=VAN;Initial Catalog=QLBH;Integrated Security=True"].ConnectionString;
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

		// ẨN HIỆN PASSWORD
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
				txtMatKhau.UseSystemPasswordChar = true;
			else
				txtMatKhau.UseSystemPasswordChar = false;
		}

		// ĐĂNG NHẬP - SIGN IN
		public void DangNhap()
		{
			try
			{
				sqlcon.Open();
				string hoten = txtTenDangNhap.Text;
				string pass = txtMatKhau.Text;
				string sql = "Select Count(*) From [QLBH].[dbo].[Info_SignIn] Where ID_Sin=@id And Pass_Sin=@pass";
				SqlCommand cmd = new SqlCommand(sql, sqlcon);
				cmd.Parameters.Add(new SqlParameter("@id", hoten));
				cmd.Parameters.Add(new SqlParameter("@pass", pass));
				int x = (int)cmd.ExecuteScalar();
				if (x == 1)
				{
					this.Hide();
					Frm_List_Cus_Emp f = new Frm_List_Cus_Emp();
					f.Show();
				}
				else
				{
					MessageBox.Show("Thông tin đăng nhập không đúng. \n Vui lòng nhập lại!", "ERROR");
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

		// ĐÓNG FORM
		private void btnDong_Click(object sender, EventArgs e)
		{
			Application.Exit();
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

		// ĐĂNG KÝ - SIGN UP
		public void DangKy()
		{
			sqlcon.Open();
			string F = txtFName.Text;
			string L = txtLName.Text;
			string P = txtPhone.Text;
			string pw = txtPw.Text;
			string cpw = txtCPw.Text;
			string A = txtAddress.Text.Trim();
			// Không cho phép để trống textbox nào
			if(F != "")
			{
				if(L != "")
				{
					if(P != "")
					{
						if (pw != "")
						{
							if (cpw != "")
							{
								if (A != "")
								{
									// vào SQL kiểm tra SĐT 
										// nếu SĐT trùng thì báo lỗi + VÔ HIỆU HÓA nút ĐĂNG KÝ
										// nếu SĐT không trùng thì kiểm tra tiếp MẬT KHẨU
											// Kiểm soát chiều dài PW 6-8
												// nếu sai quy định (PW < 6 || PW > 8) thì VÔ HIỆU HÓA nút ĐĂNG KÝ
												// nếu hợp lệ thì kiểm tra ký tự bên trong
													// Ít nhất: 1 chữ Hoa + 1 chữ Thường + 1 Số + 1 Ký tự đặc biệt
														// nếu hợp lệ + txtCpw không trống và trùng với PW thì báo ĐĂNG KÝ thành công 
														// không thỏa điều kiện trên thì :
															// nếu không thỏa ký tự -> báo lỗi PW
															// nếu bỏ trống txtCpw -> báo lỗi Cpw
															// nếu txtCpw không trùng với PW -> báo lỗi Cpw
												
								}
								else
								{
									errorProvider1.SetError(txtAddress, "Enter your Address please !");
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
