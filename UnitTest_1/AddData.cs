﻿using System;
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
    public class AddData
    {
        
        
        [TestMethod]
            public void TestAdddata()
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Frm_Bill());
                bool actual = Frm_Bill.ADDData;
                bool expected = true;
                Assert.AreEqual(expected, actual);
            }
    }
}
