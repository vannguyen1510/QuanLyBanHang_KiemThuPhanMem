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
            SqlCommand cmd = new SqlCommand(sql,sqlcon);
			cmd.ExecuteNonQuery();
            SqlDataAdapter data = new SqlDataAdapter(cmd);
			//DataSet set = new DataSet();
			//data.Fill(set,"Info_Emp");
			//combobEmp_ID.DataSource = set.Tables[0];
			//combobEmp_ID.DisplayMember = "ID_Emp";
			//combobEmp_ID.ValueMember = "FirstName_Emp";
			DataTable dt = new DataTable();
			data.Fill(dt);
			foreach(DataRow dr in dt.Rows)
			{
				combobEmp_ID.Items.Add(dr["ID_Emp"].ToString());
			}
        }

        // Function - Kiểm tra Employee
        //public void Check_Emp()
        //{
            
        //    else 
        //    {
        //        sqlcon.Open();
        //        string Emp_Name = txtEmp_Name.Text;
        //        string sql_Check_Emp = "SELECT COUNT (*) FROM Info_Emp WHERE FirstName=@fn";
        //        SqlCommand cmd_Check_Emp = new SqlCommand(sql_Check_Emp,sqlcon);
        //        cmd_Check_Emp.Parameters.Add(new SqlParameter("@fn", Emp_Name));
        //        int x = (int)cmd_Check_Emp.ExecuteScalar();
        //        if (x == 1)
        //        { 
                    
        //        }
        //    }
        //}

		private void combobEmp_ID_SelectedIndexChanged(object sender, EventArgs e)
		{
			// kiểm tra Emp_ID có trống hay không 
			// nếu có: thì báo lỗi - fail
			if (combobEmp_ID.SelectedIndex == -1)
			{
				errorProvider1.SetError(combobEmp_ID, "Do not accept blank fields !");
			}
			// nếu không: thì kiểm tra tồn tại trong SQL hay không
			else
			{
				sqlcon.Close();
				sqlcon.Open();
				string sql = "SELECT ID_Emp, FirstName_Emp FROM Info_Emp WHERE ID_Emp = '" + combobEmp_ID.Text + "'";
				SqlCommand cmd = new SqlCommand(sql, sqlcon);
				cmd.ExecuteNonQuery();
				SqlDataReader dr = cmd.ExecuteReader();
				// nếu tồn tại: thì hiển thị tên lên Emp_Name
				if(dr.Read())
				{
					if(dr.HasRows)
					{
						string name = (string)dr["FirstName_Emp"].ToString();
						txtEmp_Name.Text = name;
					}
					
					else
					{
						errorProvider1.SetError(combobEmp_ID, "Do not accept blank fields !");
					}
				}
				
				// nếu không tồn tại: thì báo lỗi
				
			}
		}



		
		
	}
}
