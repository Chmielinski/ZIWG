using System.Text.RegularExpressions;
using VehicleHistory.Logic.Models.Utility;

namespace VehicleHistory.Logic.Helpers
{
    public static class VinValidator
    {
        public static void Validate(this string vin)
        {
            if (vin.Length != 17)
            {
                throw new AppException("Invalid VIN length.");
            }

            if (!Regex.IsMatch(vin, "\\b[A-HJ-NPR-Z1-9]{17}\\b"))
            {
                throw new AppException("Invalid pattern.");
            }
        }
    }
}
