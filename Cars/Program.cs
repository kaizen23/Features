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
            var cars = ProcessFile("fuel.csv");
            var manufactures = ProcessManufacturers("manufacturers.csv");
            var query = cars.Join(manufactures,
                             c => c.Manufacture,
                             m => m.Name,
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
            var result = cars.Any(c => c.Manufacture == "Ford");
            //var result2 = cars.SelectMany(c => c.Name);
            //foreach (var character in result2)
            //{
            //    Console.WriteLine(character);
            //}
            //Console.WriteLine(result);

            foreach (var car in query)
            {
                Console.WriteLine($"{car.Headquarters} {car.Name} : {car.Combined}");
            }
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
