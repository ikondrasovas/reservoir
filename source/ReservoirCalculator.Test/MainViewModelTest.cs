using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReservoirCalculator.ViewModel;
using ReservoirCalculator.Services;
using ReservoirCalculator.Model;

namespace ReservoirCalculator.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MainViewModelTest
    {
        const string testDataSetFolder = "TestDataSet";

        /// <summary>
        /// Given I load the dataset
        /// And initialize the MainViewModel
        /// When I execute the CalculateCommand
        /// Then I have the volume equals the expected value in cubic feet
        /// </summary>
        [TestMethod, TestCategory("ViewModel")]
        public void CalculateDefaultDataSetCubicFeet()
        {
            //Setup
            var viewModel = new MainViewModel(new HorizonCsvReader());
            viewModel.InitializeCommand.Execute(null);
            viewModel.SelectedVolumeUnit = VolumeUnit.CubicFeet;

            //Act
            viewModel.CalculateCommand.Execute(null);

            //Assert
            Assert.AreEqual(2413988640, viewModel.Volume, Reservoir.Tolerance);
        }

        /// <summary>
        /// Given I load the dataset
        /// And initialize the MainViewModel
        /// When I execute the CalculateCommand
        /// Then I have the volume equals the expected value in cubic meters
        /// </summary>
        [TestMethod, TestCategory("ViewModel")]
        public void CalculateDefaultDataSetCubicMeters()
        {
            //Setup
            var viewModel = new MainViewModel(new HorizonCsvReader());
            viewModel.InitializeCommand.Execute(null);
            viewModel.SelectedVolumeUnit = VolumeUnit.CubicMeters;

            //Act
            viewModel.CalculateCommand.Execute(null);

            //Assert
            Assert.AreEqual(68356539.6476875, viewModel.Volume, Reservoir.Tolerance);
        }

    }
}
