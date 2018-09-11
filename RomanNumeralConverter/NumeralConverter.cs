using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumeralConverter
{
    static class NumeralConverter
    {
        public static string Roman { get; private set; }
        public static string Arabic { get; private set; }
        private const int _arabicLimit = 4999;
        private static Dictionary<string, int> _romanNumeralValues = new Dictionary<string, int>()
        {
            { "I", 1 },
            { "V", 5 },
            { "X", 10 },
            { "L", 50 },
            { "C", 100 },
            { "D", 500 },
            { "M", 1000 }
        };
        private static Dictionary<int, int> _incrementations = new Dictionary<int, int>()
        {
            { 1, 5 },
            { 5, 10 },
            { 10, 50 },
            { 50, 100 },
            { 100, 500 },
            { 500, 1000 }
        };
        private static Dictionary<int, int> _decrementations = new Dictionary<int, int>()
        {
            { 1, -1 },
            { 5, 0 },
            { 10, 1 },
            { 50, 5 },
            { 100, 10 },
            { 500, 50 },
            { 1000, 100 }
        };
        private static Dictionary<int, string> _ones = new Dictionary<int, string>()
        {
            { 0, "" },
            { 1, "I" },
            { 2, "II" },
            { 3, "III" },
            { 4, "IV" },
            { 5, "V" },
            { 6, "VI" },
            { 7, "VII" },
            { 8, "VIII" },
            { 9, "IX" }
        };
        private static Dictionary<int, string> _tens = new Dictionary<int, string>()
        {
            { 0, "" },
            { 1, "X" },
            { 2, "XX" },
            { 3, "XXX" },
            { 4, "XL" },
            { 5, "L" },
            { 6, "LX" },
            { 7, "LXX" },
            { 8, "LXXX" },
            { 9, "XC" }
        };
        private static Dictionary<int, string> _hundreds = new Dictionary<int, string>()
        {
            { 0, "" },
            { 1, "C" },
            { 2, "CC" },
            { 3, "CCC" },
            { 4, "CD" },
            { 5, "D" },
            { 6, "DC" },
            { 7, "DCC" },
            { 8, "DCCC" },
            { 9, "CM" }
        };
        private static Dictionary<int, string> _thousands = new Dictionary<int, string>()
        {
            { 0, "" },
            { 1, "M" },
            { 2, "MM" },
            { 3, "MMM" },
            { 4, "MMMM" }
        };
        private static Dictionary<int, Dictionary<int, string>> _places = new Dictionary<int, Dictionary<int, string>>()
        {
            { 0, _ones },
            { 1, _tens },
            { 2, _hundreds },
            { 3, _thousands }
        };

        public static bool IsValidRomanValue(string roman, bool isStrictMode)
        {
            var arabic = RomanToArabic(roman, false);
            var isValidArabicValue = IsValidArabicValue(arabic);

            if (isStrictMode)
                return isValidArabicValue && FollowsRomanStyleRules(roman);
            else
                return isValidArabicValue;
        }

        private static bool FollowsRomanStyleRules(string roman)
        {
            var highValue = 0;
            var prevValue = 0;
            var consecutiveLows = 0;
            var consecutiveLowsLimit = 1;
            var consecutiveSame = 1;
            var consecutiveSameLimit = 3;
            List<int> usedFives = new List<int>();
            List<int> usedLows = new List<int>();
            foreach (var value in ReversedRomanValues(roman))
            {
                // V, L, and D cannot repeat.
                if (value.ToString().Contains("5"))
                {
                    if (usedFives.Any(uf => uf == value)) return false;
                    else usedFives.Add(value);
                }

                // A numeral lower than a higher numeral cannot appear on both sides of the higher numeral.
                if (value > highValue)
                {
                    highValue = value;
                    usedLows.Add(prevValue);
                }                
                if (usedLows.Any(ul => ul >= value)) return false;

                // Two numerals lower than a higher numeral cannot appear in a row to the left of the higher numeral.
                if (value < highValue)
                {
                    consecutiveLows++;
                    if (consecutiveLows > consecutiveLowsLimit || usedLows.Any(ul => ul == value))
                    {
                        return false;
                    }
                }
                else
                {
                    consecutiveLows = 0;
                }

                // Numerals less than M cannot appear more than 3 times in a row.
                // M cannot appear more than 4 times in a row.
                if (value == prevValue)
                {
                    consecutiveSame++;
                    if ((consecutiveSame > consecutiveSameLimit && value != _romanNumeralValues["M"]) ||
                    (consecutiveSame > consecutiveSameLimit + 1 && value == _romanNumeralValues["M"]))
                    {
                        return false;
                    }
                }
                else
                {
                    consecutiveSame = 1;
                }

                // A numeral to the left of another numeral cannot have a value less than that of 2 numerals
                // lower than the numeral on the right. (i.e. "IL" is not allowed, but "IX" is.)
                if (prevValue != 0 && value < _decrementations[prevValue]) return false;

                prevValue = value;
            }
            return true;
        }

        private static List<int> ReversedRomanValues(string roman)
        {
            List<string> numerals = roman.Select(c => c.ToString()).ToList();
            List<int> reversedValues = numerals.Select(n => _romanNumeralValues[n]).Reverse().ToList();
            return reversedValues;
        }

        public static string RomanToArabic(string roman, bool setRoman = true)
        {
            if (roman == string.Empty)
            {
                Roman = string.Empty;
                Arabic = string.Empty;
                return Arabic;
            }

            List<int> values = ReversedRomanValues(roman);
            
            int total = values[0];

            for (var i = 1; i < values.Count; i++)
            {
                if (values[i] >= values[i - 1]) total += values[i];
                else total -= values[i];
            }
            
            Arabic = total.ToString();
            if (setRoman) Roman = ArabicToRoman(Arabic);
            return Arabic;
        }

        public static bool IsValidArabicValue(string arabic)
        {
            try
            {
                if (arabic == string.Empty) arabic = "0";
                return Int32.Parse(arabic) <= _arabicLimit;
            }
            catch
            {
                return false;
            }            
        }
        
        public static string ArabicToRoman(string arabic)
        {
            if (arabic == string.Empty)
            {
                Arabic = string.Empty;
                Roman = string.Empty;
                return Roman;
            }
            
            List<string> numerals = arabic.Select(c => c.ToString()).ToList();
            List<int> values = numerals.Select(n => Int32.Parse(n)).Reverse().ToList();

            var romanNumerals = new List<string>();

            for (var i = 0; i < values.Count; i++)
            {
                romanNumerals.Add(_places[i][values[i]]);
            }

            Arabic = arabic;
            romanNumerals.Reverse();
            Roman = String.Join("", romanNumerals);
            return Roman;
        }
    }
}
