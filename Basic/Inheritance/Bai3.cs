using System;

namespace Basic.Inheritance
{
    class Bai3
    {
        public static void Main(String[] args)
        {
            People p1 = new People("Long", "25/08/2007", "bede");
            p1.xuat();

            People p2 = new SinhVien("Long1", "12312", "nu", "110", "da");
            p2.xuat();

            SinhVien sv = new SinhVien("Long2", "12312", "nu", "110", "cao đẳng");
            sv.xuat();
            sv.tongHocPhi();
        }
    }

    class People
    {
        public string name {set; get;}
        private DateTime _date;
        public String date
        {
            get
            {
                return _date.ToString("yyyy/MM/dd");
            }
            set
            {
                // kiểm tra 
                if( DateTime.TryParse( value, out DateTime result))
                {
                    _date = result;
                }
                else
                {
                    _date = DateTime.MinValue;
                }
            }
        }

        private string _sex = "";
        public string sex
        {
            set
            {
                if( "nam".Equals(value) || "nữ".Equals(value) )
                {
                    _sex = value;
                }
                else
                {
                    _sex = "nam";
                }
            }
            get
            {
                return _sex;
            }
        }

        // Constructor
        public People()
        {
            name = "";
            date = "";
            sex = "";
        }

        public People(string name, string date, string sex)
        {
            this.name = name;
            this.date = date;
            this.sex = sex;
        }

        // method
        public virtual void xuat()
        {
            Console.WriteLine($"Name: {name} | Date: {date} | Sex: {sex}");
        }
    }

    class SinhVien : People
    {
        private string _id = "";
        public string id
        {
            get
            {
                return _id;
            }
            set
            {
                if( int.Parse(value) < 0 )
                {
                    _id = "";
                }
                else
                {
                    _id = value;
                }
            }
        }

        private readonly string[] listHeDaoTao = {"đại học", "cao đẳng", "cao đẳng nghề"};
        private readonly int[] listSoTinChi = {150, 100, 130};
        private readonly decimal[] listHocPhi = {200000, 150000, 120000};
        private string _heDaoTao = "";
        public string heDaoTao
        {
            get
            {
                return _heDaoTao;
            }
            set
            {
                if( Array.IndexOf(listHeDaoTao, value) != -1 )
                {
                    _heDaoTao = value;
                    _soTinChi = listSoTinChi[Array.IndexOf(listHeDaoTao, value)];
                }
                else
                {
                    _heDaoTao = "đại học";
                    _soTinChi = 150;
                }
            }
        }

        private int _soTinChi = 0;
        public int soTinChi
        {
            get
            {
                return _soTinChi;
            }
            set
            {
                if( value < 0 )
                {
                    _soTinChi = 0;
                }
                else
                {
                    _soTinChi = value;
                }
            }
        }

        // Constructor
        public SinhVien() : base()
        {
            id = "";
            heDaoTao = "";
            soTinChi = 0;
        }

        public SinhVien(string name, string date, string sex, string id,
        string heDaoTao) : base(name, date, sex)
        {
            this.id = id;
            this.heDaoTao = heDaoTao;
        }

        // method
        public override void xuat()
        {
            base.xuat();
            Console.WriteLine($"Id: {id} | Hệ đào tạo: {heDaoTao} | Số tín chỉ: {soTinChi}");
        }

        public void tongHocPhi()
        {
            Console.WriteLine($"Tổng học phí là: {listHocPhi[Array.IndexOf(listHeDaoTao, heDaoTao)] * (decimal) soTinChi}");
        }
    }
}