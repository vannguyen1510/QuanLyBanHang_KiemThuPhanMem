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
    public class TestFind
    {

        [TestMethod]
        public void TestFind1()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_List_Cus_Emp());
            bool actual = Frm_List_Cus_Emp.TiemKiemFlag;
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
    }
}
