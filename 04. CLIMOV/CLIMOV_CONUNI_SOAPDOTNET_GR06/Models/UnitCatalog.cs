namespace CLIMOV_CONUNI_SOAPDOTNET_GR06.Models
{
    public static class UnitCatalog
    {
        public static readonly string[] Categories =
        {
            "Masa",
            "Longitud",
            "Temperatura"
        };

        public static string[] GetUnits(string? category)
        {
            if (string.Equals(category, "Masa", StringComparison.OrdinalIgnoreCase))
                return new string[] { "kg", "g", "lb", "oz", "t" };

            if (string.Equals(category, "Longitud", StringComparison.OrdinalIgnoreCase))
                return new string[] { "m", "cm", "km", "in", "ft" };

            if (string.Equals(category, "Temperatura", StringComparison.OrdinalIgnoreCase))
                return new string[] { "C", "F", "K", "R" };

            return Array.Empty<string>();
        }
    }
}