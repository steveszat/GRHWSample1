using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRHWLibrary
{
    public class SomeDataProvider : ISomeDataProvider
    {

        public List<SomeData> GetData(ISomeFileReader fileReader, char delimiter)
        {
            var file = fileReader.OpenFile();
            int numberOfElements = 5;
            if (IsDelimiterValid(delimiter, numberOfElements, file))
            {
                return (from line in
                            from line in file
                            select line.Split(delimiter)
                               .ToArray<string>()
                        select new SomeData()
                        {
                            LastName = line[(int)ArrayElement.LastName].Trim(),
                            FirstName = line[(int)ArrayElement.FirstName].Trim(),
                            Email = line[(int)ArrayElement.Email].Trim(),
                            FavoriteColor = line[(int)ArrayElement.FavoriteColor].Trim(),
                            DateOfBirth = DateTime.Parse(line[(int)ArrayElement.DoB].Trim())
                        }
                ).ToList<SomeData>(); 
            }
            else
            {
                throw new ArgumentException("Invalid delimiter");
            }

        }

        // Just doing a simple check to make sure each line
        // contains the correct number of delimiters
        private static bool IsDelimiterValid(char delimiter, int elementCount, string[] file)
        {
            return (from line in file
                    // each line should contain one less delimiter than elements
                    where line.Count(c => c == delimiter) == (elementCount - 1)
                    select line).Count() 
                    ==
                    (from line in file
                    select line).Count();
        }
    }
}
