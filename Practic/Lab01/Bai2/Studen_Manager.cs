using System;
namespace Lab01.Bai2;

class Student_Manager
{
    private Dictionary<string, Student> dicStudent = new Dictionary<string, Student>();

    public static void Main(string[] args)
    {

        Student_Manager stSys = new Student_Manager();

        stSys.dicStudent.Add("Nguyen Van A", new Student("HS001", "Nguyen Van A", 4));
        stSys.dicStudent.Add("Nguyen Van B", new Student("HS002", "Nguyen Van B", 7));
        stSys.dicStudent.Add("Nguyen Van C", new Student("HS003", "Nguyen Van C", 8));

        stSys.PrintInfoStudent();

        Console.WriteLine("--------------Q1----------------");
        stSys.AddStudentSafe(new Student("HS004", "Nguyen Van D", 10 ));
        stSys.PrintInfoStudent();

        Console.WriteLine("--------------Q2----------------");
        stSys.FindStudentMaxPoint();

        Console.WriteLine("--------------Q3----------------");
        stSys.PrintInfoStudent(stSys.TransferDicToList());

        Console.WriteLine("--------------A1----------------");
        Repository<string, Student> repoStudent =  new Repository<string, Student>();
        repoStudent.Add("Nguyen Van A", new Student("HS001", "Nguyen Van A", 8));
        repoStudent.Add("Nguyen Van B", new Student("HS002", "Nguyen Van B", 8));
        repoStudent.Add("Nguyen Van C", new Student("HS003", "Nguyen Van C", 8));
        Student result = repoStudent.GetValueByKey("Nguyen Van");
        repoStudent.PrintRepo();

        Console.WriteLine("--------------A2----------------");
        result = stSys["Nguyen Va"];
        if( result != null) result.PrintInfo();

        Console.WriteLine("--------------A3----------------");
        stSys.PrintBetterOrEqualsPoint(7.0f);
    }

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

        Console.WriteLine("Thông tin sinh viên có điểm cao nhất là: ");
        maxPoint.PrintInfo();
    }

    public List<Student> TransferDicToList()
    {
        List<Student> result = new List<Student>();
        foreach(KeyValuePair<string, Student> item in dicStudent)
        {
            result.Add(item.Value);
        }
        return result;
    }

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

    public string Id{set; get;}
    public string Name{set; get;}
    public float Point{set; get;}

    public Student(string id, string name, float point)
    {
        Id = id;
        Name = name;
        Point = point;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Id: {Id} | Name: {Name} | Point: {Point}");
    }
}

class Repository<TKey, TValue> where TValue : IPrintable
{
    private Dictionary<TKey, TValue> _data = new Dictionary<TKey, TValue>();

    public void Add(TKey key, TValue value)
    {
        if( FindKey(key) )
        {
            Console.WriteLine($"[ERROR] Key {key} đã tồn tại");
        }
        else _data.Add(key, value);
    }

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

    public TValue GetValueByKey(TKey key)
    {
        if( !FindKey(key) )
        {
            Console.WriteLine($"[ERROR] Key {key} không tồn tại");
            return default;
        }
        return _data[key];
    }

    public Dictionary<TKey, TValue> getAll()
    {
        return _data;
    }

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

    public void PrintRepo()
    {
        foreach(KeyValuePair<TKey, TValue> item in _data)
        {
            Console.Write($"Key: {item.Key}, Value: ");
            item.Value.PrintInfo();
        }
    }
}

interface IPrintable
{
    public void PrintInfo();
}
