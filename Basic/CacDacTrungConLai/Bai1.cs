using System;

namespace Basic.CacDacTrungConLai
{
    class Bai1
    {
        public static void Main(String[] args)
        {
            
        }
    }

    abstract class NhanVien
    {
       private const decimal _luongCoBan = 100000;
       private string _id {set; get;}
       private string _name {set; get;}
       private int _date {set; get;}
       private string _sex {set; get;}
       private double _heSoLuong {set; get;}
       private int _nameVaoLam {set; get;}

        // Constructor
        public NhanVien()
        {
            _id = "";
            _name = "";
            _date = 0;
            _sex = "";
            _heSoLuong = 0.0d;
            _namVaoLam = 0;
        }

        public NhanVien(string id, string name, int date, string sex, 
        double heSoLuong, int namVaoLam)
        {
            _id = id;
            _name = name;
            _date = date;
            _sex = sex;
            _heSoLuong = heSoLuong;
            _namVaoLam = namVaoLam;
        }

        // method tính thu nhập
        public  decimal thuNhap()
        {
            char loaiThiDua = this.xepLoaiDiemThiDua();
            float phanTramLuong = 0.0f;
            switch (loaiDiemThiDua)
            {
                case 'A':
                    phanTramLuong = 1.0;
                    break;
                case 'B':
                    phanTramLuong = 0.75;
                    break;
                case 'C':
                    phanTramLuong = 0.5;
                    break;
                default:
                    phanTramLuong = 0.0;
                    break;                
            }
            return (decimal) phanTramLuong * this.tinhLuong() + this.phuCapThamNien();
        }
        // method phân loại điểm thi đua
        public abstract char xepLoaiDiemThiDua();
        // method tính lương tổng
        // method tính phụ cấp thâm niên
        public abstract decimal tinhLuong();
        public decimal phuCapThamNien()
        {
            DateTime current = DateTime.Now.Year;
            int soNamLamViec = (int) current.Year - _date;
            if( soNamLamViec >=5 )
            {
                return (decimal) soNamLamViec * _luongCoBan;
            }
            return 0;
        }
    }

    class SanXuat : NhanVien
    {
        private const double _heSoPhuCapNangNhoc = 0.1;
        private int _soNgayNghi{set; get;}

        public char xepLoaiDiemThiDua()
        {
            if( _soNgayNghi <= 1) return 'A';
            else if( _soNgayNghi <= 3) return 'B';
            else if( _soNgayNghi <= 5) return 'C';
            else return 'D';
        }

        public decimal tinhLuong()
        {
            return  (decimal) _heSoLuong * _luongCoBan * (decimal) (1+_heSoPhuCapNangNhoc);
        }
    }

    class KinhDoanh : NhanVien
    {
        private decimal _doanhSoToiThieu = 111111;
        private decimal _doanhSoCuaThang{set; get;}

        public char xepLoaiDiemThiDua()
        {
            if( (double) _doanhSoCuaThang / (double) _doanhSoToiThieu >= 2.0)
            {
                return 'A';
            }
            else if( _doanhSoCuaThang > _doanhSoToiThieu )
            {
                return 'B';
            }
            else if( (double) _doanhSoCuaThang / (double) _doanhSoToiThieu >= 0.5 )
            {
                return 'C';
            }
            else return 'D';
        }

        public decimal tinhLuong()
        {
            decimal hoaHong = 0;
            if( _doanhSoCuaThang > _doanhSoToiThieu )
            {
                hoaHong = doanhSoCuaThang * 0.15;
            }
            return _heSoLuong * _luongCoBan + hoaHong;
        }
    }

    class CanBo : NhanVien
    {
        private string _chucVu {set; get;}
        private double _heSoChucVu{set; get;}

        public char xepLoaiDiemThiDua()
        {
            return 'A';
        }

        public decimal tinhLuong()
        {
            return (decimal) _heSoLuong * _luongCoBan + (decimal) (_heSoChucVu * 1100);
        }
    }
}