using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_KiemThuPhanMem
{
	public partial class Frm_Bill : Form
	{
		public Frm_Bill()
		{
			InitializeComponent();
			string billNo = txtBillNo.Text;
		}

		private void Frm_Bill_Load(object sender, EventArgs e)
		{
            txtBillNo.Text = "Hello";
		}
		
		private string RandomString(int count)
		{
			string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
			string[] allCharArray = allChar.Split(',');
			string billNo = txtBillNo.Text;
			int temp = -1;
			Random rd = new Random();
			for(int i = 0; i < count; i++)
			{
				if(temp != -1)
				{
					rd = new Random(i*temp*((int)DateTime.Now.Ticks));
				}
				int t = rd.Next(36);
				if(temp != -1 && temp == t)
				{
					return RandomString(count);
				}
				temp = t;
				billNo += allCharArray[t];
			}
			return billNo;
		}
		
		private void cbRandomBillNo_CheckedChanged(object sender, EventArgs e)
		{
			RandomString(6);
		}
	}
}
