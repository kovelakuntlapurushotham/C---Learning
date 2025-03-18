using System.Xml.Linq;

namespace ConsoleApp1
{
    public class Employee : EmployeeDetails
    {
        public int Id { get; private set; }
        private string EmployeeName {  get; set; }
        private int EmployeeAge { get; set; }

        protected int Salary { get; set; }
        public Employee(int id, string employeeName, int employeeAge, int salary) : base(salary)
        {
            Id = id;
            EmployeeName = employeeName;
            EmployeeAge = employeeAge;
            Salary = salary;
        }

        public override int CalculateSalary()
        {
            throw new NotImplementedException();
        }

        public override void GetEmployeeDetails()
        {
            throw new NotImplementedException();
        }
    }

    public class FullTimeEmployee : Employee
    {
        public FullTimeEmployee(int id, string employeeName, int employeeAge, int salary) : base(id, employeeName, employeeAge,salary)
        {
        }

        public override int CalculateSalary()
        {
            //one day salary * 30 days;
            return Salary * 30;
        }

       
    }


    public class PartTimeEmployee : Employee
    {
        public int NoOfHous { get; set; }
        public PartTimeEmployee(int id, string employeeName, int employeeAge, int salary , int noOfHours) : base(id, employeeName, employeeAge, salary)
        {
            NoOfHous = noOfHours;
        }
        public override int CalculateSalary()
        {
            //one day salary * 30 days;
            return Salary * NoOfHous;
        }
    }
    public abstract class EmployeeDetails : SalaryEmployee
    {
        private int Salary { get; set; }
        public abstract int CalculateSalary();

        public abstract void GetEmployeeDetails();
        

        protected EmployeeDetails(int salary)
        {
            Salary = salary;
        }

    }

    interface SalaryEmployee
    {
        int CalculateSalary();
        void GetEmployeeDetails();
    }
}
