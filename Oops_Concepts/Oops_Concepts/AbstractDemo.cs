using System;

abstract class Animal
{
    public string Name { get; set; }

    // Abstract method (no implementation)
    public abstract void MakeSound();

    // Non-abstract method (with implementation)
    public void Eat()
    {
        Console.WriteLine($"{Name} is eating.");
    }
}

class Dog : Animal
{
    public Dog(string name)
    {
        Name = name;
    }

    // Providing implementation for the abstract method
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says woof!");
    }
}

class Program
{
    static void Main()
    {
        Animal animals = new Dog("Sandy");
        animals.Eat(); // Output: Sandy is eating.
        Dog myDog = new Dog("Buddy");
        myDog.MakeSound(); // Output: Buddy says woof!
        myDog.Eat();       // Output: Buddy is eating.
    }
}


