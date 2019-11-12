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
	}
}
