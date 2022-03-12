// See https://aka.ms/new-console-template for more information

using GRHWLibrary;

var parsedArgs = ArgParser.ParseArgs(args);

if (args.Length == 0 || !parsedArgs.ContainsKey("path"))
{
    // Normally this and other messages would be stored elsewhere
    // to make them easy to modify without having to recompile
    Console.WriteLine("\"/path\" argument is required in the format \"/path filepath\", where \"filepath\" is replaced with a valid path to a file containing delimited data.");
}
else
{
    string filePath = parsedArgs["path"];

    {

        char delimiter = GetDelimiter(args, parsedArgs);

        try
        {
            var data =
                new SomeDataProvider()
                .GetData(new SomeFileReader(filePath), delimiter)
                 .ToList<SomeData>();

            data = SortData(parsedArgs, data);

            foreach (var line in data)
            {
                Console.WriteLine(line);
            }

        }
        // for sake of brevity, I am only catching generic exception
        catch (Exception)
        {

            throw;
        }

    }

    static char GetDelimiter(string[] args, Dictionary<string, string> parsedArgs)
    {
        char delimiter = ','; // comma is default delimiter
        if (parsedArgs.ContainsKey("delim"))
        {
            char delimArg = parsedArgs["delim"].First<char>();
            switch (delimArg)
            {
                case '|':
                    delimiter = '|';
                    break;
                case ' ':
                    delimiter = ' ';
                    break;
                default:
                    delimiter = ',';
                    Console.WriteLine("Invalid delimiter specified. Using comma by default.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("To specify the delimiter, add the argument \"/delim\" followed by a value of a space, a comma, or a piping symbol");
        }
        return delimiter;
    }

    static List<SomeData> SortData(Dictionary<string, string> parsedArgs, List<SomeData> data)
    {
        if (parsedArgs.ContainsKey("sort"))
        {
            string sortBy = parsedArgs["sort"];
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
        }

        return data;
    }
}