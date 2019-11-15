using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBH_KiemThuPhanMem;

namespace UnitTest_1
{
    [TestClass]
    public class TestDangKy
    {
        public TestContext TestContext { get; set; }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "|DataDirectory|\\DangKy.csv", "DangKy#csv", DataAccessMethod.Sequential),
                    DeploymentItem("UnitTest_1\\DangKy.csv"),
        TestMethod]
        public void TestDangky1()
        {
            string F = TestContext.DataRow[0].ToString();
            string L = TestContext.DataRow[1].ToString();
            string P = TestContext.DataRow[2].ToString();
            string pw = TestContext.DataRow[3].ToString();
            string cpw = TestContext.DataRow[4].ToString();
            string A = TestContext.DataRow[5].ToString();
            bool expected = bool.Parse(TestContext.DataRow[6].ToString());
            Frm_SignIn b = new Frm_SignIn();
            bool actual = b.DangKy1(F, L, P, pw, cpw, A);
            Assert.AreEqual(expected, actual);
            // false false => true

        }
    }
}
