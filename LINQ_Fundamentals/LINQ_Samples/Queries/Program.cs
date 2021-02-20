using System;
using System.Collections.Generic;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
            {
                new Movie { Title = "The Sound of Music", Rating = 8.0f, Year = 1965 },
                new Movie { Title = "La La Land", Rating = 8.0f, Year = 2016 },
                new Movie { Title = "Grease", Rating = 7.2f, Year = 1978 },
                new Movie { Title = "Chicago", Rating = 7.2f, Year = 2002 },
                new Movie { Title = "The Rocky Horror Picture Show", Rating = 7.4f, Year = 1975 }
            };

            //querying the movies after year 2000
            Console.WriteLine("\n***** LINQ *****\n");
            var queryYearLinq = movies.Where(m => m.Year >= 2000);

            foreach (var movie in queryYearLinq)
            {
                Console.WriteLine(movie.Title);
            }

            //you can implement the same filter using extended methods - that's how linq works under the hoods
            Console.WriteLine("\n***** EXTENDED METHOD *****\n");
            var queryYearExMethod = movies.Filter(m => m.Year >= 2000);

            foreach (var movie in queryYearExMethod)
            {
                Console.WriteLine(movie.Title);
            }
        }
    }
}
