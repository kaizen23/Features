﻿using System;
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
            var query = cars.Where(c => c.Manufacture =="BMW")
                            .Where(c => c.Year == 2016)
                            .OrderByDescending(c => c.Combined)
                            .ThenBy(c => c.Name)
                            .Take(10);
            var result = cars.Any(c => c.Manufacture == "Ford");
            Console.WriteLine(result);

            //foreach(var car in query)
            //{
            //    Console.WriteLine($"{car.Manufacture} {car.Name} : {car.Combined}");
            //}
            Console.ReadKey();
        }

        private static List<Car> ProcessFile(string path)
        {
            return
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(line => line.Length > 1)
                    .Select(Car.ParseFromCsv)
                    .ToList();


        }
    }
}
