

using System;
namespace Lab04;
class Bai3
{
    public static void Main(string[] args)
    {

        Animal myPet = new Dog1();
        Console.WriteLine("Câu 2: ");
        myPet.MakeSound();

        Console.WriteLine("\nCâu 4: ");
        List<Animal> animalList = new List<Animal> { new Cat(), new Dog(), new Dog2() };

        foreach (var animal in animalList)
        {
            try
            {

                animal.MakeSound();
            }
            catch (NotImplementedException ex)
            {

                Console.WriteLine($"[Lỗi] Con vật này chưa được code chức năng kêu: {ex.Message}");
            }
        }
    }
}

class Dog1 : Animal
{
    public new void MakeSound()
    {
        Console.WriteLine("Gâu gâu");
    }
}
class Dog2 : Animal
{

    public override void MakeSound()
    {

        throw new NotImplementedException("Chức năng sủa chưa được lập trình!");
    }
}
