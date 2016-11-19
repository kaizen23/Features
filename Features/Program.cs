using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Features.Linq;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee {Id =1, Name = "Scott" },
                new Employee {Id =2, Name = "Chris" }
            };

            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee { Id = 3, Name = "Ales" },
                new Employee { Id = 4, Name = "Olek" }
            };
            /*Console.WriteLine(developers.Count());
            IEnumerator<Employee> enumerator = sales.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
                Console.ReadKey();
            }
            */
            foreach (var employee in developers.Where(
                     e=>e.Name.StartsWith("S")
                     ))
            {
                Console.WriteLine(employee.Name);
                Console.ReadKey();
            }
        }

        /*private static bool NameStartWithS(Employee employee)
        {
            return employee.Name.StartsWith("S");
        }*/
    }
}
