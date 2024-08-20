using FitnessEvaluator.Grain;

namespace FitnessEvaluator.Domain.Specifications
{
    public class FlangeWidthGeometrySpecification : ISpecification<FitnessDetails>
    {
        private readonly float _flangeWidthMaxRelationship;

        public FlangeWidthGeometrySpecification(float flangeWidthMaxRelationship = 1.2f)
        {
            _flangeWidthMaxRelationship = flangeWidthMaxRelationship;
        }
        public bool IsSatisfiedBy(FitnessDetails entity)
        {
            var max = Math.Max(entity.BottomFlangeWidth,entity.TopFlangeWidth);
            var min = Math.Min(entity.BottomFlangeWidth, entity.TopFlangeWidth);

            var factor = max / min;

            return factor < _flangeWidthMaxRelationship;
        }
    }
}
