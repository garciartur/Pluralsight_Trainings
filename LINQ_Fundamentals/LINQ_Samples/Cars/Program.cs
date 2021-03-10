using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Cars
{
    public class Program
    {
        static void Main(string[] args)
        {
            //importing the csv files
            var cars = ProcessCars("fuel.csv");
            var manufacturers = ProcessManufacturers("manufacturers.csv");


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
                Console.WriteLine($"{item.Name,-15} : {item.Combined,0}");

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


            //using join to query diferent sources of data
            //extended method syntax
            /*
            var queryJoin = from car in cars
                            join manufacturer in manufacturers
                                on car.Manufacturer equals manufacturer.Name
                            orderby car.Combined descending, car.Name ascending
                            select new
                            {
                                manufacturer.Headquarters,
                                car.Name,
                                car.Combined
                            };
            */

            //lambda expression syntax
            var queryJoin = cars.Join(manufacturers,
                                    c => c.Manufacturer,
                                    m => m.Name, (c, m) => new
                                    {
                                        m.Headquarters,
                                        c.Name,
                                        c.Combined
                                    })
                                .OrderByDescending(c => c.Combined)
                                .ThenBy(c => c.Name);


            foreach (var item in queryJoin.Take(10))
            {
                Console.WriteLine($"{item.Headquarters} {item.Name} : {item.Combined}");
            }

            Console.WriteLine("\n***** GROUPING *****\n");
            //grouping data 
            //extended method syntax
            /*
            var groupingCar = from car in cars
                              //define the group key - it's like an identifier
                              //all uppercase to avoid errors
                              group car by car.Manufacturer.ToUpper() into manufacturer
                              //you can't try to order car cause it's not available, that's why you use into 
                              orderby manufacturer.Key ascending
                              select manufacturer;
            */

            //lambda expression syntax
            var groupingCar = cars.GroupBy(c => c.Manufacturer.ToUpper())
                                  .OrderBy(g => g.Key);

            //the return is a collection of collections
            foreach (var group in groupingCar)
            {
                Console.WriteLine(group.Key);

                //querying the group to take just the two most efficient cars
                foreach (var car in group.OrderByDescending(c => c.Combined).Take(2))
                {
                    Console.WriteLine($"\t{car.Name} : {car.Combined}");
                }
            }

            Console.WriteLine("\n***** GROUP AND JOIN *****\n");
            //join different data sources and grouping it
            //extension method syntax
            /*
            var queryGroupJoin = from manufacturer in manufacturers
                                     //join the cars by their manufecturer
                                 join car in cars on manufacturer.Name equals car.Manufacturer
                                    into carGroup
                                 orderby manufacturer.Headquarters
                                 select new
                                 {
                                     Manufacturer = manufacturer,
                                     Car = carGroup
                                 } into result
                                 group result by result.Manufacturer.Headquarters;
            */

            //lambda expression syntax
            var queryGroupJoin = manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, (m, g) =>
                                                 new
                                                 {
                                                     Manufacture = m,
                                                     Car = g
                                                 })
                                               .GroupBy(m => m.Manufacture.Headquarters);

            foreach (var group in queryGroupJoin)
            {
                Console.WriteLine($"{group.Key}");
                foreach (var car in group.SelectMany(g => g.Car)
                                         .OrderByDescending(c => c.Combined)
                                         .Take(3))
                {
                    Console.WriteLine($"\t{car.Name} : {car.Combined}");
                }
            }

            Console.WriteLine("\n***** AGGREGATING *****\n");
            //aggregating data
            //extension method syntax
            var queryAggregate = from car in cars
                                 group car by car.Manufacturer into carGroup
                                 select new
                                 {
                                     Name = carGroup.Key,
                                     //return the biggest number in query
                                     Max = carGroup.Max(c => c.Combined),
                                     //return the smallest number in query
                                     Min = carGroup.Min(c => c.Combined),
                                     //return the average
                                     Avg = carGroup.Average(c => c.Combined)
                                 } into result
                                 //sort the query by the max descending
                                 orderby result.Max descending
                                 select result;

            foreach (var result in queryAggregate)
            {
                Console.WriteLine($"{result.Name}");
                Console.WriteLine($"\tMax: {result.Max}");
                Console.WriteLine($"\tMin: {result.Min}");
                Console.WriteLine($"\tAvg: {result.Avg}");
            }

            //creating a xml file
            CreateXML(cars);
            //querrying a xml file
            QueryXML();
        }

        private static void QueryXML()
        {
            //load the file - it can be an url too
            var documentXML = XDocument.Load("fuel.xml");

            var query = from element in documentXML.Descendants("Car")
                        where element.Attribute("Manufacturer")?.Value == "BMW"
                        select element.Attribute("Name").Value;

            foreach (var name in query)
                Console.WriteLine(name);
        }

        private static void CreateXML(List<Car> cars)
        {
            //creatin an XML file
            //create xml file
            var documentXML = new XDocument();
            /*
            //create the head element
            var carsXML = new XElement("Cars");

            //using foreach
            foreach (var car in cars)
            {
                //create an upper element
                var carXML = new XElement("Car",
                             //append the attributes and values
                             new XAttribute("Name", car.Name),
                             new XAttribute("Combined", car.Combined),
                             new XAttribute("Manufacturer", car.Manufacturer)
                );

                //add every child element to the head element
                carsXML.Add(carXML);
            }
            */

            //using linq
            //create the head element
            var carsXML = new XElement("Cars",
                    //create the linq query to populate
                    from car in cars
                    select new XElement("Car",
                             new XAttribute("Name", car.Name),
                             new XAttribute("Combined", car.Combined),
                             new XAttribute("Manufacturer", car.Manufacturer))
            );

            //add the head element to the xml file
            documentXML.Add(carsXML);
            //save the file
            documentXML.Save("fuel.xml");
        }

        //reading the csv info using linq
        private static List<Car> ProcessCars(string path)
        {
            var query = File.ReadAllLines(path)
                            //skip the first that is the header
                            .Skip(1)
                            .Where(line => line.Length > 1)
                            //parse the lines to Car objects
                            .ToCar();

            return query.ToList();
        }

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query = File.ReadAllLines(path)
                            .Where(l => l.Length > 1)
                            .Select(l =>
                            {
                                var columns = l.Split(',');
                                return new Manufacturer
                                {
                                    Name = columns[0],
                                    Headquarters = columns[1],
                                    Year = int.Parse(columns[2])
                                };
                            });

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

    //this class will be passed as an aggregator in a linq query
    public class CarStatistics
    {
        public int Max { get; set; }
        public int Min { get; set; }
        public int Average { get; set; }
    }
}
