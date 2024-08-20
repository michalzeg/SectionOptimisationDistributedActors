using FitnessEvaluator.Grain;

namespace FitnessEvaluator.Domain.Specifications
{
    public class FlangeThicknessGeometrySpecification : ISpecification<FitnessDetails>
    {
        private readonly float _flangeThicknessMaxRelationship;

        public FlangeThicknessGeometrySpecification(float flangeThicknessMaxRelationship = 1.5f)
        {
            _flangeThicknessMaxRelationship = flangeThicknessMaxRelationship;
        }
        public bool IsSatisfiedBy(FitnessDetails entity)
        {
            var max = Math.Max(entity.BottomFlangeThickness, entity.TopFlangeThickness);
            var min = Math.Min(entity.BottomFlangeThickness, entity.TopFlangeThickness);

            var factor = max / min;

            return factor < _flangeThicknessMaxRelationship;
        }
    }
}
