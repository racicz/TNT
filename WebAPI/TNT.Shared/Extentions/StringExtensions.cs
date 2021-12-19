using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TNT.Shared;

namespace TNT.Shared.Extentions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        public static bool IsNullOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);

        public static string ReturnNullIfNullOrWhiteSpace(this string str) => str.IsNullOrWhiteSpace() ? null : str;

        public static string ToCamelCase(this string str)
        {
            if (string.IsNullOrEmpty(str) || !char.IsUpper(str[0]))
            {
                return str;
            }

            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                bool hasNext = (i + 1 < chars.Length);
                if (i > 0 && hasNext && !char.IsUpper(chars[i + 1]))
                {
                    break;
                }

                chars[i] = char.ToLower(chars[i], CultureInfo.InvariantCulture);
            }

            return new string(chars);
        }

        public static string ToCharEncoding(this string str, string symbol, string defaultValue = "")
        {
            if (!str.IsNullOrWhiteSpace() && !symbol.IsNullOrWhiteSpace())
            {
                return $"{symbol}{str}{symbol}".Trim();
            }
            return defaultValue;
        }

        public static string ExtractMessage(this string str)
        {
            // Format: Error: [51000] Procedure: [SP_Name] Line: [172] Message: [Error message]
            var message = Regex.Match(str, @"Message: (.+)", RegexOptions.Singleline).Groups[1].Value;

            return message.TrimStart("[").TrimEnd("]");
        }

        public static string RemoveSingleTickForProcedure(this string str)
        {
            return !string.IsNullOrEmpty(str) ? str.Replace("'", "''") : string.Empty;
        }

        public static string TrimStart(this string target, string trimChars) => target.TrimStart(trimChars.ToCharArray());

        public static string TrimEnd(this string target, string trimChars) => target.TrimEnd(trimChars.ToCharArray());

        /// <summary>
        /// $5 => $5
        /// 5  => $5.00
        /// "" => if addDollarForZeroAmount is true then $0.00 else 0.00
        /// 0  => $0.00
        /// </summary>
        public static string ToCurrencyFormat(this string amount, bool addDollarForZeroAmount = false) => amount.Contains("$") ? amount : (amount.IsNullOrWhiteSpace() ? (addDollarForZeroAmount ? Constant.ZeroAmountWithDollarSymbol : Constant.ZeroAmount) : $"{Convert.ToDecimal(amount):C}");
        public static string ToCurrencyFormat(this decimal amount) => $"{amount:C}";

        public static string JoinRows<TItem>(this IEnumerable<TItem> enumerable, string separator) => string.Join(separator, enumerable);

        public static string ToString<T>(this IEnumerable<T> enumerable, string separator) => enumerable.JoinRows(separator);

        public static bool StringContains(this string source, string toCheck) => source.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;

        public static string Replace(this string str, char[] separators = null, string newSeparator = "")
        {
            string[] temp = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return string.Join(newSeparator, temp);
        }

        public static bool IsValidEmail(this string inputEmail)
        {
            Regex re = new Regex(Constant.EmailRegex);
            return re.IsMatch(inputEmail);
        }

        public static string Format(this string value, object arg0)
        {
            return string.Format(value, arg0);
        }

        public static string Format(this string value, params object[] args)
        {
            return string.Format(value, args);
        }

        /// bool result = "CoreSystem".In("CoreSystem", "Library");
        public static bool In(this string value, params string[] stringValues)
        {
            foreach (string otherValue in stringValues)
                if (IsEqual(value, otherValue))
                    return true;

            return false;
        }

        public static bool IsEqual(this string strA, string strB)
        {
            return strA.Equals(strB, StringComparison.OrdinalIgnoreCase);
        }

        public static string GetCapitalLetters(this string str)
        {
            return string.Concat(str.Where(c => c >= 'A' && c <= 'Z'));
        }

        public static string Split(this string str, char symbol, int index)
        {
            var strSplit = str.Split(symbol);
            return strSplit.Count() > 1 ? strSplit[index] : str;
        }


        public static string SplitAndIgnoreLastOne(this string str, char symbol)
        {
            var strSplit = str.Split(symbol);
            return strSplit.Count() == 1 ? str : strSplit.Take(strSplit.Length - 1).JoinRows(symbol.ToString());
        }

        public static string ObjectToString(this object objStr, string matchStr = "", string replaceStr = "")
        {
            string str = Convert.ToString(objStr);
            return !matchStr.IsNullOrWhiteSpace() && str.IsEqual(matchStr) ? replaceStr : str;
        }

        public static string Repeat(this string str, int count)
        {
            return Enumerable.Repeat(str, count)
                             .Aggregate(new StringBuilder(), (sb, s) => sb.Append(s))
                             .ToString();
        }

        public static bool TryParseJson<T>(this string obj, out T result)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.MissingMemberHandling = MissingMemberHandling.Error;

                result = JsonConvert.DeserializeObject<T>(obj, settings);
                return true;
            }
            catch (Exception)
            {
                result = default(T);
                return false;
            }
        }
    }
}
