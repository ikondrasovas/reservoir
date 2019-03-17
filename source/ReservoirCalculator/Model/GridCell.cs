namespace ReservoirCalculator.Model
{
    /// <summary>
    /// Represents a horizon grid cell
    /// width and length are considered to be
    /// in the same unit as the horizon length unit
    /// </summary>
    public class GridCell
    {
        internal int Width { get; set; }
        internal int Length { get; set; }

        internal GridCell(int width, int length)
        {
            Width = width;
            Length = length;
        }
    }
}
