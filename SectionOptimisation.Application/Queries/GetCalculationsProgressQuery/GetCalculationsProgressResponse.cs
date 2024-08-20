namespace SectionOptimisation.Application.Queries.GetCalculationsProgressQuery
{
    public class GetCalculationsProgressResponse
    {
        public required IReadOnlyCollection<CalculationsProgressDto> CalculationResults { get; init; }
        public required DateTimeOffset StartedAt { get; init; }
    }
}
