using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommonBehaviour
{
    internal class InternalTools
    {
        public static string GetStringEnumerationValue<EnumType>(EnumType value)
        {
            if (typeof(EnumType).IsEnum)
            {
                if (!String.IsNullOrEmpty(value.ToString()))
                { 
                    return value.ToString(); 
                }
            }

            return String.Empty;
        }

        public static EnumType GetEnumerationValue<EnumType>(string stringValue, EnumType defaultValue)
        {
            if (typeof(EnumType).IsEnum)
            {
                if (Enum.IsDefined(typeof(EnumType), stringValue))
                {
                    return (EnumType)Enum.Parse(typeof(EnumType), stringValue);
                }
            }

            return defaultValue;
        }

        public static string GetFullName(string FirstName, string LastName)
        {
            return FirstName + " " + LastName;
        }

        public static int GetNewPIN()
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);
            int minValue = 1000, maxValue = 9999;

            return random.Next(minValue, maxValue);
        }

        public static List<int> ConvertPINToList(int PIN)
        {
            List<int> pins = new List<int>();
            char[] numbers = PIN.ToString().ToCharArray();

            foreach (char number in numbers)
            {
                pins.Add(number);
            }

            return pins;
        }

        public static int ConvertPINToInteger(List<int> PIN)
        {
            string pinInString = String.Empty;
            foreach (int pin in PIN)
            {
                pinInString += pin;
            }

            return int.Parse(pinInString);
        }

        /// <summary>
        /// This function manages the datetime in UTC, so every function/property/variable of type datetime must use it.
        /// </summary>
        /// <returns>
        /// Datetime in UTC
        /// </returns>

        public static DateTime GetDateTimeNow()
        {
            return DateTime.UtcNow;
        }

        /// <summary>
        /// This function manages the date in UTC, so every function/property/variable of type datetime must use it.
        /// </summary>
        /// <returns>
        /// DateOnly in UTC
        /// </returns>

        public static DateOnly GetDateNow()
        {
            return DateOnly.Parse(GetDateTimeNow().ToString());
        }

        /// <summary>
        /// This function evaluates the date and time in UTC, to return a boolean value if it is between the given minimum date and maximum date.
        /// </summary>
        /// <returns>
        /// return true if the date is between minDatetime and maxDatetime
        /// </returns>
        public static bool DatetimeBetweenDates(DateTime date, DateTime minDatetime, DateTime maxDatetime)
        {
            return minDatetime.ToUniversalTime().CompareTo(date.ToUniversalTime()) == -1 
                && date.ToUniversalTime().CompareTo(maxDatetime.ToUniversalTime()) == -1;
        }

        public static string Encrypt(string encryptionKey, string value)
        {
            return value;
        }

        public static string Dencrypt(string encryptionKey, string value)
        {
            return value;
        }
    }
}
