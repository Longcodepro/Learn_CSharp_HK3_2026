using System;
using Lab01.BankCustomer;
using Lab01.ChucNangChuyenTien;

namespace Lab01
{
    class Program
    {
        public static void Main(String[] args)
        {

            Customer cusA = new Customer("Nguyen Van A", 0.0);
            Customer cusB = new Customer("Nguyen Van B", 0.0);

            cusA.napTien();
            cusB.napTien();

            ChuyenTien.thucHienGiaoDich(cusA, cusB, 50000);

            cusA.xemSoDu();
            cusB.xemSoDu();
        }
    }
}