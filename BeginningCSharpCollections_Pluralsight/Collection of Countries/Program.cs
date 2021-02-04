using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralsight.BegCShCollections.CollectionOfCountries
{
	class Program
	{
		static void Main(string[] args)
		{
			string filePath = @"C:\Users\tarep\Documents\PluralSight\BeginningCSharpCollections_Pluralsight\Pop by Largest Final.csv";
			CsvReader reader = new CsvReader(filePath);

			//creating a dictionary of lists of Country instances
			Dictionary<string, List<Country>> countries = reader.ReadAllCountries();

			//display all the regions / keys of the dictionary
			foreach (var region in countries.Keys)
                Console.WriteLine(region);

            //read the user region input
            Console.WriteLine("Choose the region above to display the Top 10 Country's Population : ");
			string userRegion = Console.ReadLine();

			//verify if the chosen region exists in the dictionary
			if (countries.ContainsKey(userRegion))
            {
				//using LINQ to query the first 10 countries that matches the chosen region
				foreach (var country in countries[userRegion].Take(10))
					//display formated info 
                    Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)} : {country.Name}");
            }
			else
                Console.WriteLine("This is NOT a valid region! Please, reads the list above...");
		}
	}
}
