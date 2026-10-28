using System;

namespace ec.edu.monster.modelo
{
    public static class UnitCatalog
    {
        public const string CategoryMass = "Masa";
        public const string CategoryLength = "Longitud";
        public const string CategoryTemperature = "Temperatura";

        public static readonly string[] Categories =
        {
            CategoryMass,
            CategoryLength,
            CategoryTemperature
        };

        public static readonly string[] MassUnits = { "kg", "g", "lb", "oz", "t" };
        public static readonly string[] LengthUnits = { "m", "cm", "km", "in", "ft" };
        public static readonly string[] TemperatureUnits = { "C", "F", "K", "R" };

        public static string[] GetUnits(string category)
        {
            if (IsCategory(category, CategoryMass))
            {
                return MassUnits;
            }

            if (IsCategory(category, CategoryLength))
            {
                return LengthUnits;
            }

            if (IsCategory(category, CategoryTemperature))
            {
                return TemperatureUnits;
            }

            return Array.Empty<string>();
        }

        public static bool IsCategory(string value, string category)
        {
            return string.Equals(value, category, StringComparison.OrdinalIgnoreCase);
        }
    }
}
