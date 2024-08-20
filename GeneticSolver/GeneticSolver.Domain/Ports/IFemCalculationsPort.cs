namespace GeneticSolver.Domain.Ports
{
    public interface IFemCalculationsPort
    {
        public ValueTask<FemCalculationResult> CalculateAsync(FemCalculationInput input);
    }
}
