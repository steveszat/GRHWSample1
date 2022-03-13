using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRHWLibrary
{
    public class SomeDataProvider : ISomeDataProvider<SomeData>
    {

        public List<SomeData> GetData(ISomeFileHandler fileReader, char delimiter)
        {
            var file = fileReader.ReadFile();
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

        public static bool IsDelimiterValid(char delimiter, int elementCount, string[] file)
        {
            return (from line in file
                    // each line should contain one less delimiter than elements
                    where line.Count(c => c == delimiter) == (elementCount - 1)
                    select line).Count()
                    ==
                    (from line in file
                     select line).Count();
        }

        public List<SomeData> SortData(string sortBy, List<SomeData> data)
        {

            switch (sortBy)
            {
                case "color":
                    data = data.OrderBy(d => d.FavoriteColor)
                        .ThenBy(d => d.LastName)
                        .ToList<SomeData>();
                    break;
                case "birthdate":
                    data = data.OrderBy(d => d.DateOfBirth)
                    .ToList<SomeData>();
                    break;
                case "name":
                    data = data.OrderByDescending(d => d.LastName)
                    .ToList<SomeData>();
                    break;
                default:
                    Console.WriteLine("To sort data, add the argument \"/sort\" followed by one of the following values: \"color\", \"birthdate\" or \"name\"");
                    break;

            }

            return data;
        }

    }


}
