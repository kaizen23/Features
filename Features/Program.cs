using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] developers = new Employee[]
            {
                new Employee {Id =1, Name = "Scott" },
                new Employee {Id =2, Name = "Chris" }
            };

            List<Employee> sales = new List<Employee>()
            {
                new Employee { Id = 3, Name = "Ales" },
                new Employee { Id = 4, Name = "Olek" }
            };

            foreach (var person in sales)
            {
                Console.WriteLine(person.Name);
                Console.ReadKey();
            }
        }
    }
}
