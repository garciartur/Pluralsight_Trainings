using System;
using System.Collections.Generic;
using System.Linq;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            //Linq uses IEnumerable and IEnumerable<T> to work
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee { Id = 1, Name = "Saori"},
                new Employee { Id = 2, Name = "Hyoga"}
            };

            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee { Id = 3, Name = "Seiya"}
            };

            //using the extended method
            Console.WriteLine(developers.Count());
            Console.WriteLine(sales.Count());

            IEnumerator<Employee> enumerator = sales.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }

            //using a lambda expression to filter the foreach condition
            foreach (var employee in sales.Where(_ => _.Name.StartsWith("S")))
            {
                Console.WriteLine(employee.Name);
            }

            //you can combine filters using linq
            foreach (var developer in developers.Where(_ => _.Name.Length == 5)
                                                .OrderBy(_ => _.Name))
            {
                Console.WriteLine(developer.Name);
            }

            //the same linq query can be writen using the extended method syntax or lambda expressions
            var queryLambda = developers.Where(d => d.Name.Length == 5)
                                    .OrderByDescending(d => d.Name);
                                    //this last statment is not mandatory
                                    //.Select(d => d);

            var querySyntax = from developer in developers
                              where developer.Name.Length == 5
                              orderby developer.Name descending
                              select developer;

            foreach (var developer in queryLambda)
            {
                Console.WriteLine(developer.Name);
            }

            foreach (var developer in querySyntax)
            {
                Console.WriteLine(developer.Name);
            }

            //using lambda expression to creat functions
            //one parameter - the second is the return
            Func<int, int> square = x => x * x;
            //two or more parameters, the last is always the return
            Func<int, int, int> sum = (x, y) => x + y;
            //you can use curly brackets to write the function
            Func<int, int, int> divide = (x, y) =>
            {
                var result = x / y;
                return result;
            };
            //return void
            Action<int> write = x => Console.WriteLine(x);
            //testing the functions
            write(square(3));
            write(sum(5, 8));
            write(divide(4, 2));

        }
    }
}
