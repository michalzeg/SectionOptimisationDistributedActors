using GeneticSharp;
using GeneticSolver.Domain.Ports;

namespace GeneticSolver.Domain.Builders
{
    public static class ChromosomeBuilder
    {
        const double _minHeight = 0.2;
        const double _maxHeight = 2;
        const double _minWidth = 0.2;
        const double _maxWidth = 1;
        const double _maxThickness = 0.1;
        const double _minThickness = 0.001;
        
        private static readonly int _totalBits = 14;

        public static FloatingPointChromosome Create()
        {
            var minValues = new[] { _minWidth, _minThickness, _minHeight, _minThickness, _minWidth, _minThickness };
            var maxValues = new[] { _maxWidth, _maxThickness, _maxHeight, _maxThickness, _maxWidth, _maxThickness };
            var totalBits = new[] { _totalBits, _totalBits, _totalBits, _totalBits, _totalBits, _totalBits };
            var fractionDigits = new[] { 2, 3, 2, 3, 2, 3 };

            return new FloatingPointChromosome(
                minValues,
                maxValues,
                totalBits,
                fractionDigits
                );
        }
    }
}
