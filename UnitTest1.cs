using System;
using System.Data;
using QLBH_KiemThuPhanMem;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextDangNhap
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDN()
        {
            string userName = "NV05";
            string passWord = "Nv05@#";
            bool expected = true;
            if(userName.Length > 100 || passWord.Length > 100)
            {
                throw new InvalidOperationException("Số kí tự quá dài");
            }
            else
            {
                Frm_SignIn b = new Frm_SignIn();
                b.user = userName;
                b.pass = passWord;
                bool actual = b.DangNhap(userName, passWord);
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
