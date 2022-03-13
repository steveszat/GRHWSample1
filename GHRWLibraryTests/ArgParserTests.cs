using GRHWLibrary;
using System.Collections.Generic;
using Xunit;

namespace GHRWLibraryTests
{
    public class ArgParserTests
    {
        [Theory]
        [InlineData(",", ',')]
        [InlineData("|", '|')]
        [InlineData("s", ' ')]
        [InlineData("xyz", ',')]
        public void GetDelimiterTest(string delimString, char expectedResult)
        {

            Dictionary<string, string> args =
                new Dictionary<string, string>()
                {
                    { "path", @"D:\Temp" },
                    { "sort", "color" },
                    { "irrelevant", "something" },
                    { "delim", delimString }

                };
            char delimiter = ArgParser.GetDelimiter(args);
            Assert.Equal(expectedResult, delimiter);
        }

        [Theory]
        [InlineData("sort", "color")]
        [InlineData("sort", "birthdate")]
        [InlineData("sort", "name")]
        [InlineData("nothing", "none")]
        public void GetSortByTest(string key, string sort)
        {
            Dictionary<string, string> args =
            new Dictionary<string, string>()
            {
                { "otherKey", "something" },
                {"path", "somepath" },
                { key, sort },
                { "delim", "somedelim" }

            };
            string sortBy = ArgParser.GetSortBy(args);
            Assert.Equal(sort, sortBy);
        }

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