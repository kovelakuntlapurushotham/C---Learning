public class Vehical
{
    private string Name { get; set; }
    private string Model { get; set; }
    private string Color { get; set; }
    private int Year { get; set; }
    public Vehical(string name, string model, string color, int year)
    {
        Name = name;
        Model = model;
        Color = color;
        Year = year;
    }
    public string GetName() => Name;
    public string GetModel() => Model;
    public string GetColor() => Color;
    public string GetYear() => Year.ToString();
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Vehical Name: {Name}, Model: {Model}, Color: {Color}, Year: {Year}");
    }
}

public class Car : Vehical, ICaluclateRentalPrice
{
    public int NoOfHours { get; set; }
    public int BaseAmount { get; set; }
    public Car(string name, string model, string color, int year, int noOfHours,int baseAmount) : base(name, model, color, year)
    {
        NoOfHours = noOfHours;
        BaseAmount = baseAmount;
    }

    public void CalculateRentalPrice()
    {
        Console.WriteLine($"Total Car Amount is {BaseAmount * NoOfHours}");
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"My Car is {GetName}, with model no {GetModel} , manufactured in {GetYear} looks {GetColor}");
    }
}

public class Truck : Vehical , ICaluclateRentalPrice
{
    public int NoOfHours { get; set; }
    public int BaseAmount { get; set; }
    public Truck(string name, string model, string color, int year, int noOfHours, int baseAmount) : base(name, model, color, year)
    {
        NoOfHours = noOfHours;
        BaseAmount = baseAmount;
    }
    public override void DisplayDetails()
    {
        Console.WriteLine($"My Truck is {GetName}, with model no {GetModel} , manufactured in {GetYear} looks {GetColor}");
    }

    public void CalculateRentalPrice()
    {
        Console.WriteLine($"Total Car Amount is {BaseAmount * NoOfHours + 1000}");
    }
}

interface ICaluclateRentalPrice
{
    void CalculateRentalPrice();
}

public abstract class VehicalDetail
{
    public abstract void DisplayDetails(Vehical vehical);
    
}

public class VehicleRentalSystems : VehicalDetail
{
    public override void DisplayDetails(Vehical vehical)
    {
        vehical.DisplayDetails();
    }
}
