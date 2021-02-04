
using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    //creating an event
    //who sends the event and arguments of the event
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public interface IBook
    {
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;

        void AddGrade(double grade);
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public virtual event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public virtual Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            //creates and open the file
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                //write in the file
                writer.WriteLine(grade);

                if (GradeAdded != null)
                {
                    //the sender is the function
                    GradeAdded(this, new EventArgs());
                }
            }
            //this structure close and clean everything after using the file and it's very common in i/o sessions
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            //opens the file to read the content
            using(var reader = File.OpenText($"{Name}.txt"))
            {
                //initiate the reading
                var line = reader.ReadLine();
                //while there is lines to be read...
                while(line != null)
                {
                    //read the line content as a double
                    var number = double.Parse(line);
                    //add a grade in statistics
                    result.Add(number);
                    //read another line
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }

    public class InMemoryBook : Book
    {
        private List<double> grades { get; set; }
        //the event parameter in the class
        public override event GradeAddedDelegate GradeAdded;

        //reference the base constructor in the class constructor
        public InMemoryBook(string name) : base(name)
        {
            //inicialize the list on constructor to be used in AddGrade
            grades = new List<double>();
            this.Name = name;
        }

        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                //invoking the event - if it's null, no one is listening
                if(GradeAdded != null)
                {
                    //the sender is the function
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                //throw an exception using the parameter type name in the message
                throw new ArgumentException($"Invalid {nameof(grade)}");
                //to catch this exception, the runtime will try to find some piece of code that menage the error
                //in case it didn't find it'll go back to the code that call the function
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            var index = 0;

            foreach(var grade in grades)
            {
                result.Add(grades[index]);
                index++;
            }

            return result;
        }        
    }
}
 