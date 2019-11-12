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
	public partial class Frm_ForgotPassword : Form
	{
        SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-LFN81CO;Initial Catalog=KTPM;Integrated Security=True");
        //SqlConnection sqlcon = new SqlConnection(@"Data Source=VAN;Initial Catalog=KTPM;Integrated Security=True");
        //SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
        //SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["QLBH_KiemThuPhanMem.Properties.Settings.KTPMConnectionString"].ToString());
        public Frm_ForgotPassword()
		{
			InitializeComponent();
			
		}
		
		// hiển thị Tên đăng nhập từ frm SignIn
		public Frm_ForgotPassword(string id) : this()
		{ 
			txtUser.Text = id;
		}
		// Ngăn textbox bỏ trống
		private void txtUser_Leave(object sender, EventArgs e)
		{
			if (txtUser.Text == "")
			{
				txtUser.Text = "User";
				txtUser.ForeColor = Color.White;
			}
		}
		private void txtUser_Enter(object sender, EventArgs e)
		{
			if (txtUser.Text == "User")
			{
				txtUser.Text = "";
				txtUser.ForeColor = Color.White;
			}
		}
		private void txtNpw_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(txtNpw.Text))
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
			if (string.IsNullOrEmpty(txtCNpw.Text))
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
		private void txtUser_TextChanged(object sender, EventArgs e)
		{
			errorProvider1.SetError(txtUser, "");
		}

		// Ẩn hiện mật khẩu
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked)
				txtNpw.UseSystemPasswordChar = true;
			else
				txtNpw.UseSystemPasswordChar = false;
		}
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox3.Checked)
				txtCNpw.UseSystemPasswordChar = true;
			else
				txtCNpw.UseSystemPasswordChar = false;
		}

		// Function - Quên mật khẩu
		public void Forgot()
		{
			// textbox không bỏ trống
			if (ValidateChildren(ValidationConstraints.Enabled))
			{
				string Newpw = txtNpw.Text; // New password
				string Cfpw = txtCNpw.Text; // Confirm password
				string id = txtUser.Text; // phone 
				try
				{
					sqlcon.Open();
					string sql = "SELECT COUNT (*) FROM [KTPM].[dbo].[Info_Secret] Where Phone_Cus=@id";
					SqlCommand cmd = new SqlCommand(sql, sqlcon);
					cmd.Parameters.Add("@id", id);
					//cmd.Parameters.Add("@pass", pass);
					int x = (int)cmd.ExecuteScalar();
					if (x == 1)// đúng id
					{
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
										string sqlUpdatePW = "UPDATE [KTPM].[dbo].[Info_Secret] "
																+"SET Password='" + Cfpw + "' WHERE Phone_Cus='" + id + "'";
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
				errorProvider1.SetError(txtNpw, " Enter the password !");
				errorProvider1.SetError(txtCNpw, " Enter the password !");
			}
		}
		// btn Forgot
		private void btnDoipw_Click(object sender, EventArgs e)
		{
			Forgot();
		}

		// btn Sign In
		private void btnLogIn_Click(object sender, EventArgs e)
		{
			Frm_SignIn login = new Frm_SignIn();
			login.Show();
			this.Hide();
		}
		// btn Sign Up
		private void btnSignUp_Click(object sender, EventArgs e)
		{
			Frm_SignIn login = new Frm_SignIn();
			login.Show();
			this.Hide();
		}

		
		
	}
}
