using System;
using Lab01.BankCustomer;
using Lab01.ChucNangChuyenTien;

namespace Lab01
{
    class Program
    {
        public static void Main(String[] args)
        {
            // tạo 2 object khách hàng
            Customer cusA = new Customer("Nguyen Van A", 0.0);
            Customer cusB = new Customer("Nguyen Van B", 0.0);

            // nạp tiền cho 2 khách
            cusA.napTien();
            cusB.napTien();

            // chuyển tiền từ cusA sang cusB
            ChuyenTien.thucHienGiaoDich(cusA, cusB, 50000);

            // in ra số dư của cả hai
            cusA.xemSoDu();
            cusB.xemSoDu();
        }
    }
}