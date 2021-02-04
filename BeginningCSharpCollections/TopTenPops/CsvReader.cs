using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pluralsight.BegCShCollections.TopTenPops
{
	class CsvReader
	{
		private string _csvFilePath;

		public CsvReader(string csvFilePath)
		{
			this._csvFilePath = csvFilePath;
		}

		public Country[] ReadFirstNCountries(int nCountries)
		{
			Country[] countries = new Country[nCountries];

			//creates a disposable structure to close the file after using it (I/O)
			using (StreamReader reader = new StreamReader(_csvFilePath))
            {
				//read the head does nothi with it - discard 
				reader.ReadLine();

				for (int i = 0; i < nCountries; i++)
                {
					//read the next line from csv file
					string csvLine = reader.ReadLine();
					//call the method to populate the array with instances of Country
					countries[i] = ReadCountryFromCsvLine(csvLine);
                }
            }

			return countries;
		}

		//receive the scv line and return a Country
		public Country ReadCountryFromCsvLine(string csvLine)
		{
			//parse the scv line
			string[] parts = csvLine.Split(new char[] { ',' });

			//place the values in the parameters
			string name = parts[0];
			string code = parts[1];
			string region = parts[2];
			int population = int.Parse(parts[3]);

			//returns an instance of Country
			return new Country(name, code, region, population);
		}

	}
}
