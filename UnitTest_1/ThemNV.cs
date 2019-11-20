using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBH_KiemThuPhanMem;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitTest_1
{
	[TestClass]
	public class ThemNV
	{
        public void Testthemnv()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_List_Cus_Emp());
            bool actual = Frm_List_Cus_Emp.themFlag;
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
    }
}
