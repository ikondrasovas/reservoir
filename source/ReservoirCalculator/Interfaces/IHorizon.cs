using ReservoirCalculator.Model;
using System.Collections.ObjectModel;

namespace ReservoirCalculator.Interfaces
{
    public interface IHorizon
    {
        ReadOnlyCollection<int> Nodes { get; }
        LengthUnit LengthUnit { get; set; }
        double CellArea { get; }
    }
}
