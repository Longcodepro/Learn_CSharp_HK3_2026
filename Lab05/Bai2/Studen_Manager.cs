using System;
namespace Lab05.Bai2;

class Student_Manager
{
    private Dictionary<string, Student> dicStudent = new Dictionary<string, Student>();
    
    public static void Main(string[] args)
    {
        // tạo đối tượng hệ thống quản lý student
        Student_Manager stSys = new Student_Manager();

        // Add dữ liệu
        stSys.dicStudent.Add("Nguyen Van A", new Student("HS001", "Nguyen Van A", 4));
        stSys.dicStudent.Add("Nguyen Van B", new Student("HS002", "Nguyen Van B", 7));   
        stSys.dicStudent.Add("Nguyen Van C", new Student("HS003", "Nguyen Van C", 8));

        // in thông tin các student
        stSys.PrintInfoStudent();

        // check Q1
        Console.WriteLine("--------------Q1----------------");
        stSys.AddStudentSafe(new Student("HS004", "Nguyen Van D", 10 ));
        stSys.PrintInfoStudent();

        // check Q2
        Console.WriteLine("--------------Q2----------------");
        stSys.FindStudentMaxPoint();        

        // check Q3
        Console.WriteLine("--------------Q3----------------");
        stSys.PrintInfoStudent(stSys.TransferDicToList());

        // check A1
        Console.WriteLine("--------------A1----------------");
        Repository<string, Student> repoStudent =  new Repository<string, Student>();
        repoStudent.Add("Nguyen Van A", new Student("HS001", "Nguyen Van A", 8));
        repoStudent.Add("Nguyen Van B", new Student("HS002", "Nguyen Van B", 8));
        repoStudent.Add("Nguyen Van C", new Student("HS003", "Nguyen Van C", 8));
        Student result = repoStudent.GetValueByKey("Nguyen Van");
        repoStudent.PrintRepo();

        // check A2
        Console.WriteLine("--------------A2----------------");
        result = stSys["Nguyen Va"];
        if( result != null) result.PrintInfo();

        // check A3
        Console.WriteLine("--------------A3----------------");
        stSys.PrintBetterOrEqualsPoint(7.0f);
    }

    // in thông tin các student
    public void PrintInfoStudent()
    {
        Console.WriteLine("[Thông tin các student từ Dictionary]");
        foreach(KeyValuePair<string, Student> item in dicStudent)
        {
            Console.Write($"Key: {item.Key}, Value: ");
            item.Value.PrintInfo();
        }
    }

    public void PrintInfoStudent(List<Student> listStudent)
    {
        Console.WriteLine("[Thông tin các student từ List]");
        foreach(Student item in listStudent)
        {
            item.PrintInfo();
        }
    }

    // [Q1] method add một student mới tránh bị trùng key
    public void AddStudentSafe(Student newStudent)
    {
        if( dicStudent.ContainsKey(newStudent.Name) )
        {
            Console.WriteLine($"[ERROR] Key: {newStudent.Name} đã bị trùng");
        }
        else
        {
            Console.WriteLine("[NOTICE] Đã add thành công một student mới");
            dicStudent.Add(newStudent.Name, newStudent);
        }
    }

    //[Q2] method tìm sinh viên có điểm cao nhất
    public void FindStudentMaxPoint()
    {
        Student maxPoint = null;
        foreach(KeyValuePair<string, Student> item in dicStudent)
        {
            if(maxPoint == null || item.Value.Point > maxPoint.Point)
            {
                maxPoint = item.Value;
            }
        }

        // in kết quả
        Console.WriteLine("Thông tin sinh viên có điểm cao nhất là: ");
        maxPoint.PrintInfo();
    }

    //[Q3] method chuyển từ dic sang list
    public List<Student> TransferDicToList()
    {
        List<Student> result = new List<Student>();
        foreach(KeyValuePair<string, Student> item in dicStudent)
        {
            result.Add(item.Value);
        }
        return result;
    }

    // [A2] indexer
    public Student this[string name]
    {
        get
        {
            if(dicStudent.ContainsKey(name))
                return dicStudent[name];
            Console.WriteLine($"[ERROR] Không có key này");
            return null;
        }
    }

    // [A3] in sinh viên có điểm >= Point
    public void PrintBetterOrEqualsPoint(float Point)
    {
        Console.WriteLine($"Danh sách các sinh viên có điểm lớn hơn hoặc bằng {Point}");
        foreach(KeyValuePair<string, Student> item in dicStudent)
        {
            if(item.Value.Point >= Point)
            {
                item.Value.PrintInfo();
            }
        }
    }
}

class Student : IPrintable
{
    // PROPERTY
    public string Id{set; get;}
    public string Name{set; get;}
    public float Point{set; get;}

    // CONSTRUCTOR
    public Student(string id, string name, float point)
    {
        Id = id;
        Name = name;
        Point = point;
    }

    // IN THÔNG TIN STUDENT
    public void PrintInfo()
    {
        Console.WriteLine($"Id: {Id} | Name: {Name} | Point: {Point}");
    }
}

// Q1 Generic 
class Repository<TKey, TValue> where TValue : IPrintable // => miễn class nào mà impletment interface này thì được
{
    private Dictionary<TKey, TValue> _data = new Dictionary<TKey, TValue>();

    // method thêm
    public void Add(TKey key, TValue value)
    {
        if( FindKey(key) )
        {
            Console.WriteLine($"[ERROR] Key {key} đã tồn tại");
        }
        else _data.Add(key, value);
    }

    // method remove
    public void Remove(TKey key)
    {
        if( FindKey(key) )
        {
            _data.Remove(key);
        }
        else
        {
            Console.WriteLine($"[ERROR] Key {key} không tồn tại");
        }
    }

    // method lấy value bằng key
    public TValue GetValueByKey(TKey key)
    {
        if( !FindKey(key) )
        {
            Console.WriteLine($"[ERROR] Key {key} không tồn tại");
            return default;
        }
        return _data[key];
    }

    // method getAll
    public Dictionary<TKey, TValue> getAll()
    {
        return _data;
    }

    // method kiểm tra sự tồn tại của một key
    public bool FindKey(TKey key)
    {
        foreach(KeyValuePair<TKey, TValue> item in _data)
        {
            if(key.Equals(item.Key))
            {
                return true;
            }
        }
        return false;
    }

    // method in 
    public void PrintRepo()
    {
        foreach(KeyValuePair<TKey, TValue> item in _data)
        {
            Console.Write($"Key: {item.Key}, Value: ");
            item.Value.PrintInfo();
        }
    }
}

// interface in thông tin của một object => tác dụng: để  ràng buộc TValue của class Repository
interface IPrintable
{
    public void PrintInfo();
}