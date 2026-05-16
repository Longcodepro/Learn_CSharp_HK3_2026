// đề bài tính diện tích và chu vi hình tròn với input là giá trị của bán kính

using System;

namespace Basic.Class
{
    class Bai1
    {
        public static void Main(String[] args)
        {
            // nhập bán kính s
            Console.Write("Nhập vào bán kính hình tròn: ");
            double ban_kinh = double.Parse(Console.ReadLine() ?? "0");
            // khởi tạo đối tượng hình tròn
            HinhTron ht = new HinhTron(ban_kinh);
            // F2 dùng để lấy 2 số sau dấu phẩy
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

        // constructor
        public HinhTron()
        {
            BanKinh = 0;
        }

        public HinhTron(double banKinh)
        {
            this.BanKinh = banKinh;
        }

        // diện tích
        public double dienTich()
        {
            double pi = Math.PI;
            return pi * Math.Pow( this.BanKinh, 2);
        }

        // chu vi
        public double chuVi()
        {
            double pi = Math.PI;
            return 2 * pi * this.BanKinh;
        }

    }
}