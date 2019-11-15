using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBH_KiemThuPhanMem;

namespace UnitTest_1
{
    [TestClass]
    public class TestUpDate
    {
        public TestContext TestContext { get; set; }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "|DataDirectory|\\Update.csv", "Update#csv", DataAccessMethod.Sequential),
                    DeploymentItem("UnitTest_1\\Update.csv"),
        TestMethod]
        public void testSua()
        {
            string LastName_Emp = TestContext.DataRow[0].ToString();
            string FirstName_Emp = TestContext.DataRow[1].ToString();
            string Birtday_Emp = TestContext.DataRow[2].ToString();
            string Sex_Emp = TestContext.DataRow[3].ToString();
            string ID_E = TestContext.DataRow[4].ToString();
            bool expected = bool.Parse(TestContext.DataRow[5].ToString());
            Frm_List_Cus_Emp Cusb = new Frm_List_Cus_Emp();
            bool actual = Cusb.Update1(LastName_Emp, FirstName_Emp, Birtday_Emp, Sex_Emp, ID_E);
            Assert.AreEqual(expected, actual);
        }
    }
}
