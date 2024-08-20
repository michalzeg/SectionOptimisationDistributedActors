using SectionOptimisation.Application.Commands.StartCalculationsCommand;

namespace SectionOptimisation.Application.Queries.GetCalculationsIdsQuery
{
    public class GetCalculationsResponse
    {
        public required IReadOnlyCollection<CalculationEntryDto> CalculationsList { get; init; }
    }
}
