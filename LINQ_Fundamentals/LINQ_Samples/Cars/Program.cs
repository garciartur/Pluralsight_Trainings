using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("fuel.csv");

            //testing the csv parse
            foreach (var car in cars)
                Console.WriteLine(car.Name);

            /*
            //filtering the cars by eficiency descending ans alphabetical order
            var querySort = cars.OrderByDescending(c => c.Combined)
                                //add the second filtering statement
                                .ThenBy(c => c.Name);
            */

            //using extension method syntax to filter
            var querySort = from car in cars
                            orderby car.Combined descending, car.Name ascending
                            //you can select only the parameter you'll use for a better performance
                            select new
                            {
                                car.Name,
                                car.Combined
                            };

            //selecting only the 10 first results in the query
            foreach (var item in querySort.Take(10))
                Console.WriteLine($"{item.Name, -15} : {item.Combined, 0}");

            //using First to select only one element - Last can be used too
            //this isn't a deferred method, it'll run with the program
            var queryFirst = cars.OrderByDescending(c => c.Combined)
                                 .ThenBy(c => c.Name)
                                 .Select(c => c)
                                 //if the query doesn't find any adequate register it'll throw and exception
                                 .First(c => c.Manufacturer == "Ford" && c.Year == 2016);

            //in this case, queryFirst is a Car object and can be used like this
            Console.WriteLine(queryFirst.Name);

            //you can ask if any element mets a predicate
            //it returns a bool, so it's not deferred
            //true
            var askingA = cars.Any(c => c.Manufacturer == "Ford");
            Console.WriteLine(askingA);
            //false
            var askingB = cars.All(c => c.Manufacturer == "Ford");
            Console.WriteLine(askingB);
        }

        //reading the csv info using linq
        private static List<Car> ProcessFile(string path)
        {
            var query = File.ReadAllLines(path)
                            //skip the first that is the header
                            .Skip(1)
                            .Where(line => line.Length > 1)
                            //parse the lines to Car objects
                            .ToCar();

            return query.ToList();
        }
    }

    //it parses the csv lines and take the responsability from Car.cs
    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                //population the returning Car
                //yield return car by car int running time
                yield return new Car
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3]),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7])
                };
            }           
        }

    }
}
