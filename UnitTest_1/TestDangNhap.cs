using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBH_KiemThuPhanMem;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnitTest_1
{
    [TestClass]
    public class TestDangNhap
    {
        [TestMethod]
        public void TestDangNhap2()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_SignIn());
            bool actual = Frm_SignIn.LoginFlag;
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
    }
 
}
