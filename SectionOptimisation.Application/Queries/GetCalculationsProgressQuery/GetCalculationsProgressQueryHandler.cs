using Coordinator.Grain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace SectionOptimisation.Application.Queries.GetCalculationsProgressQuery
{
    public class GetCalculationsProgressQueryHandler : IRequestHandler<GetCalculationsProgressQuery, GetCalculationsProgressResponse>
    {
        private readonly ILogger<GetCalculationsProgressQueryHandler> _logger;
        private readonly IGrainFactory _grainFactory;

        public GetCalculationsProgressQueryHandler(ILogger<GetCalculationsProgressQueryHandler> logger, IGrainFactory grainFactory)
        {
            _logger = logger;
            _grainFactory = grainFactory;
        }
        public async Task<GetCalculationsProgressResponse> Handle(GetCalculationsProgressQuery request, CancellationToken cancellationToken)
        {
            var coordinationGrain = _grainFactory.GetGrain<ICoordinatorGrain>(Constants.Coordinator);
            var result = await coordinationGrain.GetProgress(request.CalculationId);

            var response = result.ProgressDetails.Select(e => new CalculationsProgressDto()
            {
                TopFlangeThickness = e.TopFlangeThickness,
                TopFlangeWidth = e.TopFlangeWidth,
                WebThickness = e.WebThickness,
                WebHeight = e.WebHeight,
                BottomFlangeWidth = e.BottomFlangeWidth,
                BottomFlangeThickness = e.BottomFlangeThickness,
                MaxStress = e.MaxStress,
                TotalWeight = e.TotalWeight,
                Finished = e.Finished,
                OccurredAt = e.OccurredAt,
                ChromosomesEvaluated = e.ChromosomesEvaluated
            }).ToList();

            return new GetCalculationsProgressResponse()
            {
                CalculationResults = response,
                StartedAt = result.StartedAt
            };
        }
    }
}
