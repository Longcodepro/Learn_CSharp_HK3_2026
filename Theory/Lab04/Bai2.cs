using System;
namespace Lab04;

class Bai2
{
    public static void Main(string[] args)
    {
        Animal indenfity = new Animal();
        indenfity.MakeSound();
        Animal dog = new Dog();
        dog.MakeSound();
        Animal cat = new Cat();
        cat.MakeSound();
    }
}

class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound");
    }
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Dog braks");
    }
}

class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Cat meows");
    }
}