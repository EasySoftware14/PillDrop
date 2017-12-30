using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PillDrop.Implementation.Implementation.Extensions
{
    public static class StringExtensions
    {
        private const string RemoveSpecialCharacters = @"[^0-9a-zA-Z]+";
        private const string RemoveSpaces = " ";
        private const int PositionInSubscriberNumberToAddsSpacesUntil = 1;

        private static readonly int[] StartingIndexForFormattingSubscriberNumber = { 0, 2, 5, 9, 13, 17 };
        private static readonly int[] TakeThisManyNumbersFromSubcriberNumber = { 2, 3, 4, 4, 3, 3 };

        public static string ToHash(this string value)
        {
            return MD5Hasher.GetMd5Hash(value);
        }

        public static string StripIllegalCharacters(this string value, params char[] chars)
        {
            var finalString = value;
            for (int i = 0; i < chars.Length; i++)
            {
                finalString = finalString.Replace(chars[i].ToString(), "");
            }
            return finalString;
        }

        public static string CropToStandardSms(this string value)
        {
            return value.CropTo(160);
        }

        public static string CropTo(this string value, int cropAtLength)
        {
            return value.Length <= cropAtLength ? value : value.Substring(0, cropAtLength);
        }

        public static DateTime? ToGmtDateTime(this string value)
        {
            if (value == null)
                return null;
            if (value.Length != 14)
                return null;
            int n;
            if (Int32.TryParse(value, out n))
                return null;

            try
            {
                int year = Int32.Parse("20" + value[0] + value[1]);
                int month = Int32.Parse(value.Substring(2, 2));
                int day = Int32.Parse(value.Substring(4, 2));
                int hour = Int32.Parse(value.Substring(6, 2));
                int minute = Int32.Parse(value.Substring(8, 2));
                int second = Int32.Parse(value.Substring(10, 2));
                int timezoneMinutesOffset = Int32.Parse(value.Substring(12, 2)) * (-15);
                var result = new DateTime(year, month, day, hour, minute, second, DateTimeKind.Utc);
                result.AddMinutes(timezoneMinutesOffset);
                return result;
            }
            catch
            {
                return null;
            }
        }

        public static string ToTitleCase(this string value)
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
        }

        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static string SafeSubstring(this string value, int startIndex, int length)
        {
            startIndex = IsStartIndexSafe(value, startIndex) ? startIndex : 0;

            if (value.Substring(startIndex).Length >= length)
                return value.Substring(startIndex, length);

            return value.Substring(startIndex);
        }

        public static bool IsStartIndexSafe(string value, int startIndex)
        {
            if (value.Length > startIndex)
                return true;
            else
                return false;
        }

        public static string SafeSubstring(this string value, int startIndex)
        {
            if (value.Length > startIndex)
                return value.Substring(startIndex);
            return string.Empty;
        }

        public static string UrlEncode(this string value)
        {
            return HttpUtility.UrlEncode(value);
        }

        public static string GetFormatEmails(this string value)
        {
            return value.ToLowerInvariant();
        }

        public static string Prefix(this string value)
        {
            if (value == null) return string.Empty;
            return value.Split(',').Length == 2 ? value.Split(',')[0] : string.Empty;
        }

        public static string SubscriberNumber(this string value)
        {
            if (value == null) return string.Empty;
            return value.Split(',').Length == 2 ? value.Split(',')[1] : value;
        }

        public static string FormatTelephoneNumber(this string telephoneNumber)
        {
            if (string.IsNullOrWhiteSpace(telephoneNumber))
                return "No contact number found.";

            if (!telephoneNumber.Contains(','))
            {
                return telephoneNumber;
            }

            var prefix = telephoneNumber.Split(',').ToList().First();
            var unformattedSubscriberNumber = telephoneNumber.Split(',').ToList().Last();

            if (string.IsNullOrWhiteSpace(prefix))
            {
                return "No prefix for the contact number found.";
            }

            if (string.IsNullOrWhiteSpace(unformattedSubscriberNumber))
            {
                return "No subscriber for the contact number found.";
            }

            var formattedSubcriberNumber = FormatSubscriberNumber(unformattedSubscriberNumber);
            var formattedContactNumber = string.Format("({0}) {1}", prefix, formattedSubcriberNumber);

            return formattedContactNumber;
        }

        private static string FormatSubscriberNumber(string subscriberNumber)
        {
            var stoppingPoint = 0;
            var formattedNumber = string.Empty;

            subscriberNumber = subscriberNumber.Replace(RemoveSpaces, "");
            subscriberNumber = Regex.Replace(subscriberNumber, RemoveSpecialCharacters, "");

            var lengthOfSubscriberNumber = subscriberNumber.Length;

            // Determines when to stop formatting the subscriber number based on the length of the number
            for (var i = 0; i < StartingIndexForFormattingSubscriberNumber.Length; i++)
            {
                if (StartingIndexForFormattingSubscriberNumber[i] <= lengthOfSubscriberNumber)
                {
                    stoppingPoint = i;
                }
            }

            // Formats the number into the correct format 00 000-0000-0000-000-000
            for (var i = 0; i <= stoppingPoint; i++)
            {
                if (i <= PositionInSubscriberNumberToAddsSpacesUntil)
                {
                    formattedNumber += string.Format("{0} ", subscriberNumber.Substring(StartingIndexForFormattingSubscriberNumber[i], TakeThisManyNumbersFromSubcriberNumber[i]));
                }
                else
                {
                    if (i == stoppingPoint)
                    {
                        var remainingDigits = subscriberNumber.Length - StartingIndexForFormattingSubscriberNumber[i];

                        if (remainingDigits == 0)
                        {
                            return formattedNumber;
                        }

                        formattedNumber += string.Format("-{0}", subscriberNumber.Substring(StartingIndexForFormattingSubscriberNumber[i], remainingDigits));
                        break;
                    }

                    formattedNumber = formattedNumber.Trim();
                    formattedNumber += string.Format("-{0}", subscriberNumber.Substring(StartingIndexForFormattingSubscriberNumber[i], TakeThisManyNumbersFromSubcriberNumber[i]));
                }
            }

            return formattedNumber;
        }
    }
}
