using System;
using System.Collections.Generic;
namespace GradeBook
{
    class Program
    {
        //using the args as a string array
        static void Main(string[] args)
        {
            var book = new DiskBook("GradeBookTest");
            //the method that listen and handle the event 
            //it need to be static to relate to every objects
            static void OnGradeAdded(object sender, EventArgs args)
            {
                Console.WriteLine("A grade was added");
            }
            //it subscribes the event
            //you can just use += or -= in events
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);

            var stats = book.GetStatistics();
            Console.WriteLine("Average: " + stats.Average);
            Console.WriteLine("Highest grade: " + stats.Highest);
            Console.WriteLine("Lowest grade: " + stats.Lowest);
            Console.WriteLine("Letter grade: " + stats.Letter);
        }

        private static void EnterGrades(IBook book)
        {
            //infinite loop, the break will stop it
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit: ");
                //receive the grade
                var input = Console.ReadLine();

                //finish the infinite loop
                if (input == "q") break;

                //this piece of code will handle the exception
                //the program still running after throwing an exception when it's handled
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    //to finish the program after exception message
                    //throw;
                }
                //handle the double input exceptions - errors that you know can happens
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //used when you have a piece of code that needs to be executed
                finally
                {
                    Console.WriteLine("*** Next grade! ***");
                }
            }
        }
    }
}
