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

        char delimiter = ArgParser.GetDelimiter(parsedArgs);

        try
        {
            var dataProvider = new SomeDataProvider();
            var data = dataProvider
                
                .GetData(new SomeFileHandler(filePath), delimiter)
                 .ToList<SomeData>();
            string sortBy = ArgParser.GetSortBy(parsedArgs);
            data = dataProvider.SortData(sortBy, data);

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

}