public class Program
{
    int  x = 10;
    static void main(string[] args)
    {
        Program p = new Program();

        Father f1 = new Child(200000,50000);
        Console.WriteLine(f1.GetFather());
        Console.WriteLine(f1.GetFatherAssests ());
        Console.WriteLine(f1);
        Console.WriteLine($"Hello World ,{p.x}");
    }
}


public class Father
{
    protected int FatherAssests { get; set; }
    protected int Loans { get; set; }
    public Father(int property, int loans)
    {
        FatherAssests = property;
        Loans = loans;
    }

    public virtual string GetFather()
    {
        return $"My Father is Base of Mine" ;
    }
    public int GetFatherAssests()
    {
        return 200000;
    }

    public int GetFatherLoans()
    {
        return 100000;
    }
}


public class Child : Father
{
    public Child(int property, int loans) : base(property, loans)
    {

    }
    public int GetChildAssests()
    {
        return FatherAssests + 100000;
    }

    public override string GetFather()
    {
        base.GetFather();
        return $"I am Child of My Father";
    }
    public int GetChildLoans()
    {
        return Loans + 50000;
    }

    public int TotalAssesstsChildHas()
    {
        return GetChildAssests() - GetChildLoans();
    }
}