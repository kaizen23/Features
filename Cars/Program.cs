using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var records = ProcessFile("fuel.csv");
            var document = new XDocument();
            var cars = new XElement("Cars");

            foreach (var  record in records)
            {
                var car = new XElement("Car");
                var name = new XElement("Name",record.Name);
                var combined = new XElement("Combined", record.Combined);

                car.Add(name);
                car.Add(combined);
                cars.Add(car);

            }

            document.Add(cars);
            document.Save("fuel.xml");
            Console.ReadKey();

         
            
        }

     

        private static List<Car> ProcessFile(string path)
        {
            var query =

                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(line => line.Length > 1)
                    .ToCar()
                    //.Select(Car.ParseFromCsv)
                    .ToList();
            return query;


        }
    }
}
