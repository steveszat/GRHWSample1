namespace GRHWLibrary
{
    public static class ArgParser
    {

        public static char GetDelimiter(Dictionary<string, string> args)
        {
            char delimiter = ','; // comma is default delimiter
            if (args.ContainsKey("delim"))
            {
                char delimArg = args["delim"].First<char>();
                switch (delimArg)
                {
                    case '|':
                        delimiter = '|';
                        break;
                    case 's': // use 's' because command line parser ignores spaces
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

        /// <summary>
        /// Gets the sort by string from a dictionary
        /// </summary>
        /// <param name="args"></param>
        /// <returns>None if no sort string is found</returns>
        public static string GetSortBy(Dictionary<string, string> args)
        {
            string result = "none";
            if (args.ContainsKey("sort"))
            {
                result = args["sort"];
            }
            return result;
        }

        /// <summary>
        /// Parses an array of arguments into a dictionary
        /// </summary>
        /// <param name="args"></param>
        /// <returns>A dictionary of argument/value</returns>
        public static Dictionary<string, string> ParseArgs(string[] args)
        {
            // arguments should be
            // /path followed by the full file path containing the delimited data
            // /sortby followed by color, birthdate or name
            // /delim followed either a comma (,) a piping symbol (|) or the letter s, to indicate space delimited
            // delim defaults to comman
            // to keep things simple and focus on the task at hand
            // it is assumed that the arguments are entered correctly
            var keys = from key in args
                       where key.StartsWith('/')
                       select key.TrimStart('/').ToLower();
            var values = from value in args
                         where !value.StartsWith('/')
                         // use "s" to indicate space delimiter
                         select value.ToLower() == "s" ? " " : value.ToLower();

            return keys.Zip(values, (key, value) =>
                new KeyValuePair<string, string>(key, value))
                .ToDictionary(x => x.Key, x => x.Value); ;
        }
    }
}
