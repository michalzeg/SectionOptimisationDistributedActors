namespace FemCalculator.Grain
{
    public interface IFemCalculatorGrain : IGrainWithGuidKey
    {
        ValueTask<CalculationResponse> Calculate(CalculationRequest request);
    }
}