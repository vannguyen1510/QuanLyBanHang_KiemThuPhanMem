using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_KiemThuPhanMem
{
	class Class_ChuyenSoThanhChu
	{
		public static string ChuyenSoThanhChu (string sNumber)
		{
			int mLen, mDigit;
			string mtemp = "";
			string[] mNumText;
			// Xóa các dấu "," nếu có
			sNumber = sNumber.Replace(",", "");
			mNumText = "Zero;One;Two;Three;Four;Five;Six;Seven;Eight;Nine".Split(';');
			mLen = sNumber.Length - 1;
			for(int i =0; i <= mLen; i++)
			{
				mDigit = Convert.ToInt32(sNumber.Substring(i,1));
				mtemp = mtemp + " " + mNumText[mDigit];
				if(mLen == i)
					switch ((mLen - i) % 9)
				{
						case 0:
							{
								mtemp = mtemp + " Billion ";
								if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
								if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
								if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
								break;
							}
						case 6:
							{
								mtemp = mtemp + " Milion ";
								if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
								if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
								break;
							}
						case 3:
							{
								mtemp = mtemp + " Thousand ";
								if (sNumber.Substring(i + 1, 3) == "000") i = i + 3;
								break;
							}
						default:
							switch ((mLen - i) % 3)
							{
								case 2:
									mtemp = mtemp + " Houndred";
									break;
								case 1:
									mtemp = mtemp + " mươi";
									break;
							}
							break;
					}
			}
			return mtemp;
		}
	}
}
