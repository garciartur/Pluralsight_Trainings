using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pluralsight.BegCShCollections.ReadAllCountries
{
	class CsvReader
	{
		private string _csvFilePath;

		public CsvReader(string csvFilePath)
		{
			this._csvFilePath = csvFilePath;
		}

		public List<Country> ReadAllCountries()
		{
			List<Country> countries = new List<Country>();

			//creates a disposable structure to close the file after using it (I/O)
			using (StreamReader reader = new StreamReader(_csvFilePath))
            {
				//read the head does nothi with it - discard 
				reader.ReadLine();
				//creates the var to receive line and control the loop
				string csvLine;

				//while there is line to be read...
				while ((csvLine = reader.ReadLine()) != null)
                {
					//add Country instances to the list 
					countries.Add(ReadCountryFromCsvLine(csvLine));
                }
            }

			return countries;
		}

		//receive the scv line and return a Country
		public Country ReadCountryFromCsvLine(string csvLine)
		{
			//split the line informations and place in an array
			string[] parts = csvLine.Split(',');
			//create string to receive the informations
			string name;
			string code;
			string region;
			string pop;

			//to handle countries that have ',' in their names (5 parts) and unexpected cases
			switch (parts.Length)
            {
				//expected case
				case 4:
					//placing the values
					name = parts[0];
					code = parts[1];
					region = parts[2];
					pop = parts[3];
					break;

				//expected case - Egypt has a ',' in its name
				case 5:
					//placing the values - it's a ugly way to do that kkk
					name = parts[0] + ", " + parts[1];
					name = name.Replace("\"", null).Trim();
					code = parts[2];
					region = parts[3];
					pop = parts[4];
					break;

				//unexpected case  - handle exception
				default:
					throw new Exception($"Can't parse country from csvLine: {csvLine}");
			}

			//parse pop string into population int
			int.TryParse(pop, out int population);

			//returns an instance of Country
			return new Country(name, code, region, population);
		}

		//when you use a for to remove / add item in a list is better to use index backwards, cause the index change when the list is modified
		//foreach is readonly
		public void RemoveCommaCountries(List<Country> countries)
        {
			for (int i = countries.Count - 1; i >= 0; i--)
            {
				if (countries[i].Name.Contains(','))
					countries.RemoveAt(i);
            }

			//you can use a list method that remove all items that satisfy a lambda expression - way much simpler
			//countries.RemoveAll(_ => _.Name.Contains(','));
        }

	}
}
