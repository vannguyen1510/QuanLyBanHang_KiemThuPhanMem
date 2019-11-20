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
    public class ChangePW
    {

        [TestMethod]
        public void Testpw()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_SignIn());
            bool actual = Frm_SignIn.PassFlag;
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
    }
}
