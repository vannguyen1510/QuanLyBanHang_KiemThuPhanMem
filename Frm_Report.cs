﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Configuration;
using DataTable = Microsoft.Office.Interop.Excel.DataTable;

namespace QLBH_KiemThuPhanMem
{
	public partial class Frm_Report : Form
	{
		SqlConnection sqlcon = new SqlConnection("Data Source= VAN;Initial Catalog=KTPM;Integrated Security=True");

		public Frm_Report()
		{
			InitializeComponent();
		}

		private void btnReport_Click(object sender, EventArgs e)
		{
		//	try
		//	{
		//		string saveExcelFile = @"D:\KTPM_Report.xlsx";
		//		Excel.Application xlApp = new Excel.Application();
		//		if(xlApp == null)
		//		{
		//			MessageBox.Show("Can not use Excel library !");
		//			return;
		//		}
		//		xlApp.Visible = false;
		//		object misValue = System.Reflection.Missing.Value;
		//		Workbook wb = xlApp.Workbooks.Add(misValue);
		//		Worksheet ws = (Worksheet)wb.Worksheets[1];
		//		if(ws == null)
		//		{
		//			MessageBox.Show("Can not create Worksheet !");
		//			return;
		//		}
		//		int row = 1;
		//		string fontName = "Time New Roman";
		//		int fontSizeTieuDe = 18;
		//		int fontSizeTenTruong = 14;
		//		int fontSizeNoiDung = 12;
		//		// Xuất dòng tiêu đề của file 
		//		Range row1_TieuDe_KTPM = ws.get_Range("A1", "K1");
		//		row1_TieuDe_KTPM.Merge();
		//		row1_TieuDe_KTPM.Font.Size = fontSizeTieuDe;
		//		row1_TieuDe_KTPM.Font.Name = fontName;
		//		row1_TieuDe_KTPM.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
		//		row1_TieuDe_KTPM.Value2 = "REVENUE";
		//		// Tạo ô Số thứ tự
		//		Range row2_STT = ws.get_Range("A2");
		//		row2_STT.Font.Size = fontSizeTenTruong;
		//		row2_STT.Font.Name = fontName;
		//		row2_STT.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
		//		row2_STT.Value2 = "No";
		//		// Tạo ô Mã hóa đơn
		//		Range row2_BillID = ws.get_Range("B2");
		//		row2_BillID.Font.Size = fontSizeTenTruong;
		//		row2_BillID.Font.Name = fontName;
		//		row2_BillID.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
		//		row2_BillID.Value2 = "ID Bill";
		//		row2_BillID.ColumnWidth = 25;
		//		// Tạo ô mã khách hàng
		//		Range row2_CusID = ws.get_Range("C2");
		//		row2_CusID.Font.Size = fontSizeTenTruong;
		//		row2_CusID.Font.Name = fontName;
		//		row2_CusID.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
		//		row2_CusID.Value2 = "ID Cus";
		//		row2_CusID.ColumnWidth = 20;
		//		// Tạo ô Mã Nhân viên
		//		Range row2_EmpID = ws.get_Range("D2");
		//		row2_EmpID.Font.Size = fontSizeTenTruong;
		//		row2_EmpID.Font.Name = fontName;
		//		row2_EmpID.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
		//		row2_EmpID.Value2 = "ID Emp";
		//		row2_EmpID.ColumnWidth = 20;
		//		// Tạo ô ngày đặt hàng
		//		Range row2_Date = ws.get_Range("E2");
		//		row2_Date.Font.Size = fontSizeTenTruong;
		//		row2_Date.Font.Name = fontName;
		//		row2_Date.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
		//		row2_Date.Value2 = "Order Date";
		//		row2_Date.ColumnWidth = 20;
		//		// Tạo ô quốc gia 
		//		Range row2_Country = ws.get_Range("F2");
		//		row2_Country.Font.Size = fontSizeTenTruong;
		//		row2_Country.Font.Name = fontName;
		//		row2_Country.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
		//		row2_Country.Value2 = "Order Date";
		//		row2_Country.ColumnWidth = 20;
		//		// Tạo ô mã sản phẩm
		//		Range row2_ProID = ws.get_Range("G2");
		//		row2_ProID.Font.Size = fontSizeTenTruong;
		//		row2_ProID.Font.Name = fontName;
		//		row2_ProID.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
		//		row2_ProID.Value2 = "ID Product";
		//		row2_ProID.ColumnWidth = 25;
		//		// Tạo ô giá tiền
		//		Range row2_Price = ws.get_Range("H2");
		//		row2_Price.Font.Size = fontSizeTenTruong;
		//		row2_Price.Font.Name = fontName;
		//		row2_Price.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
		//		row2_Price.Value2 = "Unit price";
		//		row2_Price.ColumnWidth = 25;
		//		// Tạo ô số lượng mua
		//		Range row2_Quantity = ws.get_Range("I2");
		//		row2_Quantity.Font.Size = fontSizeTenTruong;
		//		row2_Quantity.Font.Name = fontName;
		//		row2_Quantity.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
		//		row2_Quantity.Value2 = "Quantity";
		//		row2_Quantity.ColumnWidth = 25;
		//		// Tạo ô Discount
		//		Range row2_Discount = ws.get_Range("J2");
		//		row2_Discount.Font.Size = fontSizeTenTruong;
		//		row2_Discount.Font.Name = fontName;
		//		row2_Discount.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
		//		row2_Discount.Value2 = "Quantity";
		//		row2_Discount.ColumnWidth = 25;
		//		// Tô màu nền cột tiêu đề
		//		Range row2_Truong = ws.get_Range("A2","J2");
		//		row2_Truong.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
		//		row2_Truong.Font.Bold = true;
		//		row2_Truong.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
		//		//--------------------------------------------------------------------
		//		int stt = 0;
		//		row = 2; // Dữ liệu xuất bắt đầu ở vị trí dòng số 3 trong excel
		//		//--------------------------------------------------------------------
		//		string sql = "SELECT o.OrderID,o.ID_Cus,o.ID_Emp,o.OrderDate,o.ShipVia,od.ProductID,p.ProductName,od.UnitPrice,od.Quantity,od.Discount"
		//					+ "FROM [KTPM].[dbo].[Orders] AS o INNER JOIN"
		//					+ "[KTPM].[dbo].[Order Details] AS od ON od.OrderID = o.OrderID INNER JOIN"
		//					+ "[KTPM].[dbo].[Products] AS p ON od.ProductID = p.ProductID";
		//		sqlcon.Open();
		//		SqlCommand cmd = new SqlCommand(sql,sqlcon);
		//		SqlDataAdapter da = new SqlDataAdapter(cmd);
		//		DataTable dt = new DataTable();
		//		da.Fill(dt);
		//		dataGridView1.DataSource = dt;
		//		sqlcon.Close();
		//		// Tạo đối tượng cmd và set cho Orders

		//		//----------------------------------------------------------------------------
		//		// Lưu file Excel xuống ổ cứng
		//		wb.SaveAs(saveExcelFile);
		//		// Mở file Excel sau khi xuất thành công
		//		System.Diagnostics.Process.Start(saveExcelFile);
		//	}
		//	catch(Exception ex)
		//	{
		//		MessageBox.Show(ex.Message);
		//	}
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			//KTPMDataContext context = new KTPMDataContext();
			//dataGridView1.DataSource = context.
		}
	}
}
