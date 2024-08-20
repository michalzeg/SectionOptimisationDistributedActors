using FEM2DStressCalculator.Beams;
using FemCalculator.Domain.Builders;

namespace FemCalculator.Domain
{
    public class FemCalculator : IFemCalculator
    {
        private const int _resultPoints = 10;
        private readonly IFemStructureBuilder _beamStructureBuilder;

        public FemCalculator(IFemStructureBuilder beamStructureBuilder)
        {
            _beamStructureBuilder = beamStructureBuilder;
        }

        public FemCalculationResult Calculate(FemCalculationInput input)
        {
            var structure = _beamStructureBuilder.Build(input);
            
            structure.Solve();
            
            var beamResults = structure.Results.BeamResults;

            var totalWeight = 0d;
            var maxStress = 0d;

            foreach (var beam in structure.ElementFactory.GetBeamElements())
            {
                var calculator = new BeamStressCalculator(beam.BarProperties.SectionProperties);

                var beamResult = beamResults.GetResult(beam);

                var beamForces = Enumerable.Range(0, _resultPoints + 1)
                .Select(f => f / _resultPoints)
                .Select(f => beamResult.GetBeamForces(f));

                var beamStresses = beamForces.Select(e => new { top = calculator.TopNormalStress(e), bottom = calculator.BottomNormalStress(e) })
                    .Select(e => Math.Max(Math.Abs(e.top), Math.Abs(e.bottom)));

                var beamMaxStress = beamStresses.Max();

                maxStress = maxStress > beamMaxStress ? maxStress : beamMaxStress;

                var weight = beam.Length * beam.BarProperties.Area * input.Weight;
                totalWeight += weight;
            }

            return new FemCalculationResult { MaxStress = maxStress, TotalWeight = totalWeight };
        }

    }
}
