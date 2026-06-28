

using System;

namespace Basic.Class.Bai3
{
    class Bai2
    {
        public static void Main(String[] args)
        {

            Console.Write("Nhập vào chiều dài hình chữ nhật: ");
            double cd = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhập vào chiều rộng hình chữ nhật: ");
            double cr = double.Parse(Console.ReadLine() ?? "0");

            HCN hcn1 = new HCN(cd, cr);

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

        public double SHCN()
        {
            return _cd * _cr;
        }

        public double CHCN()
        {
            return (_cd + _cr)/2;
        }

        public void PrintResult()
        {
            Console.WriteLine($"Diện tích hình chữ nhật là: {this.SHCN():F2}");
            Console.WriteLine($"Chu vi hình chữ nhật là: {this.CHCN():F2}");
        }
    }
}