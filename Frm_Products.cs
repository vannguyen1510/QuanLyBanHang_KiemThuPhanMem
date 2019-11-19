using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_KiemThuPhanMem
{
	public partial class Frm_Products : Form
	{
		SqlConnection sqlcon = new SqlConnection("Data Source= VAN;Initial Catalog=KTPM;Integrated Security=True");
		public Frm_Products()
		{
			InitializeComponent();
		}

		private void Frm_Products_Load(object sender, EventArgs e)
		{
			dataLoad();
		}

		// Kiểm tra textbox rỗng
		private void txtBillNo_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(txtBillNo.Text))
			{
				e.Cancel = true;
				txtBillNo.Focus();
				errorProvider1.SetError(txtBillNo, " Do not accept blank field !");
			}
			else
			{
				e.Cancel = false;
				errorProvider1.SetError(txtBillNo, null);
			}
		}
		private void txtName_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(txtName.Text))
			{
				e.Cancel = true;
				txtName.Focus();
				errorProvider1.SetError(txtName, " Do not accept blank field !");
			}
			else
			{
				e.Cancel = false;
				errorProvider1.SetError(txtName, null);
			}
		}
		private void txtprice_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(txtprice.Text))
			{
				e.Cancel = true;
				txtprice.Focus();
				errorProvider1.SetError(txtprice, " Do not accept blank field !");
			}
			else
			{
				e.Cancel = false;
				errorProvider1.SetError(txtprice, null);
			}
		}
		private void txtStock_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(txtStock.Text))
			{
				e.Cancel = true;
				txtStock.Focus();
				errorProvider1.SetError(txtStock, " Do not accept blank field !");
			}
			else
			{
				e.Cancel = false;
				errorProvider1.SetError(txtStock, null);
			}
		}
		private void textBox5_Validating(object sender, CancelEventArgs e)
		{
			if (string.IsNullOrEmpty(textBox5.Text))
			{
				e.Cancel = true;
				textBox5.Focus();
				errorProvider1.SetError(textBox5, " Do not accept blank field !");
			}
			else
			{
				e.Cancel = false;
				errorProvider1.SetError(textBox5, null);
			}
		}

		// Không nhận ký tự đặc biệt
		private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar > (char)47) && (e.KeyChar < (char)58) // 0-9
				|| (e.KeyChar > (char)64) && (e.KeyChar < (char)91) // A - Z
				|| (e.KeyChar == (char)8)) // backspace
			{
				txtBillNo.ShortcutsEnabled = false;
				e.Handled = false;
			}
			else
			{
				MessageBox.Show("Accept only numbers and letters!");
				e.Handled = true;
			}
		}
		private void txtName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (((e.KeyChar > (char)47) && (e.KeyChar < (char)58) // 0-9
				|| (e.KeyChar > (char)64) && (e.KeyChar < (char)91) // A - Z
				|| (e.KeyChar > (char)96) && (e.KeyChar < (char)123)) // a- z
				|| (e.KeyChar == (char)8)) // backspace
			{
				txtName.ShortcutsEnabled = false;
				e.Handled = false;
			}
			else
			{
				MessageBox.Show("Accept only numbers and letters!");
				e.Handled = true;
			}
		}

		// Chỉ nhận ký tự số
		private void txtprice_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar > (char)47) && (e.KeyChar < (char)58) // 0-9
				|| (e.KeyChar == (char)8)) // backspace
			{
				txtprice.ShortcutsEnabled = false;
				e.Handled = false;
			}
			else
			{
				MessageBox.Show("Accept only numbers!");
				e.Handled = true;
			}
		}
		private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar > (char)47) && (e.KeyChar < (char)58) // 0-9
				|| (e.KeyChar == (char)8)) // backspace
			{
				txtStock.ShortcutsEnabled = false;
				e.Handled = false;
			}
			else
			{
				MessageBox.Show("Accept only numbers!");
				e.Handled = true;
			}
		}

		// Load dữ liệu lên Data Grid View
		private void dataLoad()
		{
			sqlcon.Open();
			String sql = "Select * From [KTPM].[dbo].[Products] ";
			SqlCommand cmd = new SqlCommand(sql, sqlcon);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			sqlcon.Close();
			dataGridView1.DataSource = dt;
		}

	}
}
