using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBH_KiemThuPhanMem;

namespace TestDangNhap
{
    [TestClass]
    public class DangNhap
    {
        public TestContext TestContext { get; set; }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "|DataDirectory|\\Login.csv", "Login#csv", DataAccessMethod.Sequential),
                    DeploymentItem("TestDangNhap\\Login.csv"),
        TestMethod]
        public void TestDangNhap()
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
