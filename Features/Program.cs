﻿using System;
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
            Func<int, int> square = x => x * x;
            Func<int,int,int> add = (x,y) => x + y;
            Action<int> write = x => Console.WriteLine(x);
            write(add(2, 2));
            Console.WriteLine(add((square(5)),(square(4))));
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
            //method syntax
            var query = developers.Where(e => e.Name.StartsWith("S"))
                                  .Where(e => e.Name.Length >= 4)
                                  .OrderBy(e => e.Name);
            //query syntax
            var query2 = from developer in developers
                         where developer.Name.Length == 5
                         where developer.Name.StartsWith("S")
                         orderby developer.Name
                         select developer;                                   
            foreach (var employee in query2)                    
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
