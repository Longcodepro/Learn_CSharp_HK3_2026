using System;
using Lab01.BankCustomer;

namespace Lab01.ChucNangChuyenTien
{
    public class ChuyenTien
    {
        public static void thucHienGiaoDich(Customer nguoiChuyen, Customer nguoiNhan, double soTien)
        {
            nguoiNhan.nhanTien(soTien, nguoiChuyen.name);
            nguoiChuyen.truTien(soTien, nguoiNhan.name);
        }
    }
}