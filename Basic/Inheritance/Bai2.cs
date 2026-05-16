using System;

namespace Basic.Inheritance
{
    class Bai2
    {
        public static void Main(String[] args)
        {
            hangHoa h1 = new nuocGiaiKhat("HH00A", "Sting", "abc", 10, 10000);
            h1.xuat();
            nuocGiaiKhat h2 = new nuocGiaiKhat("HH002", "C2", "chai", 11, 12000);
            h2.xuat();
            Console.WriteLine(h2.tinhTongTien());
        }
    }

    class hangHoa
    {
        private string _tenHang = "";
        public string tenHang
        {
            set{ _tenHang = value;}
            get{ return _tenHang; }
        }

        private string _maHang = "";
        public string maHang
        {
            set
            {
                if(checkMaHangHoa(value))
                {
                    _maHang = value;
                }
                else
                {
                    _maHang = "HH001";
                }
            }
            get{ return _maHang; }
        }

        // Constructor
        public hangHoa()
        {
            tenHang = "";
            maHang = "";
        }        
        public hangHoa(string maHang, string tenHang)
        {
            this.maHang = maHang;
            this.tenHang = tenHang;
        }

        // method
        private bool checkMaHangHoa(string maHang)
        {
            string phanSo = maHang.Substring(2);
            if( maHang[0] == 'H' && maHang[1] == 'H' && int.TryParse(phanSo, out int result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public virtual void xuat()
        {
            Console.WriteLine($"Mã: {maHang} | Tên hình: {tenHang}");
        }
    }

    class nuocGiaiKhat : hangHoa
    {
        private string[] listDonViTinh = {"két", "thùng", "chai", "lon"};
        
        private string _donViTinh = "";
        public string donViTinh
        {
            set
            {
                if( listDonViTinh.Any(x => x == value) )
                {
                    _donViTinh = value;
                }
                else
                {
                    _donViTinh = "két";
                }
            }
            get{ return _donViTinh; }
        }
 
        private int _soLuong;
        public int soLuong
        {
            set
            {
                if( value < 0 )
                {
                    _soLuong = 0;
                }
                _soLuong = value;
            }
            get{ return _soLuong;}
        }

        private double _donGia;
        public double donGia
        {
            set
            {
                if( value < 0.0)
                {
                    _donGia = 0.0;
                }
                _donGia = value;
            }
            get{ return _donGia; }
        }

        // Constructor
        public nuocGiaiKhat() : base()
        {
            donViTinh = "";
            donGia = 0.0;
            soLuong = 0;
        }

        public nuocGiaiKhat(string maHang, string tenHang, string donViTinh, int soLuong, double donGia) 
        : base(maHang, tenHang)
        {
            this.donViTinh = donViTinh;
            this.soLuong = soLuong;
            this.donGia = donGia;
        }

        // method
        public override void xuat()
        {
            base.xuat(); 
            Console.WriteLine($"Đơn vị tính: {donViTinh} | Số lượng: {soLuong} | Đơn gía: {donGia}");
        }

        public decimal tinhTongTien()
        {
            switch (donViTinh)
            {
                case "két": case "thùng":
                    return (decimal)soLuong * (decimal)donGia;
                case "chai":
                    return (decimal)soLuong * (decimal)donGia / 20.0m;
                case "lon":
                    return (decimal)soLuong * (decimal)donGia/24.0m;
                default:
                    Console.WriteLine($"Không có đơn vị tính này: {donViTinh}");
                    return 0;
            }
        }
    }
}