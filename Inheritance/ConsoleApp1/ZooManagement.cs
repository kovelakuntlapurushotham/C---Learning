using System;
using System.Collections.Generic;

// Abstract base class Animal
public abstract class Animal
{
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }

    // Constructor
    public Animal(string name, string species, int age)
    {
        Name = name;
        Species = species;
        Age = age;
    }

    // Abstract method for calculating food consumption
    public abstract void CalculateFoodConsumption();

    // Abstract method for displaying the animal's habitat needs
    public abstract void HabitatNeeds();

    // Displaying common animal details
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}, Species: {Species}, Age: {Age}");
    }
}

// Lion class inheriting from Animal
public class Lion : Animal
{
    public int NumberOfMeals { get; set; }

    public Lion(string name, int age, int numberOfMeals)
        : base(name, "Lion", age)
    {
        NumberOfMeals = numberOfMeals;
    }

    // Implementing CalculateFoodConsumption for Lion
    public override void CalculateFoodConsumption()
    {
        Console.WriteLine($"{Name} the lion consumes {NumberOfMeals * 10} kg of meat per day.");
    }

    // Implementing HabitatNeeds for Lion
    public override void HabitatNeeds()
    {
        Console.WriteLine($"{Name} needs a large enclosure with a den for resting.");
    }
}

// Elephant class inheriting from Animal
public class Elephant : Animal
{
    public int NumberOfMeals { get; set; }

    public Elephant(string name, int age, int numberOfMeals)
        : base(name, "Elephant", age)
    {
        NumberOfMeals = numberOfMeals;
    }

    // Implementing CalculateFoodConsumption for Elephant
    public override void CalculateFoodConsumption()
    {
        Console.WriteLine($"{Name} the elephant consumes {NumberOfMeals * 50} kg of food per day.");
    }

    // Implementing HabitatNeeds for Elephant
    public override void HabitatNeeds()
    {
        Console.WriteLine($"{Name} needs a large open area with access to water and trees.");
    }
}

// Bird class inheriting from Animal
public class Bird : Animal
{
    public int NumberOfMeals { get; set; }

    public Bird(string name, int age, int numberOfMeals)
        : base(name, "Bird", age)
    {
        NumberOfMeals = numberOfMeals;
    }

    // Implementing CalculateFoodConsumption for Bird
    public override void CalculateFoodConsumption()
    {
        Console.WriteLine($"{Name} the bird consumes {NumberOfMeals * 1} kg of seeds per day.");
    }

    // Implementing HabitatNeeds for Bird
    public override void HabitatNeeds()
    {
        Console.WriteLine($"{Name} needs a small aviary with perches and nesting areas.");
    }
}

// Zoo class that can manage all animals
public class Zoo
{
    private List<Animal> animals;

    public Zoo()
    {
        animals = new List<Animal>();
    }

    // Add animal to the zoo
    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
    }

    // Show all animals' details
    public void DisplayAllAnimals()
    {
        foreach (var animal in animals)
        {
            animal.DisplayDetails();
            animal.CalculateFoodConsumption();
            animal.HabitatNeeds();
            Console.WriteLine(); // Add an empty line between animals
        }
    }
}

class Program1
{
    static void main(string[] args)
    {
      
        // Create a zoo
        Zoo zoo = new Zoo();

        // Create some animals
        Lion lion = new Lion("Leo", 5, 3); // 3 meals per day
        Elephant elephant = new Elephant("Dumbo", 10, 4); // 4 meals per day
        Bird bird = new Bird("Tweety", 2, 2); // 2 meals per day
        Console.Beep();
        // Add animals to the zoo
        zoo.AddAnimal(lion);
        zoo.AddAnimal(elephant);
        zoo.AddAnimal(bird);

        // Display details of all animals in the zoo
        zoo.DisplayAllAnimals();
    }
}
