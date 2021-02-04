using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralsight.BegCShCollections.ReadAllCountries
{
	class Program
	{
		static void Main(string[] args)
		{
			string filePath = @"C:\Users\tarep\Documents\PluralSight\BeginningCSharpCollections_Pluralsight\Pop by Largest Final.csv";
			CsvReader reader = new CsvReader(filePath);

			//creating a list of Country instances
			List<Country> countries = reader.ReadAllCountries();
			//removing countries with ',' in the name
			reader.RemoveCommaCountries(countries);

			//adding a new country to the list
			var wakanda = new Country("Wakanda", "WAK", "Africa", 6_000_000);
			//using a lambda expression to find wakanda position / index
			int wakandaIndex = countries.FindIndex(_ => _.Population < 6_000_000);
			//insert the instance in an especific index 
			//it can prejudicate the software performance, cause all the positions after the insertion will change in the memory
			countries.Insert(wakandaIndex, wakanda);
            //you can remove using the index too
            //countries.RemoveAt(wakandaIndex);

            //enumerate all countries at the file
            /*
			foreach (Country country in countries)
			{
				Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
			}
			*/

            //enumerate only the quantity especified by user
            Console.WriteLine("Enter the number of countries you wanna display: ");

			//read the user input and verifify if it's an integer
			bool verifyInput = int.TryParse(Console.ReadLine(), out int userInput);
			//verifiy the input again
			if (!verifyInput || userInput <= 0)
				//unexpected value
				Console.WriteLine("You need to type an integer number!");

			//compare the number of countries in the list with the user input and use the minimum
			var maxCountries = Math.Min(userInput, countries.Count) == userInput ? userInput : countries.Count;

			//enumerate only the countries user asked but show the option to continue displaying
			//enumerate all countries in the list
			for(int i = 0; i < countries.Count; i++)
            {
				//stop displaying when it reaches the input user
				if(i > 0 && (i % maxCountries == 0))
                {
					//ask user if then want to continue
                    Console.WriteLine("\nHit enter to contine or anything else to quit: ");
					//verify if the input isn't enter
					if (Console.ReadLine() != "")
						//break the loop if it's not 
						break;
                }

				Country country = countries[i];
                Console.WriteLine($"{i+1} : {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)} : {country.Name}");
            }

			//shows the number of elements in the list
			Console.WriteLine($"\n{countries.Count} countries");

			Console.ReadLine();
		}
	}
}
