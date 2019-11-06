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
		//SqlConnection sqlcon = new SqlConnection(@"Data Source=VAN;Initial Catalog=KTPM;Integrated Security=True");
		SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());
        //SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["QLBH_KiemThuPhanMem.Properties.Settings.KTPMConnectionString"].ToString());
		public Frm_ForgotPassword()
		{
			InitializeComponent();
		}
		public void Forgot()
		{

			try
			{
				sqlcon.Open();
				string id = txtUser.Text;
				if (id != null) // Textbox không bỏ trống
				{
					string sql = "Select Count(*) From [KTPM].[dbo].[Info_Secret] Where Phone_Cus=@id ";
					SqlCommand cmd = new SqlCommand(sql, sqlcon);
					cmd.Parameters.Add(new SqlParameter("@Phone_Cus", id));
					int x = (int)cmd.ExecuteScalar();
					if (x == 1) // đúng id
					{
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
								else
								{
									countDB++;
								}
								i++;
							}
							if (countThuong >= 1 && countHoa >= 1 && countSo >= 1 && countDB >= 1)
							{
								btnDoipw.Enabled = true;
							}
						}
						// So sánh PW mới với xác nhận PW
						if (String.Compare(Newpw, Cfpw, false) == 0)
						{
							btnDoipw.Enabled = true;
							string sqlUpdatePW = "UPDATE [KTPM].[dbo].[Info_Secret] SET Password='" + txtCNpw.Text + "' WHERE Phone_Cus='" + txtUser.Text + "'";
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
						MessageBox.Show("User is not correct! Please try again ", "ERROR");
					}
				}
				else
				{
					if (txtUser.Text == "")
					{
						errorProvider1.SetError(txtUser, "Do not accept blank fields!");
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Connection failed !", "Try Again");
			}
			finally
			{
				sqlcon.Close();
			}
		}

		private void btnLogIn_Click(object sender, EventArgs e)
		{
			Frm_SignIn login = new Frm_SignIn();
			login.Show();
			this.Hide();
		}
	}
}
