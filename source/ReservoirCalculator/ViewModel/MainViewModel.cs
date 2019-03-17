using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ReservoirCalculator.Converters;
using ReservoirCalculator.Interfaces;
using ReservoirCalculator.Model;
using ReservoirCalculator.Properties;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReservoirCalculator.ViewModel
{
    /// <summary>
    /// Main application ViewModel
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Constants
        const int baseHorizonRelativeDepth = 100; //meters
        const int fluidContactDept = 3000; //meters
        #endregion

        #region Atributes
        private Reservoir reservoir;
        private readonly IHorizonReader horizonReader;
        #endregion

        #region Properties
        /// <summary>
        /// Command to execute the reservoir volume calculation
        /// </summary>
        public RelayCommand CalculateCommand { get; private set; }

        /// <summary>
        /// Command to load the provided dataset
        /// </summary>
        public RelayCommand InitializeCommand { get; private set; }

        public double Volume
        {
            get
            {
                return VolumeConverter.Convert(
                    reservoir?.CalculatedVolume ?? 0,
                    VolumeUnit.CubicFeet,
                    SelectedVolumeUnit);
            }
        }

        /// <summary>
        /// Status message to infor the user of problems
        /// during data loading or calculation
        /// </summary>
        private string statusMessage;
        public string StatusMessage
        {
            get
            {
                return statusMessage;
            }
            private set
            {
                if(statusMessage != value)
                {
                    statusMessage = value;
                    RaisePropertyChanged(() => StatusMessage);
                }
            }
        }

        private VolumeUnit selectedVolumeUnit = VolumeUnit.CubicFeet;
        public VolumeUnit SelectedVolumeUnit
        {
            get
            {
                return selectedVolumeUnit;
            }
            set
            {
                if(selectedVolumeUnit != value)
                {
                    selectedVolumeUnit = value;
                    RaisePropertyChanged(() => Volume);
                }
            }
        }

        /// <summary>
        /// This list is created to be used by the view to populate
        /// the list of available units on the ComboBox
        /// </summary>
        public IReadOnlyCollection<UserVolumeUnits> ComboBoxUnits
        {
            get
            {
                return new List<UserVolumeUnits>()
                {
                    new UserVolumeUnits(){ VolumeUnit = VolumeUnit.CubicFeet, Description=  Resources.CubicFeet },
                    new UserVolumeUnits(){ VolumeUnit = VolumeUnit.CubicMeters, Description = Resources.CubicMeters},
                    new UserVolumeUnits(){ VolumeUnit = VolumeUnit.Barrels, Description = Resources.Barrels}
                };
            }
        }

        /// <summary>
        /// Indicates if there was an operation that resulted in error condition
        /// </summary>
        private bool hasError;
        public bool HasError
        {
            get
            {
                return hasError;
            }
            set
            {
                if (hasError != value)
                {
                    hasError = value;
                    RaisePropertyChanged(() => HasError);
                }
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IHorizonReader horizonReader)
        {
            this.horizonReader = horizonReader;

            CalculateCommand = new RelayCommand(
                ExecuteCalculateCommand,
                () => true);

            InitializeCommand = new RelayCommand(
                ExecuteInitializeCommand,
                () => true);
        }

        private void ExecuteCalculateCommand()
        {
            try
            {
                reservoir.CalculateVolume(
                   baseHorizonRelativeDepth,
                   fluidContactDept,
                   LengthUnit.Meter);

                StatusMessage = Resources.VolumeCalculatedSuccessfully;
                RaisePropertyChanged(() => Volume);

            }
            catch (Exception e)
            {
                StatusMessage = e.Message;
                HasError = true;
            }
        }

        private void ExecuteInitializeCommand()
        {
            HasError = false;
            var sampleDataSetFile = Path.Combine("SampleDataSets", "depthvalues.csv");

            try
            {
                var topHorizon = horizonReader.Read(sampleDataSetFile);
                reservoir = new Reservoir(topHorizon);

                StatusMessage = Resources.DataSetLoadedSuccessfull;
            }
            catch (Exception e)
            {
                StatusMessage = e.Message;
                HasError = true;
            }
        }
        #endregion
    }

    public class UserVolumeUnits
    {
        public VolumeUnit VolumeUnit { get; set; }
        public string Description { get; set; }
    }
}