using ReservoirCalculator.Converters;
using ReservoirCalculator.Interfaces;
using System;

namespace ReservoirCalculator.Model
{
    internal class Reservoir
    {
        #region Constant
        internal const double Tolerance = 0.00001;
        #endregion

        #region Properties
        IHorizon TopHorizon { get; set; }
        internal double CalculatedVolume { get; private set; }
        #endregion

        #region Constructor
        internal Reservoir(IHorizon topHorizon)
        {
            TopHorizon = topHorizon;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Calculates the volume between the two horizons
        /// and above the fluid contact
        /// </summary>
        /// <param name="baseHorizonRelativeDepth">Base Horizon depth in relation to top horizon in meters</param>
        /// <param name="fluidContactDepth">Fluid contact dept in meters</param>
        /// <param name="resultUnit"></param>
        /// <returns></returns>
        internal void CalculateVolume(double baseHorizonRelativeDepth, double fluidContactDepth, LengthUnit lengthUnit)
        {
            double totalVolume = 0;

            var cellArea = TopHorizon.CellArea;
            var baseDepth = LengthConverter.Convert(baseHorizonRelativeDepth, lengthUnit, TopHorizon.LengthUnit);
            var fluidContact = LengthConverter.Convert(fluidContactDepth, lengthUnit, TopHorizon.LengthUnit);

            foreach (var topNodeDepth in TopHorizon.Nodes)
            {
                //Step 1: Determine if base depth or fluid contact will be considered.
                double actualBaseDepth = Math.Min(topNodeDepth + baseDepth, fluidContact);

                //Step 2: Determine height between top horizon and actualBaseDepth.
                //Height greater than zero means there is oil & gas to be calculated
                //Negative value means top horizon is under fluid contact and will not be calculated
                double height = actualBaseDepth - topNodeDepth;

                if (height > 0) //top horizon is above 
                {
                    totalVolume += height * cellArea;
                }
            }

            CalculatedVolume = totalVolume;
        }
        #endregion
    }

    public enum VolumeUnit
    {
        Unknown,
        CubicMeters,
        CubicFeet,
        Barrels
    }
}
