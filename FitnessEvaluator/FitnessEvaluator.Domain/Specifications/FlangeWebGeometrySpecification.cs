using FitnessEvaluator.Grain;

namespace FitnessEvaluator.Domain.Specifications
{
    public class FlangeWebGeometrySpecification : ISpecification<FitnessDetails>
    {
        private readonly int _flangeWebThicknessMaxRelationship;

        public FlangeWebGeometrySpecification(int flangeWebThicknessMaxRelationship = 2)
        {
            _flangeWebThicknessMaxRelationship = flangeWebThicknessMaxRelationship;
        }
        public bool IsSatisfiedBy(FitnessDetails entity)
        {
            var maxFlangeThickness = Math.Max(entity.BottomFlangeThickness, entity.TopFlangeThickness);

            var factor = maxFlangeThickness / entity.WebThickness;

            return factor < _flangeWebThicknessMaxRelationship;
        }
    }
}
