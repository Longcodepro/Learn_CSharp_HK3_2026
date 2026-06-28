using System;

namespace Lab01.BankCustomer
{
    public class Customer
    {
        private string _name;
        public string name
        {
            set{ _name = value; }
            get{ return _name; }
        }
        private double _soDu;
        public double soDu
        {
            set{ _soDu = (value >= 0) ? value : 0.0; }
            get{ return _soDu; }
        }

        public Customer()
        {
            _name = "";
            _soDu = 0.0;
        }

        public Customer(string name, double soDu)
        {
            _name = name;
            _soDu = soDu;
        }

        public void napTien()
        {
            double soTienCanNap;
            Console.Write("Nhập vào số tiền bạn cần nạp: ");
            soTienCanNap = double.Parse(Console.ReadLine() ?? "0");

            if( soTienCanNap >=0 && soTienCanNap <=10000000 )
            {
                _soDu += soTienCanNap;
                Console.WriteLine("Nạp tiền thành công!!!");
            }
            else
            {
                Console.WriteLine("Số tiền nạp không hợp lệ");
            }
        }

        public void rutTien()
        {
            double soTienCanRut;
            Console.Write("Nhập vào số tiền bạn cần rút: ");
            soTienCanRut = double.Parse(Console.ReadLine() ?? "0");

            if( soTienCanRut >=0 && soTienCanRut <=10000000 && soTienCanRut <= _soDu)
            {
                _soDu -= soTienCanRut;
                Console.WriteLine("Rút tiền thành công!!!");
            }
            else
            {
                Console.WriteLine("Số tiền rút không hợp lệ");
            }
        }

        public void nhanTien(double bill, string nguoiChuyen)
        {
            _soDu += bill;
            Console.WriteLine($"Biến động số dư: +${bill} từ {nguoiChuyen}. Tổng số dư: {_soDu}");
        }

        public void truTien(double bill, string nguoiNhan)
        {
            if(bill > _soDu)
            {
                Console.WriteLine($"Chuyển tiền từ tài khoản {_name} thất bại");
            }
            else
            {
                _soDu -= bill;
                Console.WriteLine($"Chuyển tiền từ tài khoản {_name} thành công với số tiền {bill}"
                + $" đến tài khoản ${nguoiNhan}. Số dư là: {_soDu}");
            }
        }

        public void xemSoDu()
        {
            Console.WriteLine($"Tài khoản {_name} có số dư: {_soDu}");
        }
    }
}
