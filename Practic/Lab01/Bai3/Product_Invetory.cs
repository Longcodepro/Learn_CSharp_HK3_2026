using System;
using System.Collections;
namespace Lab01.Bai3;
class Product_Inventory
{
    private List<Product> listProduct = new List<Product>();
    public static void Main(string[] args)
    {

        Product_Inventory prSys = new Product_Inventory();

        prSys.listProduct.Add(new Product("P001", "Bút bi",        5000,  100));
        prSys.listProduct.Add(new Product("P002", "Vở kẻ ngang",   15000, 50));
        prSys.listProduct.Add(new Product("P003", "Thước kẻ",      10000, 30));
        prSys.listProduct.Add(new Product("P004", "Tẩy",           3000,  200));
        prSys.listProduct.Add(new Product("P005", "Bảng trắng",    250000, 5));
        prSys.PrintInfoProduct();

        Console.WriteLine("--------------Q1----------------");
        prSys.PrintInfoProduct(prSys.FindProductsLess(70));

        Console.WriteLine("--------------Q2----------------");
        Console.WriteLine($"Tổng giá trị của kho là: {prSys.ValueOfListProduct()}");

        Console.WriteLine("--------------Q3----------------");
        prSys.MaxPriceOfProduct();

        Console.WriteLine("--------------A1----------------");
        Inventory inventory = new Inventory();
        inventory.Add(new Product("P001", "Bút bi",      5000,  100));
        inventory.Add(new Product("P002", "Vở kẻ ngang", 15000, 50));
        inventory.Add(new Product("P003", "Thước kẻ",    10000, 30));

        foreach(Product item in inventory)
        {
            item.PrintInfo();
        }

        Console.WriteLine("--------------A2----------------");
        inventory.UpdateStock("P001", 50);
        prSys.PrintInfoProduct();

        Console.WriteLine("--------------A3----------------");
        foreach(Product item in inventory)
        {
            item.PrintInfo();
        }
    }

    public void PrintInfoProduct()
    {
        Console.WriteLine("Thông tin các sản phẩm: ");
        foreach(Product item in listProduct)
        {
            item.PrintInfo();
        }
    }

    public void PrintInfoProduct(List<Product> result)
    {
        foreach(Product item in result)
        {
            item.PrintInfo();
        }
    }

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

    public decimal ValueOfListProduct()
    {
        decimal result = 0.0m;
        foreach(Product item in listProduct)
        {
            result+=item.GetTotalValue();
        }
        return result;
    }

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

    public string Id{set; get;}
    public string Name{set; get;}
    public decimal Price{set; get;}
    public int Quantity{set; get;}

    public Product(string id, string name, decimal price, int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public decimal GetTotalValue()
    {
        return (decimal) Quantity * Price;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Id: {Id} | Name: {Name} | Price: {Price} | Quantity: {Quantity}");
    }
}

class Inventory : IEnumerable<Product>
{
    private List<Product> listProduct = new List<Product>();

    public void Add(Product product)
    {
        listProduct.Add(product);
    }

    public IEnumerator<Product> GetEnumerator()
    {
        return listProduct.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

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
