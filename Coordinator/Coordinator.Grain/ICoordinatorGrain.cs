namespace Coordinator.Grain
{
    public interface ICoordinatorGrain : IGrainWithStringKey
    {
        ValueTask StartCalculations(StartCalculationsRequest calculationInput);

        ValueTask<ProgressResponse> GetProgress(Guid calculationId);

        ValueTask ReportProgress(Guid calculationId, ProgressDetails progress);

        ValueTask<CalculationsListResponse> GetCalculationsList();

        ValueTask RemoveCalculations(Guid calculationId);
    }
}
