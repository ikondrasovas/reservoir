using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReservoirCalculator.Services;

namespace ReservoirCalculator.Test
{
    [TestClass]
    public class HorizonCsvReaderTest
    {
        const string testDataSetFolder = "TestDataSet";

        /// <summary>
        /// Given a sample csv file with grid format and depth value
        /// When I read this file from the current project output
        /// The number of nodes read will be exactly the ones provided in the file
        /// </summary>
        [TestMethod]
        public void LoadSampleDataSet()
        {
            //Setup
            string testDataSet = Path.Combine(testDataSetFolder, "depthvalues.csv");
            var horizonReader = new HorizonCsvReader();

            //Act
            var horizon = horizonReader.Read(testDataSet);

            //Assert
            Assert.AreEqual(16 * 26, horizon.Nodes.Count);
        }
    }
}
