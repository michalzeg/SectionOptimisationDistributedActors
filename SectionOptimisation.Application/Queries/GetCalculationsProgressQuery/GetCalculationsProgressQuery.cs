using MediatR;

namespace SectionOptimisation.Application.Queries.GetCalculationsProgressQuery
{
    public class GetCalculationsProgressQuery : IRequest<GetCalculationsProgressResponse>
    {
        public Guid CalculationId { get; }

        public GetCalculationsProgressQuery(Guid calculationId)
        {
            CalculationId = calculationId;
        }
    }
}
