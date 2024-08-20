using System.Collections.Generic;

namespace FitnessEvaluator.Domain.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
