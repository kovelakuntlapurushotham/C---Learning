

using System;

namespace Oops_Concepts
{
    public class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Every animal eats something.");
        }
        public void Sleep()
        {
            Console.WriteLine("Every animal sleeps.");
        }

        public virtual void WhoAmI()
        {
            Console.WriteLine("I belong to Animal System.");
        }

        public virtual void SoundIMake()
        {
            Console.WriteLine("Animals Have different sounds");
        }
    }

    public class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("Dog barks.");
        }
        public override void WhoAmI()
        {
            Console.WriteLine("I am a Dog.");
            base.WhoAmI();
        }

        public override void SoundIMake()
        {
            Console.WriteLine("I will Bark ....");
        }
    }

    public class Cat : Animal
    {
        public override void WhoAmI()
        {
            Console.WriteLine("I am a Cat.");
            base.WhoAmI();
        }

        public override void SoundIMake()
        {
            Console.WriteLine("I say Meowww.....");
            base.SoundIMake();
        }
    }


    public class AnimalSystem
    {
        static void main(string[] args)
        {
            Animal animal = new Dog();
            animal.Eat();
            animal.Sleep();
            animal.WhoAmI();
            animal.SoundIMake();
            //Dog d2 = (Dog) animal;
            //d2.Bark();
            //animal.Eat();
            //animal.Sleep();
            //animal.WhoAmI();
            //animal.SoundIMake();
            //Dog dog = new Dog();
            //dog.Eat();
            //dog.Sleep();
            //dog.WhoAmI();
            //dog.SoundIMake();
            //dog.Bark();
            //Cat cat = new Cat();
            //cat.Eat();
            //cat.Sleep();
            //cat.WhoAmI();
            //cat.SoundIMake
            //
            Console.ReadKey();
        }
    }
}
