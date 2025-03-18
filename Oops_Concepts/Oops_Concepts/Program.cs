using System;

namespace Oops_Concepts
{
    public class Program
    {
        static void main(string[] args)
        {
            Console.WriteLine("Hello Raj");
            Test obj = new Test2();
            obj.VirtualMethodTest();
            obj.Method1();

            Test2 obj2 = new Test2();
            obj2.VirtualMethodTest();
            Console.ReadKey();


            //// To access Method3 from Test2, we need to cast:
            //Test2 test2Obj = (Test2)obj;  // Cast obj to Test2
            //test2Obj.Method3();  // Output: Method3 in Test2
        }
    }

    public class Test
    {

        public virtual int TestValue { get; set; }
        public Test()
        {
            Console.WriteLine("Test Constructor is called");
        }
        public void Method1()
        {
            Console.WriteLine("Method1");
        }
        public virtual void VirtualMethodTest()
        {
            Console.WriteLine("Hwllo private Test");
        }
        public void Method2() { 
        Console.WriteLine("Method2");
        }
    }

    public class Test2 : Test
    {
        public override int TestValue { get => base.TestValue; set => base.TestValue = value; }
        public int TestValue2;
        public Test2()
        {
            Console.WriteLine("Test2 Constructor is called");
        }

        public void Method3()
        {
            Console.WriteLine("Method3");
        }

        public override void VirtualMethodTest()
        {
            base.VirtualMethodTest();
            Console.WriteLine("Hwllo private Test2");
        }
        public void Method4() {
            Console.WriteLine("Method4");
        }
    }

}
