using FitnessEvaluator.Grain;

namespace FitnessEvaluator.Silo.Utils
{
    public static class Mapper
    {
        public static FitnessDetails ToFitnessDetails(this EvaluationRequest request) => new()
        {
            TopFlangeThickness = request.TopFlangeThickness,
            TopFlangeWidth = request.TopFlangeWidth,
            WebHeight = request.WebHeight,
            WebThickness = request.WebThickness,
            BottomFlangeWidth = request.BottomFlangeWidth,
            BottomFlangeThickness = request.BottomFlangeThickness,
            AllowedStress = request.AllowedStress,
            BeamLength = request.BeamLength,
            MaxStress = request.MaxStress,
            TotalWeight = request.TotalWeight
        };
    }
}
