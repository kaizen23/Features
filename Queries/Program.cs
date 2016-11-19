﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                new Movie { Title = "The Dark Knight", Rating = 8.9f, Year = 2012 },
                new Movie { Title = "The King's Speech", Rating = 8.5f, Year = 2007 },
                new Movie { Title = "Casablanca", Rating = 8.2f, Year = 1900 },
                new Movie { Title = "Start Wars V", Rating = 8.3f, Year = 2004 }
            };

            var query = movies.Where(m => m.Year > 3000);

            //foreach (var movie in query)
            //{
            //    Console.WriteLine(movie.Title);
                
            //}

            Console.ReadKey();
        }
    }
}
