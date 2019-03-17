using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReservoirCalculator.Model;

namespace ReservoirCalculator.Test
{
    [TestClass]
    public class ReservoirTest
    {
        const double FeetToMeterRelation = 3.28084;

        /// <summary>
        /// Given I create a new top Horizon with 
        /// once cell at depth 0 
        /// and grid size equals one
        /// and cell size equals one feet
        /// When I calculate the volume with
        /// base depth offeset equals one feet
        /// and fluid contact equals one feet
        /// Then the results is equals one cubic feet
        /// </summary>
        [TestMethod]
        public void CalculateVolumeOneCubicFeet()
        {
            //Setup
            var topHorizon = new Horizon(
                new List<int>() { 0 }.AsReadOnly(),
                LengthUnit.Feet,
                new GridCell(1, 1));

            //Act
            var reservoir = new Reservoir(topHorizon);
           reservoir.CalculateVolume(1, 1, LengthUnit.Feet);

            //Assert
            Assert.AreEqual(1, reservoir.CalculatedVolume, Reservoir.Tolerance);
        }

        /// <summary>
        /// Given I create a new top Horizon with 
        /// once cell at depth 0 
        /// and grid size equals one
        /// and cell size equals one meter
        /// When I calculate the volume with
        /// base depth offeset equals one meter
        /// and fluid contact equals one meter
        /// Then the results is equals one cubic meter
        /// </summary>
        [TestMethod]
        public void CalculateVolumeOneCubicMeter()
        {
            //Setup
            var topHorizon = new Horizon(
                new List<int>() { 0 }.AsReadOnly(),
                LengthUnit.Meter,
                new GridCell(1, 1));

            //Act
            var reservoir = new Reservoir(topHorizon);
            reservoir.CalculateVolume(1, 1, LengthUnit.Meter);

            //Assert
            Assert.AreEqual(1, reservoir.CalculatedVolume, Reservoir.Tolerance);
        }
    }
}
