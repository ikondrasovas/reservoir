using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReservoirCalculator.Converters;
using ReservoirCalculator.Model;
using System;

namespace ReservoirCalculator.Test
{
    [TestClass]
    public class VolumehConverterTest
    {
        internal const double CubicCubicFeetToCubicMeeterRelation = 35.31467;

        [TestMethod, TestCategory("VolumeConverter")]
        public void ConvertOneCubicMeterToCubicFeet()
        {
            Assert.AreEqual(
                CubicCubicFeetToCubicMeeterRelation,
                VolumeConverter.Convert(1, VolumeUnit.CubicMeters, VolumeUnit.CubicFeet),
                Reservoir.Tolerance);
        }

        [TestMethod, TestCategory("VolumeConverter")]
        public void ConvertZeroCubicMeterToCubicFeet()
        {
            Assert.AreEqual(
                0,
                VolumeConverter.Convert(0, VolumeUnit.CubicMeters, VolumeUnit.CubicFeet));
        }

        [TestMethod, TestCategory("VolumeConverter")]
        public void ConvertTwoCubicMetersToCubicMeter()
        {
            Assert.AreEqual(
                2,
                VolumeConverter.Convert(2, VolumeUnit.CubicMeters, VolumeUnit.CubicMeters),
                Reservoir.Tolerance);
        }

        [TestMethod, TestCategory("VolumeConverter")]
        [ExpectedException(typeof(NotSupportedException))]
        public void ConvertTwoCubicMetersToUnknown()
        {
            Assert.AreEqual(
                2,
                VolumeConverter.Convert(2, VolumeUnit.CubicMeters, VolumeUnit.Unknown),
                Reservoir.Tolerance);
        }

        [TestMethod, TestCategory("VolumeConverter")]
        public void ConvertOneCubicFeetToCubicMeter()
        {
            Assert.AreEqual(
                1 / CubicCubicFeetToCubicMeeterRelation,
                VolumeConverter.Convert(1, VolumeUnit.CubicFeet, VolumeUnit.CubicMeters));
        }

        [TestMethod, TestCategory("VolumeConverter")]
        public void ConvertZeroCubicFeetToCubicMeter()
        {
            Assert.AreEqual(
                0,
                VolumeConverter.Convert(0, VolumeUnit.CubicFeet, VolumeUnit.CubicMeters));
        }

        [TestMethod, TestCategory("VolumeConverter")]
        public void ConvertTwoCubicFeetsToCubicFeet()
        {
            Assert.AreEqual(2,
                VolumeConverter.Convert(2, VolumeUnit.CubicFeet, VolumeUnit.CubicFeet),
                Reservoir.Tolerance);
        }

        [TestMethod, TestCategory("VolumeConverter")]
        [ExpectedException(typeof(NotSupportedException))]
        public void ConvertTwoUnknownToCubicFeets()
        {
            Assert.AreEqual(
                2,
                VolumeConverter.Convert(2, VolumeUnit.Unknown, VolumeUnit.CubicFeet),
                Reservoir.Tolerance);
        }


        [TestMethod, TestCategory("VolumeConverter")]
        public void ConvertHugeCubicFeetsToCubicMeters()
        {
            Assert.AreEqual(
                68356539.6476875,
                VolumeConverter.Convert(2413988640, VolumeUnit.CubicFeet, VolumeUnit.CubicMeters),
                Reservoir.Tolerance);
        }

        [TestMethod, TestCategory("VolumeConverter")]
        public void ConvertHugeCubicFeetsToBarrels()
        {
            Assert.AreEqual(
                429955516.6704,
                VolumeConverter.Convert(2413988640, VolumeUnit.CubicFeet, VolumeUnit.Barrels),
                Reservoir.Tolerance);
        }
    }
}
