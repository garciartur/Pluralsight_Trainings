using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Introduction
{
    class Program
    {

        static void Main(string[] args)
        {
            string path = @"C:\windows";
            Console.WriteLine("\n***** WITHOUT LINQ ****\n");
            ShowLargeFileWithoutLINQ(path);
            Console.WriteLine("\n***** WITH LINQ ****\n");
            ShowLargeFileWithLINQ(path);
        }

        //WITHOUT LINQ
        private static void ShowLargeFileWithoutLINQ(string path)
        {
            //system object that provide directory informations
            DirectoryInfo directory = new DirectoryInfo(path);
            //return instances of FileInfo
            FileInfo[] files = directory.GetFiles();

            //ordering the files
            //sort has a overload that can order by size, but it's necessary to use as parameter a object that implements IComparer
            Array.Sort(files, new FileInfoComparer());

            //show the 5 first elements already ordered
            for (int i = 0; i < 5; i++)
            {
                FileInfo file = files[i];
                //prints the formated results
                Console.WriteLine($"{file.Name, -20} : {file.Length, 10}");
            }
        }

        //WITH LINQ
        private static void ShowLargeFileWithLINQ(string path)
        {
            /*USING A LINQ LANGUAGE
            //a linq search is a query 
            var query = from file in new DirectoryInfo(path).GetFiles()
                        //ordering the results
                        orderby file.Length descending
                        //taking the results
                        select file;

            //show only five results
            foreach (var file in query.Take(5))
            {
                //prints the formated results
                Console.WriteLine($"{file.Name,-20} : {file.Length,10}");
            }
            */

            //USING LAMBDA EXPRESSION - same code above using another syntax
            var query = new DirectoryInfo(path).GetFiles()
                .OrderByDescending(file => file.Length)
                //select the five result in the query
                .Take(5);

            foreach(var file in query)
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
            }
        }
    }

    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            //returns -1 if y < x
            //returns 0 if y == x
            //returns 1 y > x
            return y.Length.CompareTo(x.Length);
        }

    }
}
