using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var records = ProcessFile("fuel.csv");
            var manufacturers = ProcessManufacturers("manufacturers.csv");
            var query = cars.Join(manufacturers,
                             c => new { c.Manufacturer, c.Year },
                             m => new { Manufacturer = m.Name, m.Year },
                             (c, m) => new
                             {
                                 c.Name,
                                 m.Headquarters,
                                 c.Combined
                             })
                            .OrderByDescending(c => c.Combined)
                            .ThenBy(c => c.Name)
                            .Select(c => new {c.Headquarters, c.Name, c.Combined})
                            .Take(10);
            //var result = cars.Any(c => c.Manufacturer == "Ford");
            //var result2 = cars.SelectMany(c => c.Name);
            //foreach (var character in result2)
            //{
            //    Console.WriteLine(character);
            //}
            //Console.WriteLine(result);

            var group =
                    cars//.Where(c => c.Manufacturer.Equals("MASERATI"))
                        .GroupBy(c => c.Manufacturer.ToUpper())
                        .OrderBy(g => g.Key);

            var groupjoin =
                    manufacturers.GroupJoin(cars,
                                            m => m.Name,
                                            c => c.Manufacturer,
                                            (m, g) =>
                                                new
                                                {
                                                    Manufacturer = m,
                                                    Cars = g
                                                }
                                            )
                                //.OrderBy(m => m.Manufacturer.Name);
                                .GroupBy(m => m.Manufacturer.Headquarters);
            foreach ( var result in groupjoin)
            {
                Console.WriteLine($"{result.Key}");
                foreach(var car in result.SelectMany(g =>g.Cars)
                                         .OrderByDescending(c => c.Combined)
                                         .Take(2))
               {
                    Console.WriteLine($"\t{car.Name} : {car.Combined}" );
                }
            }

            //foreach (var car in query)
            //{
            //    Console.WriteLine($"{car.Headquarters} {car.Name} : {car.Combined}");
            //}
            Console.ReadKey();
        }

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query =

                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(line => line.Length > 1)
                    .Select(line =>
                    {
                        var columns = line.Split(',');
                        return new Manufacturer
                        {
                            Name = columns[0],
                            Headquarters = columns[1],
                            Year = int.Parse(columns[2])
                        };
                    });
            return query.ToList();
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
