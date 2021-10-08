using System;

namespace Prototype_design_pattern
{
    interface IPrototype
    {
        IPrototype Clone();
    }

    class Employee : IPrototype
    {

        public string Name { get; set; }
        public string Department { get; set; }

        public Employee() { }
        public Employee(Employee prototype)
        {
            Name = prototype.Name;
            Department = prototype.Department;
        }
        public override string ToString() => $"Name: {Name}\nDepartment: {Department}";

        public IPrototype Clone() => new Employee(this);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee { Name = "Kenan", Department = "IT" };
            Employee copyEmp = emp.Clone() as Employee;
            emp.Name = "Revan";

            Console.WriteLine(emp);
            Console.WriteLine(copyEmp);
        }
    }
}
