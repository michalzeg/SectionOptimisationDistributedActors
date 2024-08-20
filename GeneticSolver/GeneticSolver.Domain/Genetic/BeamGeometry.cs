using GeneticSharp;

namespace GeneticSolver.Domain.Genetic
{
    public readonly record struct BeamGeometry
    {
        internal static BeamGeometry FromFloatingPoints(FloatingPointChromosome floatingPointChromosome)
        {
            var points = floatingPointChromosome.ToFloatingPoints();
            return new BeamGeometry()
            {
                BottomFlangeWidth = points[0],
                BottomFlangeThickness = points[1],
                WebHeight = points[2],
                WebThickness = points[3],
                TopFlangeWidth= points[4],
                TopFlangeThickness= points[5],
            };
        }
        public required double BottomFlangeWidth { get; init; }
        public required double BottomFlangeThickness { get; init; }
        public required double WebHeight { get; init; }
        public required double WebThickness { get; init; }
        public required double TopFlangeWidth { get; init; }
        public required double TopFlangeThickness { get; init; }
    }
}
