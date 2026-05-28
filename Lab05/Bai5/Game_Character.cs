using System;
namespace Lab05.Bai5;

class Game_Character
{
    public static void Main(string[] args)
    {
        Character char1 = new Character("Warrior", 10, 100);
        Character char2 = new Character("Mage", 5, 80);
        Character char3 = new Character("Archer", 8, 90);
        char1.PrintInfo();

        // check Q1
        Console.WriteLine("--------------Q1----------------");
        char1.AddItem("Sword", 1);
        char1.AddItem("Shield", 2);
        char1.CheckItem("Sword");   // có
        char1.CheckItem("Potion");  // không có

        // check Q2
        Console.WriteLine("--------------Q2----------------");
        char1.LearnSkill("Fire Slash");
        char1.LearnSkill("Ice Arrow");
        char1.LearnSkill("Fire Slash"); // trùng → lỗi

        // check Q3
        Console.WriteLine("--------------Q3----------------");
        char1.PrintInfo();
        char1.LevelUp();
        char1.PrintInfo();

        // check A1
        Console.WriteLine("--------------A1----------------");
        List<Character> listChar = new List<Character> { char1, char2, char3 };
        listChar.Sort(new CharacterLevelComparer());
        foreach(Character c in listChar)
        {
            c.PrintInfo();
        }

        // check A2
        Console.WriteLine("--------------A2----------------");
        Character char4 = char1.DeepCopy();
        char4.LevelUp();
        Console.WriteLine("[Original]");
        char1.PrintInfo();
        Console.WriteLine("[Deep copy sau LevelUp]");
        char4.PrintInfo();

        // check A3
        Console.WriteLine("--------------A3----------------");
        char1.Compare(char3);
    }
}

class Character
{
    // PROPERTY
    public string Name{set; get;}
    public int Level{set; get;}
    public int Health{set; get;}
    private Dictionary<string, int> inventory = new Dictionary<string, int>();
    private List<string> skills = new List<string>();

    // CONSTRUCTOR
    public Character(string name, int level, int health)
    {
        Name = name;
        Level = level;
        Health = health;
    }

    // METHOD
    // thêm item vào inventory
    public void AddItem(string item, int quantity)
    {
        if(inventory.ContainsKey(item))
            inventory[item] += quantity;
        else
            inventory.Add(item, quantity);
        Console.WriteLine($"[NOTICE] Đã thêm {item} x{quantity} vào inventory");
    }

    // [Q1] kiểm tra item có trong inventory không
    public void CheckItem(string item)
    {
        if(inventory.ContainsKey(item))
            Console.WriteLine($"[OK] {item} có trong inventory | Số lượng: {inventory[item]}");
        else
            Console.WriteLine($"[ERROR] {item} không có trong inventory");
    }

    // [Q2] học skill mới - không cho trùng
    public void LearnSkill(string skill)
    {
        if(skills.Contains(skill))
        {
            Console.WriteLine($"[ERROR] Đã học skill {skill} rồi");
            return;
        }
        skills.Add(skill);
        Console.WriteLine($"[NOTICE] Đã học skill {skill}");
    }

    // [Q3] tăng level và health
    public void LevelUp()
    {
        Level++;
        Health += 20;
        Console.WriteLine($"[NOTICE] {Name} lên Level {Level} | Health: {Health}");
    }

    // [A2] deep copy toàn bộ character bao gồm inventory và skills
    public Character DeepCopy()
    {
        Character copy = new Character(Name, Level, Health);
        foreach(KeyValuePair<string, int> item in inventory)
            copy.inventory.Add(item.Key, item.Value);
        foreach(string skill in skills)
            copy.skills.Add(skill);
        return copy;
    }

    // [A3] so sánh 2 character theo Level, Health, số skill, số item
    public void Compare(Character other)
    {
        Console.WriteLine($"[So sánh {Name} với {other.Name}]");
        Console.WriteLine($"Level:    {Level} vs {other.Level} => {(Level >= other.Level ? Name : other.Name)} cao hơn");
        Console.WriteLine($"Health:   {Health} vs {other.Health} => {(Health >= other.Health ? Name : other.Name)} cao hơn");
        Console.WriteLine($"Skills:   {skills.Count} vs {other.skills.Count} skill => {(skills.Count >= other.skills.Count ? Name : other.Name)} nhiều hơn");
        Console.WriteLine($"Items:    {inventory.Count} vs {other.inventory.Count} item  => {(inventory.Count >= other.inventory.Count ? Name : other.Name)} nhiều hơn");
    }

    // in thông tin character
    public void PrintInfo()
    {
        Console.WriteLine($"Name: {Name} | Level: {Level} | Health: {Health} | Skills: {skills.Count} | Items: {inventory.Count}");
    }
}

// [A1] sắp xếp character theo Level giảm dần
class CharacterLevelComparer : IComparer<Character>
{
    public int Compare(Character x, Character y)
    {
        if(x == null || y == null) return 0;
        return y.Level.CompareTo(x.Level); // đảo y.CompareTo(x) = giảm dần
    }
}