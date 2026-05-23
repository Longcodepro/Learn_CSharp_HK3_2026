// using System;
// using System.Globalization;

// namespace Lab04;

// class ChuyenTienNganHang
// {
    
//     public static void Main(string[] args)
//     {
//         Account A = new Account("Nguyễn Văn A", 1000000, "KH001");
//         Account B = new Account("Nguyễn Văn B", 100000, "KH002");

//     }
// }

// abstract class Account
// {
//     // PROPERTY
//     public string Name{set; get;}
//     public decimal _soDu;
//     public decimal SoDu
//     {
//         get{ return _soDu; }
//         set
//         {
//             if(value >= 0)
//             {
//                 _soDu = value;
//             }
//             else _soDu = 0m;
//         }
//     }

//     public string Id{set; get;}
//     public abstract decimal PhiGiaoDich{ get;}
//     public abstract decimal HanMucGiaoDich{ get;}
//     private string maKhau{get;}

//     public List<string> ThongBao{set; get;} =  new List<string>();
//     // CONSTRUCTOR
//     public Account()
//     {
//         Name = "Chưa có tên";
//         SoDu = 0m;
//         Id = "Chưa có mã";
//     }
//     public Account(string name, decimal soDu, string id)
//     {
//         Name = name;
//         SoDu = soDu;
//         Id = id;
//     }

//     // METHOD
//     // in thông tin tài khoản
//     public abstract void printInfo();
//     // biến động số dư
//     public void nhanTien(decimal soTien, Account nguoiGui)
//     {
//         _soDu += soTien;
//         Console.WriteLine($"[THÔNG BÁO] Biến động số dư tài khoản {Name}: nhận +{soTien:N0} VND từ tài khoản {nguoiGui.Name}. Số dư hiện tại là {SoDu:N0} VND.");
//     }
//     public abstract bool chuyenTien(decimal soTien, Account nguoiNhan)
//     {
//         if (_soDu < soTien )
//         {
//             Console.WriteLine($"[THÔNG BÁO] Chuyển tiền không thành công, số dư không đủ !!!");
//             return false;
//         }
//         else if(soTien > HanMucGiaoDich)
//         {
//             Console.WriteLine($"[THÔNG BÁO] Hạn mức giao dịch không được vượt quá {HanMucGiaoDich} VND");
//         }
//         else
//         {
//             _soDu -= soTien;
//             Console.WriteLine($"[THÔNG BÁO] Biến động số dư tài khoản {Name}: gửi -{soTien:N0} VND đến tài khoản {nguoiNhan.Name}. Số dư hiện tại là {SoDu:N0} VND.");
//             return true;
//         }
//     }

//     // private thông tin ngày giờ 
//     protected static string Time()
//     {
//         DateTime localTime = DateTime.Now;
//         return localTime.ToString("dd/MM/yyyy HH:mm:ss");
//     }

//     // thêm thông báo
//     protected void addThongBao(string noiDung)
//     {
//         if(string.IsNullOrEmpty(noiDung))
//         {
//             noiDung+=$"[Time()]";
//             ThongBao.Add(noiDung);
//         }
//     }

//     // đọc thông báo
//     protected void xemThongBao()
//     {
//         foreach(string noiDung in ThongBao)
//         {
//             Console.WriteLine($"{noiDung}\n");
//         }
//     }

//     // menu
//     private static void menu()
//     {
//         Console.WriteLine("[1]. Xem thông tin cá nhân\n"
//         + "[2]. Xem thông báo"
//         + "[3]. Chuyển tiền)"
//         + "[4]. Đăng xuất");
//     }

//     // thực thi menu
//     public void chayMenu()
//     {
//         int choose = 5;
//         while(choose != 4)
//         {
//             menu();
//             Console.Write("Lựa chọn của bạn là: ");
//             Console.ReadLine(choose);
//             switch(choose)
//             {
//                 case 1: 
//                     printInfo();
//                     break;
//                 case 2:
//                     xemThongBao();
//                     break;
//                 case 3:

//                     break;
//             }
//         }
//     }

//     // thực hiện chuyển tiền
//     public void thucHienChuyenTien()
//     {
        
//     }
// }

// class ChuyenTien
// {
//     // PROPERTIES
//     public decimal _soTien;
//     public decimal SoTien
//     {
//         get{ return _soTien;}
//         set
//         {
//             if( value < 10000)
//             {
//                 Console.WriteLine("[THÔNG BÁO] Số tiền thanh toán không được nhỏ hơn 10.000 VND");
//             }
//             else _soTien = value;
//         }
//     }

//     private string _noiDungChuyenTien;
//     public string NoiDungChuyenTien
//     { 
//         get{ return _noiDungChuyenTien; }
//         set
//         {
//             if( string.IsNullOrEmpty(value) )
//             {
//                 DateTime localTime = DateTime.Now;
//                 _noiDungChuyenTien = localTime.ToString("dd/MM/yyyy HH:mm:ss");
//             }
//             else
//             {
//                 _noiDungChuyenTien = value;
//             }
//         }
//     }

//     // CONSTRUTOR
//     public ChuyenTien(decimal soTien, string noiDung)
//     {
//         SoTien = soTien;
//         NoiDungChuyenTien = noiDung;
//     }

//     // METHOD
//     //  thực hiện giao dịch
//     public void thucHienGiaoDich(Account nguoiChuyen, Account nguoiNhan)
//     {
//         if( nguoiChuyen.chuyenTien(SoTien, nguoiNhan) )
//         {
//             nguoiNhan.nhanTien(SoTien, nguoiChuyen);
//             Console.WriteLine("[THÔNG BÁO] Giao dịch thực hiện thành công!!!");
//         }
//     }
// }

// class AccountVIP : Account
// {
//     public override decimal PhiGiaoDich => 2000m;
//     public override decimal HanMucGiaoDich => 100000000000m;
//     public string CapDoVIP{get;}
//     // CONSTRUCTOR
//     public AccountVIP(string name, decimal soDu, string id) : base(name, soDu, id)
//     {
        
//     }

//     // METHOD
//     // in thông tin
//     public override void printInfo()
//     {
//         Console.WriteLine($"[VIP] ID: {Id} | Name: {Name} | Số dư: {SoDu}");
//     }
    
//     // phân loại mức độ VIP
//     private void phanLoaiMucDoVIP()
//     {
//         if(soDu >= 10000000000) CapDoVIP = "Cấp A";
//         else if(soDu >= 5000000000 && soDu <= 9999999999) CapDoVIP = "Cấp B";
//         else CapDoVIP = "Cấp C";
//     }

//     // cảnh báo hạn mức thấp
//     private void canhBaoHanMuc()
//     {
//         if(soDu <= 100000000)
//         {
//             Console.WriteLine("[CẢNH BÁO] Số dư hiện tại thấp!!!");
//         }
//         else if( soDu <= 1000000)
//         {
//             Console.WriteLine("[CẢNH BÁO] Số dư rất thấp sắp không đủ để duy trì tài khoản!!!");
//         }
//         else
//         {
//             Console.WriteLine("[CẢNH BÁO] Tài khoản của bạn sẽ dừng hoạt động vì hết phí duy trì");
//         }
//     }
// }

// class AccountNormal : Account
// {
//     public override decimal PhiGiaoDich => 5000m;
//     public override decimal HanMucGiaoDich => 100000000m;
//     //  CONSTRUCTOR
//     public AccountNormal(string name, decimal soDu, string id) : base(name, soDu, id)
//     {
        
//     }

//     // METHOD
//     // in thông tin
//     public override void printInfo()
//     {
//         Console.WriteLine($"[NORMAL] ID: {Id} | Name: {Name} | Số dư: {SoDu}");
//     }
// }

// class AccountSavings : Account
// {
//     public override decimal PhiGiaoDich => 0m;
//     public decimal LaiSuat{get; } = 0.5m;

//     // CONSTRUCTOR
//     public AccountSavigs(string name, decimal soDu, string id) : base(name, soDu, id)
//     {
        
//     }

//     // METHOD
//     // in thông tin
//     public override void printInfo()
//     {
//         Console.WriteLine($"[Savings] ID: {Id} | Name: {Name} | Số dư: {SoDu} | Lãi suất: {LaiSuat}%/năm");
//     }
//     // tính tiền lãi 
//     public void tienLai()
//     {
//         SoDu+= SoDu * LaiSuat;
//         Console.WriteLine($"Tiền lãi của bạn năm nay là {SoDu * LaiSuat}");
//     }
// }

// class dangNhap
// {
//     private string name{get;}
//     private string password{get;}


// }

