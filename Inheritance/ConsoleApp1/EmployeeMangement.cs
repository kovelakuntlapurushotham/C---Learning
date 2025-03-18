using System;

namespace OOPExample
{
    // Encapsulation: Employee Class (Base Class)
    public class Employee
    {
        private string Name { get; set; }
        private int EmployeeId { get; set; }
        private double Salary { get; set; }

        // Constructor to initialize employee
        public Employee(string name, int id)
        {
            Name = name;
            EmployeeId = id;
        }

        // Encapsulation: Get and Set Methods
        public string GetName() => Name;
        public void SetName(string name) => Name = name;

        public int GetEmployeeId() => EmployeeId;
        public void SetEmployeeId(int id) => EmployeeId = id;

        public double GetSalary() => Salary;
        public void SetSalary(double salary) => Salary = salary;

        // Abstract method to be implemented by derived classes
        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Employee ID: {EmployeeId}, Name: {Name}, Salary: {Salary}");
        }
    }

    // Inheritance: FullTimeEmployee class (Derived from Employee)
    public class FullTimeEmployee : Employee, ISalaryCalculator
    {
        private double Bonus { get; set; }

        public FullTimeEmployee(string name, int id, double bonus) : base(name, id)
        {
            Bonus = bonus;
        }

        // Overriding the DisplayDetails method for FullTimeEmployee
        public override void DisplayDetails()
        {
            Console.WriteLine($"Full-Time Employee ID: {GetEmployeeId()}, Name: {GetName()}, Base Salary: {GetSalary()}, Bonus: {Bonus}");
        }

        // Polymorphism: Calculate salary for FullTimeEmployee
        public double CalculateSalary()
        {
            return GetSalary() + Bonus; // Base salary + Bonus
        }
    }

    // Inheritance: PartTimeEmployee class (Derived from Employee)
    public class PartTimeEmployee : Employee, ISalaryCalculator
    {
        private double HourlyRate { get; set; }
        private int HoursWorked { get; set; }

        public PartTimeEmployee(string name, int id, double hourlyRate, int hoursWorked) : base(name, id)
        {
            HourlyRate = hourlyRate;
            HoursWorked = hoursWorked;
        }

        // Overriding the DisplayDetails method for PartTimeEmployee
        public override void DisplayDetails()
        {
            Console.WriteLine($"Part-Time Employee ID: {GetEmployeeId()}, Name: {GetName()}, Hourly Rate: {HourlyRate}, Hours Worked: {HoursWorked}");
        }

        // Polymorphism: Calculate salary for PartTimeEmployee
        public double CalculateSalary()
        {
            return HourlyRate * HoursWorked; // Hourly Rate * Hours Worked
        }
    }

    // Abstraction: Abstract class EmployeeDetails
    public abstract class EmployeeDetails
    {
        public abstract void DisplayEmployeeDetails(Employee employee);
    }

    // Concrete Class: EmployeeManager
    public class EmployeeManager : EmployeeDetails
    {
        public override void DisplayEmployeeDetails(Employee employee)
        {
            employee.DisplayDetails(); // Calls the respective DisplayDetails of the object (FullTime or PartTime)
        }
    }

    // Interface: ISalaryCalculator
    public interface ISalaryCalculator
    {
        double CalculateSalary();
    }

    // Main Program to test the code
    public class Program
    {
        public static void main()
        {
            // Create a Full-Time Employee
            FullTimeEmployee ftEmployee = new FullTimeEmployee("John Doe", 1, 5000);
            ftEmployee.SetSalary(40000); // Set base salary
            Console.WriteLine($"Full-Time Employee Salary: {ftEmployee.CalculateSalary()}");

            // Create a Part-Time Employee
            PartTimeEmployee ptEmployee = new PartTimeEmployee("Jane Smith", 2, 20, 80); // Hourly rate, hours worked
            ptEmployee.SetSalary(0); // No base salary for part-time, salary is based on hourly rate
            Console.WriteLine($"Part-Time Employee Salary: {ptEmployee.CalculateSalary()}");

            // Use the EmployeeManager to display details
            EmployeeManager employeeManager = new EmployeeManager();
            employeeManager.DisplayEmployeeDetails(ftEmployee);
            employeeManager.DisplayEmployeeDetails(ptEmployee);
        }
    }
}
