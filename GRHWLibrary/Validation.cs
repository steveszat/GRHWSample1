using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRHWLibrary
{
    /// <summary>
    /// For the sake of expediency 
    /// none of these validation methods are fully implemented
    /// </summary>
    public static class Validation
    {
   
        public static bool IsValidBirthDate(DateTime date, DateTime minValue,  DateTime maxValue)
        {
            return date >= minValue && date <= maxValue;
        }

        public static bool IsValidBirthDate(string dateString, DateTime minValue, DateTime maxValue)
        {
            return IsValidDate(dateString) 
                && IsValidBirthDate(DateTime.Parse(dateString), minValue, maxValue);   
        }

        public static bool IsValidDate(string dateString)
        {
            bool isValid = false;
            if (string.IsNullOrEmpty(dateString))
            {
                isValid = false;
            }
            else
            {
                DateTime date = new DateTime();
                if (DateTime.TryParse(dateString, out date))
                {
                    if (date > DateTime.MinValue)
                        isValid = true;
                }
            }
            return isValid;
        }

        public static bool IsValidDelimiter(char delimiter)
        {
            return delimiter == ',' || delimiter == '|' || delimiter == 's';

        }

        public static bool IsValidDelimiter(string delimiter)
        {
            return IsValidDelimiter(delimiter.First());
        }

        public static bool IsValidEmailAddress(string address)
        {
            if (address == null)
            {
                return false;
            }
            return true;
        }

        public static bool IsValidSomeData(SomeData someData, DateTime minDoB, DateTime maxDoB)
        {
            return IsValidSomeData(someData.LastName, someData.FirstName, someData.Email,
                someData.FavoriteColor, someData.DateOfBirth.ToString(),
                minDoB, maxDoB);
        }

        public static bool IsValidSomeData(string lastName, string firstName, 
            string email, string favoriteColor, string birthdate, 
            DateTime minDoB, DateTime maxDoB)
        {
            return lastName != null 
                && firstName != null 
                && IsValidEmailAddress(email)
                && favoriteColor != null 
                && IsValidBirthDate(birthdate, minDoB, maxDoB);   

        }
    }
}
