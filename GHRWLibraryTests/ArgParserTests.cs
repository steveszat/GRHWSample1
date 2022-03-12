using GRHWLibrary;
using Xunit;

namespace GHRWLibraryTests
{
    public class ArgParserTests
    {
        [Fact]
        public void ParseArgsTest1()
        {
            string path = @"D:\Temp\RandomData\randomdata.csv";
            char delimiter = ',';
            string sortBy = "COLOR";
            string[] args = { "/path", path, "/delim",  delimiter.ToString(), "/sort", sortBy };
            
            var result = ArgParser.ParseArgs(args);
            
            string pathParameter = result["path"];
            char delimiterParameter = result["delim"][0];
            string sortParameter = result["sort"];
      
            Assert.Equal(path.ToLower(), pathParameter);
            Assert.Equal(delimiterParameter, delimiter);
            Assert.Equal(sortBy.ToLower(), sortParameter);
        }
    }
}