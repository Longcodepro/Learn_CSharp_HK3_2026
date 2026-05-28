using System;
using System.Collections;
namespace Lab05.Bai3;
class Product_Inventory
{
    private List<Product> listProduct = new List<Product>();
    public static void Main(string[] args)
    {
        // tạo object quản lý sản phẩm
        Product_Inventory prSys = new Product_Inventory();

        // thêm sản phẩm
        prSys.listProduct.Add(new Product("P001", "Bút bi",        5000,  100));
        prSys.listProduct.Add(new Product("P002", "Vở kẻ ngang",   15000, 50));
        prSys.listProduct.Add(new Product("P003", "Thước kẻ",      10000, 30));
        prSys.listProduct.Add(new Product("P004", "Tẩy",           3000,  200));
        prSys.listProduct.Add(new Product("P005", "Bảng trắng",    250000, 5)); 
        prSys.PrintInfoProduct();

        // check Q1
        Console.WriteLine("--------------Q1----------------");
        prSys.PrintInfoProduct(prSys.FindProductsLess(70));

        // check Q2
        Console.WriteLine("--------------Q2----------------");
        Console.WriteLine($"Tổng giá trị của kho là: {prSys.ValueOfListProduct()}");

        // check Q3
        Console.WriteLine("--------------Q3----------------");
        prSys.MaxPriceOfProduct();

        // check A1
        Console.WriteLine("--------------A1----------------");
        Inventory inventory = new Inventory();
        inventory.Add(new Product("P001", "Bút bi",      5000,  100));
        inventory.Add(new Product("P002", "Vở kẻ ngang", 15000, 50));
        inventory.Add(new Product("P003", "Thước kẻ",    10000, 30));

        //duyệt bằng foreach được vì đã implement IEnumerable
        foreach(Product item in inventory)
        {
            item.PrintInfo();
        }

        // check A2
        Console.WriteLine("--------------A2----------------");
        inventory.UpdateStock("P001", 50);
        prSys.PrintInfoProduct();

        // check A3
        // check A3
        Console.WriteLine("--------------A3----------------");
        foreach(Product item in inventory)
        {
            item.PrintInfo();
        }
    }       

    // [A3] method in ra danh sách các sản phẩm
    public void PrintInfoProduct()
    {
        Console.WriteLine("Thông tin các sản phẩm: ");
        foreach(Product item in listProduct)
        {
            item.PrintInfo();
        }
    }

    // method nạp chồng in ra danh sách các sản phẩm của một list
    public void PrintInfoProduct(List<Product> result)
    {
        foreach(Product item in result)
        {
            item.PrintInfo();
        }
    }
    

    // [Q1] tìm các sản phẩm có số lượng tồn kho thấp hơn ngưỡng cho phép
    public List<Product> FindProductsLess(int x)
    {
        Console.WriteLine($"Thông tin các sản phẩm có số lượng nhỏ hơn {x}: ");
        List<Product> result = new List<Product>();
        foreach(Product item in listProduct)
        {
            if( item.Quantity < x)
            {
                result.Add(item);
            }
        }
        return result;
    }

    // [Q2] Tính tổng giá trị của kho
    public decimal ValueOfListProduct()
    {
        decimal result = 0.0m;
        foreach(Product item in listProduct)
        {
            result+=item.GetTotalValue();
        }
        return result;
    }

    // [Q3] Tìm sản phẩm có giá trị cao nhất
    public void MaxPriceOfProduct()
    {
        Product max = null;
        foreach(Product item in listProduct)
        {
            if(max == null || item.Price > max.Price)
            {
                max = item;
            }
        }
        Console.Write("Sản phẩm có giá trị cao nhất là: ");
        max.PrintInfo();
    }
}

class Product
{
    // PROPERTY
    public string Id{set; get;}
    public string Name{set; get;}
    public decimal Price{set; get;}
    public int Quantity{set; get;}

    // CONSTRUCTOR
    public Product(string id, string name, decimal price, int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    // METHOD
    // tính giá trị của một sản phẩm 
    public decimal GetTotalValue()
    {
        return (decimal) Quantity * Price;
    }

    // in thông tin của một sản phẩm 
    public void PrintInfo()
    {
        Console.WriteLine($"Id: {Id} | Name: {Name} | Price: {Price} | Quantity: {Quantity}");
    }
}

// [A1]
class Inventory : IEnumerable<Product>
{
    private List<Product> listProduct = new List<Product>();

    // thêm sản phẩm 
    public void Add(Product product)
    {
        listProduct.Add(product);
    }

    // implement 
    public IEnumerator<Product> GetEnumerator()
    {
        return listProduct.GetEnumerator();
    }

    // implement - tương thích phiên bản cũ
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // [A2]
    public void UpdateStock(string id, int newQuantity)
    {
        foreach(Product item in listProduct)
        {
            if(item.Id == id)
            {
                item.Quantity = newQuantity;
                Console.WriteLine($"[NOTICE] Đã cập nhật số lượng {item.Name} thành {newQuantity}");
                return;
            }
        }
        Console.WriteLine($"[ERROR] Không tìm thấy sản phẩm có Id: {id}");
    }
}