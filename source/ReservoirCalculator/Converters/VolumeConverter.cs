using ReservoirCalculator.Model;
using System;

namespace ReservoirCalculator.Converters
{
    class VolumeConverter
    {
        internal const double CubicFeetToCubicMeterRelation = 35.31467;
        internal const double CubicFeetToOilBarrelsRelation = 0.17811;
        internal const double CubicMetersToOilBarrelsRelation = 6.289811;
        internal static double Convert(double value, VolumeUnit from, VolumeUnit to)
        {
            switch (from)
            {
                case VolumeUnit.CubicFeet:
                    return FromCubicFeetTo(value, to);
                case VolumeUnit.CubicMeters:
                    return FromCubicMeeterTo(value, to);
                case VolumeUnit.Barrels:
                    return FromBarrelsTo(value, to);
                default:
                    throw new NotSupportedException($"Conversion from {from} to {to} is not supported.");
            }
        }

        private static double FromBarrelsTo(double value, VolumeUnit to)
        {
            switch (to)
            {
                case VolumeUnit.CubicFeet:
                    return value / CubicFeetToOilBarrelsRelation;
                case VolumeUnit.CubicMeters:
                    return value / CubicMetersToOilBarrelsRelation;
                case VolumeUnit.Barrels:
                    return value;
                default:
                    throw new NotSupportedException($"Conversion from Oil Barrels to {to} is not supported.");
            }
        }

        private static double FromCubicFeetTo(double value, VolumeUnit to)
        {
            switch (to)
            {
                case VolumeUnit.CubicFeet:
                    return value;
                case VolumeUnit.CubicMeters:
                    return value / CubicFeetToCubicMeterRelation;
                case VolumeUnit.Barrels:
                    return value * CubicFeetToOilBarrelsRelation;
                default:
                    throw new NotSupportedException($"Conversion from cubic feet to {to} is not supported.");
            }
        }

        private static double FromCubicMeeterTo(double value, VolumeUnit to)
        {
            switch (to)
            {
                case VolumeUnit.CubicFeet:
                    return value * CubicFeetToCubicMeterRelation;
                case VolumeUnit.CubicMeters:
                    return value;
                case VolumeUnit.Barrels:
                    return value * CubicMetersToOilBarrelsRelation;
                default:
                    throw new NotSupportedException($"Conversion from cubic meter to {to} is not supported.");
            }
        }
    }
}
