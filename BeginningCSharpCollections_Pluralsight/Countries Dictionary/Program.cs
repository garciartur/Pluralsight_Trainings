using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralsight.BegCShCollections.CountriesDictionary
{
	class Program
	{
		static void Main(string[] args)
		{
			string filePath = @"C:\Users\tarep\Documents\PluralSight\BeginningCSharpCollections_Pluralsight\Pop by Largest Final.csv";
			CsvReader reader = new CsvReader(filePath);

			//creating a dictionary of Country instances - the first parameter (string) is the index 
			Dictionary<string, Country> countries = reader.ReadAllCountries();

			//reads the country that the user look up
            Console.WriteLine("Type a country code: ");
			string userInput = Console.ReadLine();

			//verify if the code input is in the dictionary 
			bool gotCountry = countries.TryGetValue(userInput, out var country);

			if (!gotCountry)
				//unexpected input
				Console.WriteLine($"There is no country with the code {userInput} !!!");
			else
				//expected input
				Console.WriteLine($"{country.Name} has population {PopulationFormatter.FormatPopulation(country.Population)}");

			Console.ReadLine();
		}
	}
}
