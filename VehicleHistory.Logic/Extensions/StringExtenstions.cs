namespace VehicleHistory.Logic.Extensions
{
    public class StringExtenstions
    {
        public static string ToFullAddress(string line1, string zipCode, string line2, string aptNumber = null)
        {
            if (IsValid(aptNumber))
            {
                return $"{line1}/{aptNumber},<br />{zipCode} {line2}";
            }
            return $"{line1},<br />{zipCode} {line2}";
        }

        public static bool IsValid(string input)
        {
            return !string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input);
        }
    }
}
