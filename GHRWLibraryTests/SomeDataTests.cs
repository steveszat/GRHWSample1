using GRHWLibrary;
using Xunit;

namespace GHRWLibraryTests
{
    public class SomeDataTests
    {
        [Fact]
        public void SomeDataToStringTest()
        {
            SomeData someData = new SomeData()
            {
                LastName = "LastName",
                FirstName = "FirstName",
                Email = "email@email.com",
                FavoriteColor = "Blue",
                DateOfBirth = new System.DateTime(2012, 12, 12)
            };
            string expected = "LastName,FirstName,email@email.com,Blue,12/12/2012";
            string toString = someData.ToString();
            Assert.Equal(expected, toString);   
               
        }

        [Fact]
        public void SomeDataToStringDefaultDateTest()
        {
            SomeData someData = new SomeData()
            {
                LastName = "LastName",
                FirstName = "FirstName",
                Email = "email@email.com",
                FavoriteColor = "Blue"
            };
            string expected = "LastName,FirstName,email@email.com,Blue,1/1/0001";
            string toString = someData.ToString();
            Assert.Equal(expected, toString);

        }

        [Fact]
        public void SomeDataToStringEmptyTest()
        {
            SomeData someData = new SomeData();
            string expected = "[empty],[empty],[empty],[empty],1/1/0001";
            string toString = someData.ToString();
            Assert.Equal(expected, toString);

        }
    }
}
