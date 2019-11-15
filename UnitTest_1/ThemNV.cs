using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBH_KiemThuPhanMem;

namespace UnitTest_1
{
	[TestClass]
	public class ThemNV
	{
		public TestContext TestContext { get; set; }
		[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
					"|DataDirectory|\\themNV.csv", "themNV#csv", DataAccessMethod.Sequential),
					DeploymentItem("UnitTest_1\\themNV.csv"),
		TestMethod]
		public void testThemNV()
		{
			string ma = TestContext.DataRow[0].ToString();
			string ho = TestContext.DataRow[1].ToString();
			string ten =TestContext.DataRow[2].ToString();
			string ns = TestContext.DataRow[3].ToString();
			string gt = TestContext.DataRow[4].ToString();
			bool expected = bool.Parse(TestContext.DataRow[5].ToString());
			Frm_List_Cus_Emp Cus = new Frm_List_Cus_Emp();         
			bool actual = Cus.AddNew1(ma, ho, ten, ns, gt);
			Assert.AreEqual(true, actual);
		}
	}
}
