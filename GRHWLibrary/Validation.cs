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

        public static bool IsValidDateString(string dateString)
        {
            bool isValid = false;
            if (string.IsNullOrEmpty(dateString))
            {
                isValid = false;
            }
            else
            {
                DateTime date = DateTime.Parse(dateString);
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
    }
}
