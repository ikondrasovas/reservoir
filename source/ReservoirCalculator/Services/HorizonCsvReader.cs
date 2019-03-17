using ReservoirCalculator.Interfaces;
using ReservoirCalculator.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReservoirCalculator.Services
{
    class HorizonCsvReader : IHorizonReader
    {
        /// <summary>
        /// These constants could be passed as arguments
        /// to the reader
        /// </summary>
        private const char ValueCharacterSeparator = ' ';
        private const int GridCellWidth = 200;
        private const int GridCellLength = 200;

        public IHorizon Read(string fileName)
        {
            var nodes = new List<int>();

            var lines = File.ReadLines(fileName);

            foreach (var line in lines)
                nodes.AddRange(GetNodesFromLine(line));

            return new Horizon(
                nodes.AsReadOnly(),
                LengthUnit.Feet,
                new GridCell(GridCellWidth, GridCellLength));
        }

        private static List<int> GetNodesFromLine(string line)
        {
            string[] tokens = line.Split(
                new char[] { ValueCharacterSeparator },
                StringSplitOptions.RemoveEmptyEntries);

            var nodes = new List<int>();
            foreach (var token in tokens)
            {
                try
                {
                    nodes.Add(Convert.ToInt32(token));
                }
                catch (FormatException)
                {
                    throw new InvalidDataException($"Value {token} in data set is not a valid integer.");
                }
            }

            return nodes;
        }
    }
}
