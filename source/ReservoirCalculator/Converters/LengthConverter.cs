using ReservoirCalculator.Model;
using System;

namespace ReservoirCalculator.Converters
{
    class LengthConverter
    {
        internal const double FeetToMeterRelation = 3.28084;

        internal static double Convert(double value, LengthUnit from, LengthUnit to)
        {
            switch (from)
            {
                case LengthUnit.Feet:
                    return FromFeetTo(value, to);
                case LengthUnit.Meter:
                    return FromMeterTo(value, to);
                default:
                    throw new NotSupportedException($"Conversion from {from} to {to} is not supported.");
            }
        }

        private static double FromFeetTo(double value, LengthUnit to)
        {
            switch (to)
            {
                case LengthUnit.Feet:
                    return value;
                case LengthUnit.Meter:
                    return value / FeetToMeterRelation;
                default:
                    throw new NotSupportedException($"Conversion from feet to {to} is not supported.");
            }
        }

        private static double FromMeterTo(double value, LengthUnit to)
        {
            switch (to)
            {
                case LengthUnit.Feet:
                    return value * FeetToMeterRelation;
                case LengthUnit.Meter:
                    return value;
                default:
                    throw new NotSupportedException($"Conversion from meter to {to} is not supported.");
            }
        }
    }
}
