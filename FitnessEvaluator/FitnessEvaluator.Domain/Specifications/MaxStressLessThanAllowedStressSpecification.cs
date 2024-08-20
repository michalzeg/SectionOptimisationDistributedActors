using FitnessEvaluator.Grain;

namespace FitnessEvaluator.Domain.Specifications
{
    public class MaxStressLessThanAllowedStressSpecification : ISpecification<FitnessDetails>
    {
        public bool IsSatisfiedBy(FitnessDetails entity)
        {
            return !double.IsNaN(entity.MaxStress) && entity.MaxStress <= entity.AllowedStress;
        }
    }
}
