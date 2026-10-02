using System.Text.RegularExpressions;

namespace EliteJournalReader
{
    internal static class StringHelpers
    {
        public static string SplitCamelCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            if (input.Length > 0)
            {
                return Regex.Replace(input, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
            }

            return "None";
        }
    }}
