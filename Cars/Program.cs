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
            var records23 = ProcessFile("fuel.csv");
         
            
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
