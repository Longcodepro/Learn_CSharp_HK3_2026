using System;
namespace Lab01.Bai1;
class Library_Manager_System
{
    private List<Book> listBook = new List<Book>();
    private Dictionary<string, int> author_Book = new Dictionary<string, int>();
    public static void Main(string[] args)
    {

        Library_Manager_System libSys = new Library_Manager_System();

        libSys.listBook.Add(new Book("Clean Code", "Robert Martin", "978-0132350884", 2008));
        libSys.listBook.Add(new Book("The Pragmatic Programmer", "David Thomas", "978-0135957059", 1999));
        libSys.listBook.Add(new Book("Design Patterns", "Gang of Four", "978-0201633610", 1994));
        libSys.listBook.Add(new Book("C++", "Robert Martin", "978-0132350889", 2002));

        Console.WriteLine("--------------Print listBook------------");
        libSys.PrintListBook();

        Console.WriteLine("--------------Kiểm tra Q1------------");
        try
        {
            libSys.listBook.Add(new Book("Đại số tuyến tính", "XXXX", "1111111", 950));
        }
        catch(Exception e)
        {
            Console.WriteLine($"[ERROR] {e.Message}");
        }
        libSys.PrintListBook();

        Console.WriteLine("--------------Kiểm tra Q3 (Equals so sánh theo ISBN)------------");
        Book newBook = new Book("Xác suất thống kê", "TTB", "978-0132350884", 1100);
        if(libSys.listBook.Contains(newBook))
        {
            Console.WriteLine("[ERROR] ISBN của mã sách mới này đã có trong danh sách");
        }
        else
        {
            libSys.listBook.Add(newBook);
            Console.WriteLine("Thêm cuốn sách mới thành công");
        }

        Console.WriteLine("--------------Kiểm tra A1(Implement CompareTo)------------");
        libSys.listBook.Sort();
        libSys.PrintListBook();

        Console.WriteLine("--------------Kiểm tra A2(Lấy các cuốn sách sau năm year)------------");
        libSys.PrintListBook(libSys.GetBookAfterYear(2000));

        Console.WriteLine("--------------Kiểm tra A3(Đếm số sách của từng tác giả)------------");
        libSys.author_Book = libSys.CountBookByAuthor();
        libSys. PrintResultA3();
    }

    public void PrintListBook()
    {
        foreach(Book item in listBook )
        {
            Console.WriteLine($"Title: {item.Title} | Author: {item.Author} | ISBN: {item.ISBN} | Year Published: {item.YearPublished}");
        }
    }

    public void PrintListBook(List<Book> result)
    {
        foreach(Book item in result )
        {
            Console.WriteLine($"Title: {item.Title} | Author: {item.Author} | ISBN: {item.ISBN} | Year Published: {item.YearPublished}");
        }
    }

    public List<Book> GetBookAfterYear(int year)
    {
        List<Book> result = new List<Book>();
        foreach(Book item in listBook)
        {
            if(item. YearPublished <= year)
            {
                result.Add(item);
            }
        }
        return result;
    }

    public Dictionary<string, int> CountBookByAuthor()
    {
        Dictionary<string, int> result = new Dictionary<string, int>();
        foreach(Book item in listBook)
        {
            if(result.ContainsKey(item.Author))
            {
                result[item.Author]++;
            }
            else
            {
                result.Add(item.Author, 1);
            }
        }
        return result;
    }

    public void PrintResultA3()
    {
        foreach(KeyValuePair<string, int> item in author_Book)
        {
            Console.WriteLine($"{item.Key} : {item.Value}");
        }
    }

}

class Book : IComparable<Book>
{

    private string _title;
    public string Title
    {
        set{ _title = value; }
        get{ return _title; }
    }

    private string _author;
    public string Author
    {
        set{ _author = value; }
        get{ return _author; }
    }

    private string _isbn;
    public string ISBN
    {
        set{ _isbn = value; }
        get{ return _isbn; }
    }

    private int _yearPublished;
    public int YearPublished
    {
        set
        {
            int year = DateTime.Now.Year;
            if(value < 1000 || value > year)
            {
                throw new Exception("Năm phải là từ 1000 đến hiện tại");
            }
            _yearPublished = value;
        }
        get{ return _yearPublished; }
    }

    public Book(string title, string author, string isbn, int yearPublished)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        YearPublished = yearPublished;
    }

    public Book()
    {
        Title = "";
        Author = "";
        ISBN = "";
        YearPublished = 0;
    }

    public Book(string title, string isbn)
    {
        Title = title;
        Author = "";
        ISBN = isbn;
        YearPublished = 0;
    }

    public override bool Equals(object obj)
    {
        if(obj == null) return false;
        if( !(obj is Book) ) return false;
        Book other = (Book)obj;
        return ISBN == other.ISBN;
    }

    public override int GetHashCode()
    {
        return ISBN?.GetHashCode() ?? 0;
    }

    public int CompareTo(Book other)
    {
        if (other == null) return 1;
        return this.YearPublished - other.YearPublished;
    }
}
