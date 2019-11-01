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
	public partial class Frm_ChangePassword : Form
	{
		SqlConnection sqlcon = new SqlConnection(@"Data Source=VAN;Initial Catalog=QLBH;Integrated Security=True");
		public Frm_ChangePassword()
		{
			InitializeComponent();
			//string connectionString = ConfigurationManager.ConnectionStrings["Data Source=VAN;Initial Catalog=QLBH;Integrated Security=True"].ConnectionString;
		}
		public Frm_ChangePassword(String id) : this()
		{
			txtTenDangNhap.Text = id;
		}

		// Function - Change
		public void Change()
		{
			try
			{
				sqlcon.Open();
				string pass = txtEpw.Text;
				string id = txtTenDangNhap.Text;
				if (pass != null) // textbox không bỏ trống
				{
					string sql = "SELECT COUNT (*) FROM [QLBH].[dbo].[Info_SignIn] Where ID_Sin=@id AND Pass_Sin=@pass";
					SqlCommand cmd = new SqlCommand(sql, sqlcon);
					cmd.Parameters.Add("@id", id);
					cmd.Parameters.Add("@pass", pass);
					int x = (int)cmd.ExecuteScalar();
					if (x == 1)// đúng id và password cũ
					{
						txtNpw.ReadOnly = false;
						txtCNpw.ReadOnly = false;
						string Newpw = txtNpw.Text.Trim();
						string Cfpw = txtCNpw.Text.Trim();
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
							btnDoipw.Enabled = false; // vô hiệu hóa nút đổi Mật khẩu
						}
						else // chưa bắt được lỗi nhập Khoảng trắng đầu cuối
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
								//else
								//{
								//	countDB++;
								//}
								i++;
							}
							if (countThuong >= 1 && countHoa >= 1 && countSo >= 1 && countDB >= 1)
							{
								btnDoipw.Enabled = true;
							}
							if (txtCNpw.Text != "" && txtNpw.Text != "")
							{
								if (String.Compare(Newpw, Cfpw, false) == 0)
								{
									btnDoipw.Enabled = true;
									string sqlUpdatePW = "UPDATE [QLBH].[dbo].[Info_SignIn] SET Pass_Sin='" + txtCNpw.Text + "' WHERE ID_Sin='" + txtTenDangNhap.Text + "'";
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
						// So sánh PW mới với xác nhận PW
					}
					else // nếu sai password
					{
						txtNpw.ReadOnly = true;
						txtCNpw.ReadOnly = true;
						MessageBox.Show("You have entered the WRONG PASSWORD !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					if (txtEpw.Text == "")
					{
						errorProvider1.SetError(txtEpw, " Enter the password !");
					}
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
			DialogResult = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if (DialogResult == DialogResult.OK)
			{
				this.Close();
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
				txtEpw.UseSystemPasswordChar = true;
			else
				txtEpw.UseSystemPasswordChar = false;
		}
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
	}
}
