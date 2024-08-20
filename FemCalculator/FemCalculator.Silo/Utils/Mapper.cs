using FemCalculator.Domain;
using FemCalculator.Domain.Models;
using FemCalculator.Grain;

namespace FemCalculator.Silo.Utils
{
    public static class Mapper
    {
        public static FemCalculationInput ToFemCalculationInput(this CalculationRequest request) => new()
        {
            ExternalLoad = request.ExternalLoad,
            Spans = request.Spans.Select(e => new BeamSpan()
            {
                Length = e.Length,
                ModulusOfElasticity = e.ModulusOfElasticity,
                Section = new ISection(e.BottomFlangeWidth, e.BottomFlangeThickness, e.WebHeight, e.WebThickness, e.TopFlangeWidth, e.TopFlangeThickness),
            }).ToList(),
            Weight = request.Weight,
        };

        public static CalculationResponse ToCalculationResponse(this FemCalculationResult calculationResult) => new()
        {
            MaxStress = calculationResult.MaxStress,
            TotalWeight = calculationResult.TotalWeight
        };
    }
}
