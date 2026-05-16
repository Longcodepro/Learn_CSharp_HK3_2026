// nhập vào chiều dài chiều rộng của một hình chữ nhật và tính diện tích và chu vi của nó

using System;

namespace Basic.Class
{
    class Bai2
    {
        public static void Main(String[] args)
        {
            // input
            Console.Write("Nhập vào chiều dài hình chữ nhật: ");
            double cd = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhập vào chiều rộng hình chữ nhật: ");
            double cr = double.Parse(Console.ReadLine() ?? "0");

            // khởi tạo
            HCN hcn1 = new HCN(cd, cr);

            // output
            hcn1.PrintResult();
        }
    }

    class HCN
    {
        private double _cd{set; get;}
        public double cd
        {
            set => _cd = (value>=0) ? value : 0;
            get => _cd;
        }

        private double _cr{set; get;}
        public double cr
        {
            set => _cr = (value>=0) ? value : 0;
            get => _cr;
        }
        
        // Constructor
        public HCN()
        {
            this._cd = 0;
            this._cr = 0;
        }

        public HCN(double cd, double cr)
        {
            this._cd = cd;
            this._cr = cr;
        }

        // tính diện tích
        public double SHCN()
        {
            return _cd * _cr;
        }

        // tính chu vi
        public double CHCN()
        {
            return (_cd + _cr)/2;
        }

        // in ra kết quả
        public void PrintResult()
        {
            Console.WriteLine($"Diện tích hình chữ nhật là: {this.SHCN():F2}");
            Console.WriteLine($"Chu vi hình chữ nhật là: {this.CHCN():F2}");
        }
    }    
}