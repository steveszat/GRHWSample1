using GRHWLibrary;
using System;
using Xunit;

namespace GHRWLibraryTests
{
    public class ValidationTests
    {
        [Fact]
        public void IsValidBirthDateDateTooOldTest()
        {
            DateTime minDoB = DateTime.Now.AddYears(-80);
            DateTime maxDoB = DateTime.Now.AddYears(-18);
            DateTime tooOld = DateTime.Now.AddYears(-81);
            bool isValid = Validation.IsValidBirthDate(tooOld, minDoB, maxDoB);
            Assert.False(isValid);
        }

        [Fact]
        public void IsValidBirthDateDateTooYoungTest()
        {
            DateTime minDoB = DateTime.Now.AddYears(-80);
            DateTime maxDoB = DateTime.Now.AddYears(-18);
            DateTime tooYoung = DateTime.Now.AddYears(-12);
            bool isValid = Validation.IsValidBirthDate(tooYoung, minDoB, maxDoB);
            Assert.False(isValid);
        }

        [Fact]
        public void IsValidBirthDateDateValidTest()
        {
            DateTime minDoB = DateTime.Now.AddYears(-80);
            DateTime maxDoB = DateTime.Now.AddYears(-18);
            DateTime validAge = DateTime.Now.AddYears(-40);
            bool isValid = Validation.IsValidBirthDate(validAge, minDoB, maxDoB);
            Assert.True(isValid);
        }

        [Fact]
        public void IsValidBirthDateStringInvalidTest()
        {
            DateTime minDoB = DateTime.Now.AddYears(-80);
            DateTime maxDoB = DateTime.Now.AddYears(-18);
            string dateString = "not a valid date string";
            bool isValid = Validation.IsValidBirthDate(dateString, minDoB, maxDoB);
            Assert.False(isValid);
        }

        [Fact]
        public void IsValidDateStringInvalidTest()
        {
            string dateString = "not a valid date string";
            bool isValid = Validation.IsValidDate(dateString);
            Assert.False(isValid);
        }

        [Fact]
        public void IsValidDateStringValidTest()
        {
            string dateString = "2/2/2022";
            bool isValid = Validation.IsValidDate(dateString);
            Assert.True(isValid);
        }

        [Fact]
        public void IsValidDelimiterInvalidTest()
        {
            char delimiter = '-';
            bool isValid = Validation.IsValidDelimiter(delimiter);
            Assert.False(isValid);
        }

        [Theory]
        [InlineData(',')]
        [InlineData('|')]
        [InlineData('s')]
        public void IsValidDelimiterValidTest(char delimiter)
        {
            bool isValid = Validation.IsValidDelimiter(delimiter);
            Assert.True(isValid);
        }

        [Fact]
        public void IsValidEmailAddressInvalidTest()
        {
            string emailString = null;
            bool isValid = Validation.IsValidEmailAddress(emailString);
            Assert.False(isValid);
        }

        [Fact]
        public void IsValidEmailAddressValidTest()
        {
            string emailString = "steveszat@hotmail.com";
            bool isValid = Validation.IsValidEmailAddress(emailString);
            Assert.True(isValid);
        }


        [Fact]
        public void IsValidSomeDataInvalidDateOfBirthTest()
        {
            DateTime minDoB = DateTime.Now.AddYears(-80);
            DateTime maxDoB = DateTime.Now.AddYears(-18);
            SomeData someData = new SomeData
            {
                LastName = "Szatkowski",
                FirstName = "Steve",
                Email = "steveszat@hotmail.com",
                FavoriteColor = "Purple",
                DateOfBirth = DateTime.Now
            };

            bool isValid = Validation.IsValidSomeData(someData, minDoB, maxDoB);
            Assert.False(isValid);
        }

        [Fact]
        public void IsValidSomeDataInvalidEmailTest()
        {
            DateTime minDoB = DateTime.Now.AddYears(-80);
            DateTime maxDoB = DateTime.Now.AddYears(-18);
            SomeData someData = new SomeData
            {
                LastName = "Szatkowski",
                FirstName = "Steve",
                Email = null,
                FavoriteColor = "Purple",
                DateOfBirth = new DateTime(2002, 2, 2)
            };

            bool isValid = Validation.IsValidSomeData(someData, minDoB, maxDoB);
            Assert.False(isValid);
        }


        [Fact]
        public void IsValidSomeDataInvalidFavoriteColorTest()
        {
            DateTime minDoB = DateTime.Now.AddYears(-80);
            DateTime maxDoB = DateTime.Now.AddYears(-18);
            SomeData someData = new SomeData
            {
                LastName = "Szatkowski",
                FirstName = "Steve",
                Email = "steveszat@hotmail.com",
                FavoriteColor = null,
                DateOfBirth = new DateTime(2002, 2, 2)
            };

            bool isValid = Validation.IsValidSomeData(someData, minDoB, maxDoB);
            Assert.False(isValid);
        }

        [Fact]
        public void IsValidSomeDataInvalidFirstNameTest()
        {
            DateTime minDoB = DateTime.Now.AddYears(-80);
            DateTime maxDoB = DateTime.Now.AddYears(-18);
            SomeData someData = new SomeData
            {
                LastName = "Szatkowski",
                FirstName = null,
                Email = "steveszat@hotmail.com",
                FavoriteColor = "Purple",
                DateOfBirth = new DateTime(2002, 2, 2)
            };

            bool isValid = Validation.IsValidSomeData(someData, minDoB, maxDoB);
            Assert.False(isValid);
        }

        [Fact]
        public void IsValidSomeDataInvalidLastNameTest()
        {
            DateTime minDoB = DateTime.Now.AddYears(-80);
            DateTime maxDoB = DateTime.Now.AddYears(-18);
            SomeData someData = new SomeData
            {
                LastName = null,
                FirstName = "Steve",
                Email = "steveszat@hotmail.com",
                FavoriteColor = "Purple",
                DateOfBirth = new DateTime(2002, 2, 2)
            };

            bool isValid = Validation.IsValidSomeData(someData, minDoB, maxDoB);
            Assert.False(isValid);
        }

        [Fact]
        public void IsValidSomeDataValidTest()
        {
            DateTime minDoB = DateTime.Now.AddYears(-80);
            DateTime maxDoB = DateTime.Now.AddYears(-18);
            SomeData someData = new SomeData
            {
                LastName = "Szatkowski",
                FirstName = "Steve",
                Email = "steveszat@hotmail.com",
                FavoriteColor = "Purple",
                DateOfBirth = new DateTime(2002, 2, 2)
            };

            bool isValid = Validation.IsValidSomeData(someData, minDoB, maxDoB);
            Assert.True(isValid);
        }

        [Fact]
        public void IsValidSomeDataStringsInvalidTest()
        {
            DateTime minDoB = DateTime.Now.AddYears(-80);
            DateTime maxDoB = DateTime.Now.AddYears(-18);

            bool isValid = Validation
                .IsValidSomeData(null, "Steve",
                "steveszat@hotmail.com", "Blue",
                DateTime.Now.AddYears(-22).ToString(), minDoB, maxDoB);
            Assert.False(isValid);
        }

        [Fact]
        public void IsValidSomeDataStringsValidTest()
        {
            DateTime minDoB = DateTime.Now.AddYears(-80);
            DateTime maxDoB = DateTime.Now.AddYears(-18);

            bool isValid = Validation
                .IsValidSomeData("Szatkowski", "Steve", 
                "steveszat@hotmail.com", "Blue", 
                DateTime.Now.AddYears(-22).ToString(), minDoB, maxDoB);
            Assert.True(isValid);
        }
    }
}
