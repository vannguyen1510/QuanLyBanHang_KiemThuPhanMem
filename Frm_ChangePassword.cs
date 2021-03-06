﻿using System;
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
using System.Security.Cryptography;

namespace QLBH_KiemThuPhanMem
{
	public partial class Frm_ChangePassword : Form
	{
        //SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-LFN81CO\MINHLINH;Initial Catalog=KTPM;Integrated Security=True");
        SqlConnection sqlcon = new SqlConnection(@"Data Source=VAN;Initial Catalog=QLBH;Integrated Security=True");
        //SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
        //SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["QLBH_KiemThuPhanMem.Properties.Settings.KTPMConnectionString"].ToString());
        public Frm_ChangePassword()
		{
			InitializeComponent();
		}
		public Frm_ChangePassword(String id) : this()
		{
			txtTenDangNhap.Text = id;
		}

		// Function - Change
		public void Change()
		{
			// textbox không bỏ trống
			if (ValidateChildren(ValidationConstraints.Enabled))
			{
				try
				{
					sqlcon.Open();
					string pass = txtEpw.Text;
					string id = txtTenDangNhap.Text;
					// Mã hóa mật khẩu 
					string str = "";
					Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(pass);
					MD5CryptoServiceProvider md = new MD5CryptoServiceProvider();
					buffer = md.ComputeHash(buffer);
					foreach (Byte b in buffer)
					{
						str += b.ToString("X2");
					}
					string sql = "SELECT COUNT (*) FROM [KTPM].[dbo].[Info_Secret] Where ID_Emp=@id COLLATE SQL_Latin1_General_CP1_CS_AS AND Password=@pass";
					SqlCommand cmd = new SqlCommand(sql, sqlcon);
					cmd.Parameters.AddWithValue("@id", id);
					cmd.Parameters.AddWithValue("@pass", str);
					int x = (int)cmd.ExecuteScalar();
					if (x == 1)// đúng id và password cũ
					{
						txtNpw.ReadOnly = false;
						txtCNpw.ReadOnly = false;
						string Newpw = txtNpw.Text;
						string Cfpw = txtCNpw.Text;
						string pattern = @"^[ \s]+|[ \s]+$ ";
						int countSo = 0;
						int countHoa = 0;
						int countThuong = 0;
						int countDB = 0;
						int i = 0;
						// Kiểm soát chiều dài PW
						if (Newpw.Length < 6 || Newpw.Length > 8)
						{
							errorProvider1.SetError(txtNpw, "Password must be at least 6 character and no more than 8 !"); // [6,8]
							txtNpw.Text = string.Empty;
							txtCNpw.Text = string.Empty;
						}
						else 
						{
							while (i < Newpw.Length)
							{
								if (Newpw[i] >= 'a' && Newpw[i] <= 'z')
								{
									countThuong++;
								}
								else if (Newpw[i] >= 'A' && Newpw[i] <= 'Z')
								{
									countHoa++;
								}
								else if (Newpw[i] >= '0' && Newpw[i] <= '9')
								{
									countSo++;
								}
								else
								{
									Regex checkWhitespace = new Regex(pattern);
									if (checkWhitespace.IsMatch(Newpw))
									{
										errorProvider1.SetError(txtNpw, "Your password can't start or end with a blank space");
										txtNpw.Text = string.Empty;
									}
									if (checkWhitespace.IsMatch(Cfpw))
									{
										errorProvider1.SetError(txtCNpw, "Your password can't start or end with a blank space");
										txtCNpw.Text = string.Empty;
									}
									countDB++;
								}
								i++;
							}
							if (countThuong >= 1 && countHoa >= 1 && countSo >= 1 && countDB >= 1)
							{
								if (txtCNpw.Text != "" && txtNpw.Text != "")
								{
									// So sánh PW mới với xác nhận PW
									if (String.Compare(Newpw, Cfpw, false) == 0)
									{
										btnDoipw.Enabled = false;
										// Mã hóa mật khẩu 
										string str1 = "";
										Byte[] buffer1 = System.Text.Encoding.UTF8.GetBytes(txtCNpw.Text);
										MD5CryptoServiceProvider md1 = new MD5CryptoServiceProvider();
										buffer1 = md1.ComputeHash(buffer1);
										foreach (Byte b1 in buffer1)
										{
											str1 += b1.ToString("X2");
										}
										string sqlUpdatePW = "UPDATE [KTPM].[dbo].[Info_Secret] SET Password='" + str1 + "' WHERE ID_Emp='" + txtTenDangNhap.Text + "'";
										SqlCommand cmdUpDatePW = new SqlCommand(sqlUpdatePW, sqlcon);
										SqlDataAdapter dap = new SqlDataAdapter(cmdUpDatePW);
										DataTable dt = new DataTable();
										dap.Fill(dt);
										cmdUpDatePW.ExecuteNonQuery();
										MessageBox.Show("Your password has been changed successfully !");
										sqlcon.Close();
									}
									else
									{
										errorProvider1.SetError(txtCNpw, "You need to confirm excactly!");
										Cfpw = string.Empty;
									}
								}
								else
								{
									errorProvider1.SetError(txtCNpw, "Please enter new password and confirm password!");
								}
							}
							else
							{
								errorProvider1.SetError(txtNpw, "Please read the password setting instructions!");
							}
						}
					}
					else // nếu sai password
					{
						MessageBox.Show("You have entered the WRONG PASSWORD !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				catch (Exception)
				{
					MessageBox.Show("Error Connection!", "Please Try Again");
				}
				finally
				{
					sqlcon.Close();
				}
			}
			else
			{
				errorProvider1.SetError(txtEpw, " Enter the password !");
			}
		}
		// btn Change
		private void btnDoipw_Click(object sender, EventArgs e)
		{
			Change();
		}

		// Function - Reset
		public void reset()
		{
			txtEpw.Text = string.Empty;
			txtNpw.Text = string.Empty;
			txtCNpw.Text = string.Empty;
			btnDoipw.Enabled = true;
		}
		// btn RESET
		private void btnReset_Click(object sender, EventArgs e)
		{
			reset();
		}

		// btn ĐÓNG
		private void btnDong_Click(object sender, EventArgs e)
		{
			DialogResult = MessageBox.Show(" Do you want to Sign In?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (DialogResult == DialogResult.No)
			{
				this.Close();
			}
			else
			{
				this.Hide();
				Frm_SignIn sin = new Frm_SignIn();
				sin.Show();
			}
		}

		// BẮT SỰ KIỆN PHÍM
		protected override bool ProcessDialogKey(Keys keyData)
		{
			switch (keyData)
			{
				case Keys.R:
					{
						reset();
						break;
					}
				case Keys.C:
					{
						Change();
						break;
					}
			}
			return base.ProcessDialogKey(keyData);
		}

		// ẨN HIỆN PASSWORD
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
				txtEpw.UseSystemPasswordChar = false;
			else
				txtEpw.UseSystemPasswordChar = true;
		}
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked)
				txtNpw.UseSystemPasswordChar = false;
			else
				txtNpw.UseSystemPasswordChar = true;
		}
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox3.Checked)
				txtCNpw.UseSystemPasswordChar = false;
			else
				txtCNpw.UseSystemPasswordChar = true;
		}

		private void txtEpw_Validating(object sender, CancelEventArgs e)
		{
			if(string.IsNullOrEmpty(txtEpw.Text))
			{
				e.Cancel = true;
				txtEpw.Focus();
				errorProvider1.SetError(txtEpw, " Enter the password !");
			}
			else
			{
				e.Cancel = false;
				errorProvider1.SetError(txtEpw,null);
			}
		}

		private void txtNpw_TextChanged(object sender, EventArgs e)
		{

		}

		private void txtNpw_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(txtEpw.Text))
			{
				e.Cancel = true;
				txtNpw.Focus();
				errorProvider1.SetError(txtNpw, " Enter the password !");
			}
			else
			{
				e.Cancel = false;
				errorProvider1.SetError(txtNpw, null);
			}
		}

		private void txtCNpw_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(txtEpw.Text))
			{
				e.Cancel = true;
				txtCNpw.Focus();
				errorProvider1.SetError(txtCNpw, " Enter the password !");
			}
			else
			{
				e.Cancel = false;
				errorProvider1.SetError(txtCNpw, null);
			}
		}
	}
}
