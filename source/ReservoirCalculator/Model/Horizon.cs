using ReservoirCalculator.Interfaces;
using System.Collections.ObjectModel;

namespace ReservoirCalculator.Model
{
    /// <summary>
    /// Represents a Gas & Oil Horizon
    /// </summary>
    class Horizon : IHorizon
    {
        private readonly GridCell gridCell;

        public ReadOnlyCollection<int> Nodes { get; set; }
        
        /// <summary>
        /// Unit used to specify grid cell size
        /// and depth values
        /// </summary>
        public LengthUnit LengthUnit { get; set; }

        public double CellArea => gridCell.Width * gridCell.Length;

        internal Horizon(ReadOnlyCollection<int> nodes, LengthUnit unit, GridCell gridCell)
        {
            Nodes = nodes;
            LengthUnit = unit;
            this.gridCell = gridCell;
        }
    }

    public enum LengthUnit
    {
        Unknown,
        Feet,
        Meter
    }
}
