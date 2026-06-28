using System;
namespace Lab01.Bai5;

class Game_Character
{
    public static void Main(string[] args)
    {
        Character char1 = new Character("Warrior", 10, 100);
        Character char2 = new Character("Mage", 5, 80);
        Character char3 = new Character("Archer", 8, 90);
        char1.PrintInfo();

        Console.WriteLine("--------------Q1----------------");
        char1.AddItem("Sword", 1);
        char1.AddItem("Shield", 2);
        char1.CheckItem("Sword");
        char1.CheckItem("Potion");

        Console.WriteLine("--------------Q2----------------");
        char1.LearnSkill("Fire Slash");
        char1.LearnSkill("Ice Arrow");
        char1.LearnSkill("Fire Slash");

        Console.WriteLine("--------------Q3----------------");
        char1.PrintInfo();
        char1.LevelUp();
        char1.PrintInfo();

        Console.WriteLine("--------------A1----------------");
        List<Character> listChar = new List<Character> { char1, char2, char3 };
        listChar.Sort(new CharacterLevelComparer());
        foreach(Character c in listChar)
        {
            c.PrintInfo();
        }

        Console.WriteLine("--------------A2----------------");
        Character char4 = char1.DeepCopy();
        char4.LevelUp();
        Console.WriteLine("[Original]");
        char1.PrintInfo();
        Console.WriteLine("[Deep copy sau LevelUp]");
        char4.PrintInfo();

        Console.WriteLine("--------------A3----------------");
        char1.Compare(char3);
    }
}

class Character
{

    public string Name{set; get;}
    public int Level{set; get;}
    public int Health{set; get;}
    private Dictionary<string, int> inventory = new Dictionary<string, int>();
    private List<string> skills = new List<string>();

    public Character(string name, int level, int health)
    {
        Name = name;
        Level = level;
        Health = health;
    }

    public void AddItem(string item, int quantity)
    {
        if(inventory.ContainsKey(item))
            inventory[item] += quantity;
        else
            inventory.Add(item, quantity);
        Console.WriteLine($"[NOTICE] Đã thêm {item} x{quantity} vào inventory");
    }

    public void CheckItem(string item)
    {
        if(inventory.ContainsKey(item))
            Console.WriteLine($"[OK] {item} có trong inventory | Số lượng: {inventory[item]}");
        else
            Console.WriteLine($"[ERROR] {item} không có trong inventory");
    }

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

    public void LevelUp()
    {
        Level++;
        Health += 20;
        Console.WriteLine($"[NOTICE] {Name} lên Level {Level} | Health: {Health}");
    }

    public Character DeepCopy()
    {
        Character copy = new Character(Name, Level, Health);
        foreach(KeyValuePair<string, int> item in inventory)
            copy.inventory.Add(item.Key, item.Value);
        foreach(string skill in skills)
            copy.skills.Add(skill);
        return copy;
    }

    public void Compare(Character other)
    {
        Console.WriteLine($"[So sánh {Name} với {other.Name}]");
        Console.WriteLine($"Level:    {Level} vs {other.Level} => {(Level >= other.Level ? Name : other.Name)} cao hơn");
        Console.WriteLine($"Health:   {Health} vs {other.Health} => {(Health >= other.Health ? Name : other.Name)} cao hơn");
        Console.WriteLine($"Skills:   {skills.Count} vs {other.skills.Count} skill => {(skills.Count >= other.skills.Count ? Name : other.Name)} nhiều hơn");
        Console.WriteLine($"Items:    {inventory.Count} vs {other.inventory.Count} item  => {(inventory.Count >= other.inventory.Count ? Name : other.Name)} nhiều hơn");
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Name: {Name} | Level: {Level} | Health: {Health} | Skills: {skills.Count} | Items: {inventory.Count}");
    }
}

class CharacterLevelComparer : IComparer<Character>
{
    public int Compare(Character x, Character y)
    {
        if(x == null || y == null) return 0;
        return y.Level.CompareTo(x.Level);
    }
}
