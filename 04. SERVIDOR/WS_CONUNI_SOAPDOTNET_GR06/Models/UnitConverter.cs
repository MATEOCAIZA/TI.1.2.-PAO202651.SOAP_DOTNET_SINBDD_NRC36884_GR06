using System;
using System.Collections.Generic;

namespace ec.edu.monster.modelo
{
    public static class UnitConverter
    {
        private static readonly Dictionary<string, double> MassToKg = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
        {
            { "kg", 1d },
            { "g", 0.001d },
            { "lb", 0.45359237d },
            { "oz", 0.028349523125d },
            { "t", 1000d }
        };

        private static readonly Dictionary<string, double> LengthToM = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
        {
            { "m", 1d },
            { "cm", 0.01d },
            { "km", 1000d },
            { "in", 0.0254d },
            { "ft", 0.3048d }
        };

        public static double Convert(string category, string fromUnit, string toUnit, double value)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentException("La categoria es requerida.", nameof(category));
            }

            if (string.IsNullOrWhiteSpace(fromUnit))
            {
                throw new ArgumentException("La unidad de origen es requerida.", nameof(fromUnit));
            }

            if (string.IsNullOrWhiteSpace(toUnit))
            {
                throw new ArgumentException("La unidad de destino es requerida.", nameof(toUnit));
            }

            fromUnit = fromUnit.Trim();
            toUnit = toUnit.Trim();

            if (!UnitCatalog.IsValidUnit(category, fromUnit))
            {
                throw new ArgumentException("Unidad de origen no valida para la categoria.", nameof(fromUnit));
            }

            if (!UnitCatalog.IsValidUnit(category, toUnit))
            {
                throw new ArgumentException("Unidad de destino no valida para la categoria.", nameof(toUnit));
            }

            if (UnitCatalog.IsCategory(category, UnitCatalog.CategoryMass))
            {
                return ConvertByFactor(value, fromUnit, toUnit, MassToKg);
            }

            if (UnitCatalog.IsCategory(category, UnitCatalog.CategoryLength))
            {
                return ConvertByFactor(value, fromUnit, toUnit, LengthToM);
            }

            if (UnitCatalog.IsCategory(category, UnitCatalog.CategoryTemperature))
            {
                return ConvertTemperature(value, fromUnit, toUnit);
            }

            throw new ArgumentException("Categoria no soportada.", nameof(category));
        }

        private static double ConvertByFactor(double value, string fromUnit, string toUnit, Dictionary<string, double> factors)
        {
            var baseValue = value * factors[fromUnit];
            return baseValue / factors[toUnit];
        }

        private static double ConvertTemperature(double value, string fromUnit, string toUnit)
        {
            var kelvin = ToKelvin(value, fromUnit);
            return FromKelvin(kelvin, toUnit);
        }

        private static double ToKelvin(double value, string fromUnit)
        {
            switch (fromUnit.Trim().ToUpperInvariant())
            {
                case "C":
                    return value + 273.15d;
                case "F":
                    return (value - 32d) * (5d / 9d) + 273.15d;
                case "K":
                    return value;
                case "R":
                    return value * (5d / 9d);
                default:
                    throw new ArgumentException("Unidad de temperatura no valida.", nameof(fromUnit));
            }
        }

        private static double FromKelvin(double value, string toUnit)
        {
            switch (toUnit.Trim().ToUpperInvariant())
            {
                case "C":
                    return value - 273.15d;
                case "F":
                    return (value - 273.15d) * (9d / 5d) + 32d;
                case "K":
                    return value;
                case "R":
                    return value * (9d / 5d);
                default:
                    throw new ArgumentException("Unidad de temperatura no valida.", nameof(toUnit));
            }
        }
    }
}
