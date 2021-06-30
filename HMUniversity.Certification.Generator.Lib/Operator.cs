using System;
using System.Globalization;

namespace HMUniversity.Certification.Generator.Lib
{
    public class Operator
    {
        private static readonly CultureInfo Gb = new CultureInfo("en-GB");
        private const string Format = "MMMM yyyy";

        public static string GetDate()
        {
            return ConvertToOrdinal(DateTime.UtcNow.Day) + " of " +
                   DateTime.UtcNow.ToString(Format, Gb);
        }

        public static string ConvertToOrdinal(int d)
        {
            return d switch
            {
                < 0 or >= 40 => throw new ArgumentOutOfRangeException(),
                > 20 => GetTenOrdinal(d / 10) + "-" + ConvertToOrdinal(d % 10),
                _ => d switch
                {
                    1 => "first",
                    2 => "second",
                    3 => "third",
                    4 => "fourth",
                    5 => "fifth",
                    6 => "sixth",
                    7 => "seventh",
                    8 => "eighth",
                    9 => "ninth",
                    10 => "tenth",
                    11 => "eleventh",
                    12 => "twelfth",
                    13 => "thirteenth",
                    14 => "fourteenth",
                    15 => "fifteenth",
                    16 => "sixteenth",
                    17 => "seventeenth",
                    18 => "eighteenth",
                    19 => "ninteenth",
                    20 => "twentieth",
                    _ => ""
                }
            };
        }

        public static string GetTenOrdinal(int x)
        {
            return x switch
            {
                2 => "twenty",
                3 => "thirty",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}