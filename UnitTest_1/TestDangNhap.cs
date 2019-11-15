using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBH_KiemThuPhanMem;

namespace UnitTest_1
{
    [TestClass]
    public class TestDangNhap
    {
        public TestContext TestContext { get; set; }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "|DataDirectory|\\DangNhap.csv", "DangNhap#csv", DataAccessMethod.Sequential),
                    DeploymentItem("UnitTest_1\\DangNhap.csv"),
        TestMethod]
        public void TestDangNhap1()
        {
            string userName = TestContext.DataRow[0].ToString();
            string passWord = TestContext.DataRow[1].ToString();
            bool expected = bool.Parse(TestContext.DataRow[2].ToString());
            Frm_SignIn b = new Frm_SignIn();
            bool actual = b.DangNhap1(userName, passWord);
            Assert.AreEqual(expected, actual);
        }
    }
}
