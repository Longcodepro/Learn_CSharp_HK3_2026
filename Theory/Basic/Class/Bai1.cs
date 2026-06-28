

using System;

namespace Basic.Class.Bai1
{
    class Bai1
    {
        public static void Main(String[] args)
        {

            Console.Write("Nhập vào bán kính hình tròn: ");
            double ban_kinh = double.Parse(Console.ReadLine() ?? "0");

            HinhTron ht = new HinhTron(ban_kinh);

            Console.WriteLine($"Diện tích hình tròn là: {ht.dienTich():F2}");
            Console.WriteLine($"Chu vi hình tròn là: {ht.chuVi():F2}");
        }
    }

    class HinhTron
    {
        private double _banKinh {set; get;}
        public double BanKinh {
            set => _banKinh = (value>=0) ? value : 0;
            get => _banKinh;
        }

        public HinhTron()
        {
            BanKinh = 0;
        }

        public HinhTron(double banKinh)
        {
            this.BanKinh = banKinh;
        }

        public double dienTich()
        {
            double pi = Math.PI;
            return pi * Math.Pow( this.BanKinh, 2);
        }

        public double chuVi()
        {
            double pi = Math.PI;
            return 2 * pi * this.BanKinh;
        }

    }
}