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
            CreateXml();
            QueryXml();
            //foreach (var  record in records)
            //{
            //    // name = new XAttribute("Combined", record.Combined)
            //    //var combined = new XAttribute("Combined", record.Combined);
            //    var car = new XElement("Car",
            //                             new XAttribute("Name", record.Name),
            //                             new XAttribute("Manufacturer", record.Manufacturer),
            //                             new XAttribute("Combined", record.Combined));


            //car.Add(name);
            //car.Add(combined);
            // cars.Add(car);




        }

        private static void QueryXml()
        {
            var document = XDocument.Load("fuel.xml");


            var query =
                //from element in document.Element("Cars").Elements("Car")
                from element in document.Descendants("Car")
                where element.Attribute("Manufacturer").Value == "BMW"
                select element.Attribute("Name").Value;

            foreach(var name in query)
            {
                Console.WriteLine(name);
                
            }
            Console.ReadKey();

        }

        private static void CreateXml()
        {
            var records = ProcessFile("fuel.csv");
            var document = new XDocument();
            var cars = new XElement("Cars",
                from record in records
                select new XElement("Car",
                                 new XAttribute("Name", record.Name),
                                 new XAttribute("Manufacturer", record.Manufacturer),
                                 new XAttribute("Combined", record.Combined)
                                    )

            );
            document.Add(cars);
            document.Save("fuel.xml");
            
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
