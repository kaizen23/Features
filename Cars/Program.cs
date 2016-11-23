using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarDb>());
            InsertData();
            QueryData();
            Console.ReadKey();
            //CreateXml();
            //QueryXml();
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

        private static void QueryData()
        {
            var db = new CarDb();
            db.Database.Log = Console.WriteLine;
            var query = from car in db.Cars
                        orderby car.Combined descending, car.Name ascending
                        select car;
            var query2 =
                    db.Cars
                    .Where(c => c.Manufacturer =="BMW")
                    .OrderByDescending(c => c.Combined)
                    .ThenBy(c => c.Name);
            foreach ( var car in query2.Take(10))
            {
                Console.WriteLine($"{car.Manufacturer} {car.Name} : {car.Combined}");
            }
            
        }

        private static void InsertData()
        {
            var cars = ProcessCars("fuel.csv");
            var db = new CarDb();

            if (!db.Cars.Any())
            {
                foreach(var car in cars)
                {
                    db.Cars.Add(car);
                }
                db.SaveChanges();
            }
        }

        //private static void QueryXml()
        //{
        //    var document = XDocument.Load("fuel.xml");


        //    var query =
        //        //from element in document.Element("Cars").Elements("Car")
        //        from element in document.Descendants("Car")
        //        where element.Attribute("Manufacturer").Value == "BMW"
        //        select element.Attribute("Name").Value;

        //    foreach(var name in query)
        //    {
        //        Console.WriteLine(name);
                
        //    }
        //    Console.ReadKey();

        //}

        //private static void CreateXml()
        //{
        //    var records = ProcessFile("fuel.csv");
        //    var document = new XDocument();
        //    var cars = new XElement("Cars",
        //        from record in records
        //        select new XElement("Car",
        //                         new XAttribute("Name", record.Name),
        //                         new XAttribute("Manufacturer", record.Manufacturer),
        //                         new XAttribute("Combined", record.Combined)
        //                            )

        //    );
        //    document.Add(cars);
        //    document.Save("fuel.xml");
            
        //}


        private static List<Car> ProcessCars(string path)
        {
            var query =

                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(line => line.Length > 1)
                    //.ToCar();
                    .Select(Car.ParseFromCsv);

            return query.ToList();


        }
    }
}
