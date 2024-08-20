using FitnessEvaluator.Grain;

namespace FitnessEvaluator.Domain.Specifications
{
    public class WebGeometrySpecification : ISpecification<FitnessDetails>
    {
        private readonly int _widthThicknessRelationship;

        public WebGeometrySpecification(int widthThicknessRelationship = 100)
        {
            _widthThicknessRelationship = widthThicknessRelationship;
        }
        public bool IsSatisfiedBy(FitnessDetails entity)
        {
            var factor = entity.WebHeight / entity.WebThickness;

            return factor < _widthThicknessRelationship;
        }
    }
}
