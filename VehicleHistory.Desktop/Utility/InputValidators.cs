using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VehicleHistoryDesktop.Utility
{
    public static class InputValidators
    {
        public static List<string> ValidManufacturerCodes = new List<string>(new[]
        {
            "JA",
            "JDA",
            "JF",
            "JH",
            "JK",
            "JM",
            "JN",
            "JS",
            "JT",
            "JY",
            "KL",
            "KMH",
            "KN",
            "LC0",
            "MAL",
            "NLH",
            "SAL",
            "SAJ",
            "SCC",
            "SUA",
            "SUD",
            "SUF",
            "SUJ",
            "SUL",
            "SUP",
            "SUR",
            "SUS",
            "SUU",
            "SUZ",
            "SW9",
            "SX9",
            "SZ9",
            "SZR",
            "TMA",
            "TMB",
            "TRA",
            "TRU",
            "U5Y",
            "VF1",
            "VF3",
            "VF7",
            "VSS",
            "WAU",
            "WBA",
            "WBS",
            "WDB",
            "WMA",
            "WMW",
            "WP0",
            "W0L",
            "WVW",
            "WV1",
            "WV2",
            "YK1",
            "YS3",
            "YV1",
            "ZDF",
            "ZFA",
            "ZFF",
            "1FB",
            "1FC",
            "1FD",
            "1FM",
            "1FU",
            "1FV",
            "1F9",
            "1G",
            "1GC",
            "1GM",
            "1H",
            "1L",
            "1M",
            "1N",
            "1VW",
            "1YV",
            "2FB",
            "2FC",
            "2FM",
            "2FT",
            "2FU",
            "2FV",
            "2M",
            "2G",
            "2G1",
            "2G1",
            "2HM",
            "2WK",
            "2WL",
            "2WM",
            "3FE",
            "3G",
            "3VW",
            "9BW",
            "4F",
            "4M",
            "4S",
            "4US",
            "VT",
            "4V1",
            "4V2",
            "4V3",
            "4V4",
            "4V5",
            "4V6",
            "4VL",
            "4VM",
            "4VZ",
            "5L",
            "6F",
            "6H",
            "6MM",
            "6T1",
            "SAR",
        });

        public static bool NotEmpty(string input, string validatedField, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = "Pole " + validatedField + " nie może być puste";
                return false;
            }

            errorMessage = "";
            return true;
        }

        public static bool Email(string input, out string errorMessage)
        {
            if (!Regex.IsMatch(input, "\\b[A-Za-z0-9._%+-]+@[A-Za-z0-9]+\\.[A-Za-z]{2,}\\b"))
            {
                errorMessage = "Nieprawidłowy format adresu E-Mail";
                return false;
            }

            errorMessage = "";
            return true;
        }

        public static bool NewPasswordConfirm(string input, string otherFieldInput, out string errorMessage)
        {
            if (input != otherFieldInput)
            {
                errorMessage = "Warości wpisane w pola muszą być jednakowe";
                return false;
            }

            errorMessage = "";
            return true;
        }

        public static bool DigitsOnly(string input, string validatedField, out string errorMessage)
        {
            if (!NotEmpty(input, validatedField, out errorMessage))
            {
                return false;
            }
            if (!Regex.IsMatch(input, "\\b[0-9]+\\b"))
            {
                errorMessage = "Nieprawidłowy format danych";
                return false;
            }

            errorMessage = "";
            return true;
        }

        public static bool Vin(string input, string validatedField, out string errorMessage)
        {
            if (!NotEmpty(input, validatedField, out errorMessage))
            {
                return false;
            }
            if (!Regex.IsMatch(input, "\\b[A-HJ-NPR-Z1-9]{17}\\b")) // VINs contain letters and numbers except 0, O, I and U 
            {
                errorMessage = "Nieprawidłowy format numeru VIN";
                return false;
            }

            if (!ValidManufacturerCodes.Contains(input.Substring(0, 3)) &&
                !ValidManufacturerCodes.Contains(input.Substring(0, 2)))
            {
                errorMessage = "Nieznany identyfikator producenta";
                return false;
            }
            errorMessage = "";
            return true;
        }

        public static bool Range(IComparable valueFrom, IComparable valueTo, out string errorMessage)
        {
            if (valueFrom.CompareTo(valueTo) > 0)
            {
                errorMessage = "Wartość \"od\" musi być mniejsza lub równa wartości \"do\"";
                return false;
            }

            errorMessage = "";
            return true;
        }
    }
}
    