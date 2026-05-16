using System;

namespace Basic.Inheritance
{
    class Bai1
    {
        public static void Main(String[] args)
        {
            NhanVien nvA = new NhanVien("001", "Nguyen Van A", 0.5);
            NhanVien nvB = new NhanVien();
            nvB.input();

            nvA.output();
            nvB.output();
        }
    }

    class NhanVien
    {
        protected const double _luongCoBan = 1150;
        protected string _maNv;
        public string maNv
        {
            set{ _maNv = (int.Parse(value)>0) ? value : "0"; }
            get{return _maNv; }
        }
        protected string _tenNv;
        public string tenNv
        {
            set{ _tenNv = value; }
            get{ return _tenNv; }
        }
        protected int _namVaoLam;
        public int namVaoLam
        {
            set{ _namVaoLam = (value>0) ? value : 0; }
            get{ return _namVaoLam; }
        }
        protected double _heSoLuong;
        public double heSoLuong
        {
            set{ _heSoLuong = (value>0) ? value : 0; }
            get{ return _heSoLuong; }
        }
        protected int _soNgayNghi;
        public int soNgayNghi
        {
            set{ _soNgayNghi = (value >0) ? value : 0; }
            get{ return _soNgayNghi; }
        }

        // Constructor
        public NhanVien()
        {
            DateTime d = DateTime.Now;
            _soNgayNghi = 0;
            _namVaoLam = d.Year;
            _maNv = "null";
            _tenNv = "null";
            _heSoLuong = 0.0;
        }
        public NhanVien(string maNv, string tenNv, double heSoLuong)
        { 
            DateTime d = DateTime.Now;
            _maNv = maNv;
            _tenNv = tenNv;
            _namVaoLam = d.Year;
            _heSoLuong = heSoLuong;
            _soNgayNghi = 0;
        }

        // method tính phụ cấp thâm niên
        public double tinhPhuCap()
        {
            DateTime d = DateTime.Now;
            int dateNow = d.Year;
            return ((dateNow - _namVaoLam) * _luongCoBan) / 100;
        }        

        // method xét thi đua sinh viên
        public char xetThiDua()
        {
            if(_soNgayNghi <= 1) return 'A';
            else if(_soNgayNghi <= 3) return 'B';
            else return 'C';
        }

        // method tính hệ số thi đua
        public double heSoThiDua()
        {
            char result = this.xetThiDua();
            switch(result)
            {
                case 'A': 
                    return 1.0;
                case 'B':
                    return 0.75;
                default:
                    return 0.5;
            }
        }
        // method tính lương nhân viên
        public double nhanVien()
        {
            return  _luongCoBan * this.heSoThiDua() * _heSoLuong + this.tinhPhuCap();
        }

        // method nhập thông tin nhân viên
        public void input()
        {
            Console.Write("Nhập id nhân viên: ");
            _maNv = Console.ReadLine() ?? "";

            Console.Write("Nhập vào tên nhân viên: ");
            _tenNv = Console.ReadLine() ?? "";

            Console.Write("Nhập vào hệ số lương: ");
            _heSoLuong = double.Parse(Console.ReadLine() ?? "0.0");
        }

        // method in ra thông tin nhân viên
        public void output()
        {
            Console.WriteLine($"Mã: {_maNv} | Tên: {_tenNv} | Hệ số lương: {_heSoLuong} | " + 
            $"Năm vào làm: {_namVaoLam} | Số ngày nghỉ: {_soNgayNghi}");
        }
    }

    class CanBo : NhanVien
    {
        private string _chucVu;
        public string chucVu
        {
            set{ _chucVu = value; }
            get{ return _chucVu; }
        }

        private string _phongBan;
        public string phongBan
        { 
            set{ _phongBan = value; }
            get{ return _phongBan; }
        }

        private double _heSoCanBo;
        public double heSoCanBo
        {
            set{ _heSoCanBo = value; }
            get{ return _heSoCanBo; }
        }

        // Constructor
        public CanBo() : base()
        {
            _chucVu = "Trưởng phòng";
            _phongBan = "Phòng hành chính";
            _heSoCanBo = 5.0;
        }

        public CanBo(string maNv, string tenNv, double heSoLuong, string chucVu, string phongBan, double heSoCanBo)
        : base(maNv, tenNv, heSoLuong)
        {
            _chucVu = chucVu;
            _phongBan = phongBan;
            _heSoCanBo = heSoCanBo;
        }
    }
}