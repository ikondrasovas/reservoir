using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReservoirCalculator.Converters;
using ReservoirCalculator.Model;
using System;

namespace ReservoirCalculator.Test
{
    [TestClass]
    public class LengthConverterTest
    {
        const double FeetToMeterRelation = 3.28084;

        [TestMethod, TestCategory("LengthConverter")]
        public void ConvertOneMeterToFeet()
        {
            Assert.AreEqual(
                FeetToMeterRelation,
                LengthConverter.Convert(1, LengthUnit.Meter, LengthUnit.Feet));
        }

        [TestMethod, TestCategory("LengthConverter")]
        public void ConvertZeroMeterToFeet()
        {
            Assert.AreEqual(
                0,
                LengthConverter.Convert(0, LengthUnit.Meter, LengthUnit.Feet));
        }

        [TestMethod, TestCategory("LengthConverter")]
        public void ConvertTwoMetersToMeter()
        {
            Assert.AreEqual(
                2,
                LengthConverter.Convert(2, LengthUnit.Meter, LengthUnit.Meter));
        }

        [TestMethod, TestCategory("LengthConverter")]
        [ExpectedException(typeof(NotSupportedException))]
        public void ConvertTwoMetersToUnknown()
        {
            Assert.AreEqual(
                2,
                LengthConverter.Convert(2, LengthUnit.Meter, LengthUnit.Unknown));
        }

        [TestMethod, TestCategory("LengthConverter")]
        public void ConvertOneFeetToMeter()
        {
            Assert.AreEqual(1 / FeetToMeterRelation, LengthConverter.Convert(1, LengthUnit.Feet, LengthUnit.Meter));
        }

        [TestMethod, TestCategory("LengthConverter")]
        public void ConvertZeroFeetToMeter()
        {
            Assert.AreEqual(
                0,
                LengthConverter.Convert(0, LengthUnit.Feet, LengthUnit.Meter));
        }

        [TestMethod, TestCategory("LengthConverter")]
        public void ConvertTwoFeetsToFeet()
        {
            Assert.AreEqual(
                2,
                LengthConverter.Convert(2, LengthUnit.Feet, LengthUnit.Feet));
        }

        [TestMethod, TestCategory("LengthConverter")]
        [ExpectedException(typeof(NotSupportedException))]
        public void ConvertTwoUnknownToFeets()
        {
            Assert.AreEqual(
                2,
                LengthConverter.Convert(2, LengthUnit.Unknown, LengthUnit.Feet));
        }
    }
}
