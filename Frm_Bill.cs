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
	public partial class Frm_Bill : Form
	{
		// SQL CONNECTION
        //SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["QLBH_KiemThuPhanMem.Properties.Settings.KTPMConnectionString"].ToString());
		SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ToString());

		// RANDOM BILL NO
		private const String allChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private readonly char[] allCharArray = (allChar + allChar.ToUpper() + "0123456789").ToCharArray();

		public Frm_Bill()
		{
			InitializeComponent();
		}

		private void Frm_Bill_Load(object sender, EventArgs e)
		{
			
			Load_combobEmp_ID();
		}

		// Function - Random Bill No
		private string RandomString(int count)
		{
			StringBuilder result = new StringBuilder();
			Random rd = new Random();
			for(int i = 0; i< count; i++)
			{
				result.Append(allCharArray[rd.Next(allCharArray.Length)]);
			}
			return result.ToString();
		}
		// Checkbox Bill No
		private void cbRandomBillNo_CheckedChanged(object sender, EventArgs e)
		{
			if(cbRandomBillNo.Checked == true)
			{
				txtBillNo.Text = RandomString(Convert.ToInt32(5));
			}
			else
			{
				txtBillNo.Text = string.Empty;
			}
		}

		// Function - Load Employee ID
		public void Load_combobEmp_ID()
		{
			combobEmp_ID.Items.Clear();
			sqlcon.Open();
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

		// Function - Kiểm tra Employee
		private void combobEmp_ID_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				for(int i =0; i<= combobEmp_ID.Items.Count - 1; i++)
				{
					if(combobEmp_ID.Text.Equals(combobEmp_ID.GetItemText(combobEmp_ID.Items[i].ToString())))
					{
						sqlcon.Close();
						sqlcon.Open();
						string sql = "SELECT ID_Emp, FirstName_Emp FROM Info_Emp WHERE ID_Emp = '" + combobEmp_ID.Text + "' COLLATE SQL_Latin1_General_CP1_CS_AS";
						SqlCommand cmd = new SqlCommand(sql, sqlcon);
						cmd.ExecuteNonQuery();
						SqlDataReader dr = cmd.ExecuteReader();
						while (dr.Read())
						{
							string name = (string)dr["FirstName_Emp"].ToString();
							txtEmp_Name.Text = name;
						}
						sqlcon.Close();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error Connection. Please try again !", "ERROR");
			}
			
		}

		private void combobEmp_ID_Leave(object sender, EventArgs e)
		{
			if (ValidateChildren(ValidationConstraints.Enabled))
			{
				//string empID = combobEmp_ID.Text;
				//sqlcon.Open();
				//string sql = "SELECT ID_Emp FROM Info_Emp WHERE ID_Emp = @id  COLLATE SQL_Latin1_General_CP1_CS_AS";
				//SqlCommand cmd = new SqlCommand(sql, sqlcon);
				//cmd.Parameters.Add(new SqlParameter ("@id",empID));
				//int x = (int)cmd.ExecuteScalar();
				//if (x == 1)
				//{
				//	string sql_c = "SELECT ID_Emp, FirstName_Emp FROM Info_Emp WHERE ID_Emp = '"+empID+"'  COLLATE SQL_Latin1_General_CP1_CS_AS";
				//	SqlCommand cmd_c = new SqlCommand(sql, sqlcon);
				//	cmd_c.ExecuteNonQuery();
				//	SqlDataReader dr = cmd_c.ExecuteReader();
				//	while (dr.Read())
				//	{
				//		string name = (string)dr["FirstName_Emp"].ToString();
				//		txtEmp_Name.Text = name;
				//	}
				//}
				//else
				//{
				//	errorProvider1.SetError(combobEmp_ID, " This employee ID does not exist in Database !");
				//}
			}
			else
			{
				sqlcon.Close();
				errorProvider1.SetError(combobEmp_ID, " Do not accept blank field !");
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
	}
}
