namespace FemCalculator.Domain
{
    public interface IFemCalculator
    {
        FemCalculationResult Calculate(FemCalculationInput input);
    }
}