using Coordinator.Grain;
using MediatR;
using SectionOptimisation.Application.Commands.StartCalculationsCommand;

namespace SectionOptimisation.Application.Queries.GetCalculationsIdsQuery
{
    public class GetCalculationsQueryHandler : IRequestHandler<GetCalculationsQuery, GetCalculationsResponse>
    {
        private readonly IGrainFactory _grainFactory;

        public GetCalculationsQueryHandler(IGrainFactory grainFactory)
        {
            _grainFactory = grainFactory;
        }
        public async Task<GetCalculationsResponse> Handle(GetCalculationsQuery request, CancellationToken cancellationToken)
        {
            var coordinationGrain = _grainFactory.GetGrain<ICoordinatorGrain>(Constants.Coordinator);
            var calculationsList = await coordinationGrain.GetCalculationsList();

            var calculationsIds = calculationsList.CalculationInputs.Select(e => new CalculationEntryDto()
            {
                Crossover = e.CrossoverType,
                Label = e.Label,
                Length = e.BeamLength,
                Load = e.ExternalLoad,
                Selection = e.SelectionType,
                Spans = e.Spans,
                MaxStress = e.MaxStress,
                ModulusOfElasticity = e.ModulusOfElasticity,
                Mutation = e.MutationType,
                Population = [e.MinPopulation, e.MaxPopulation],
                Termination = e.Termination,
                Weight = e.Weight,
                CalculationId = e.CalculationId
            }).ToList();

            var result = new GetCalculationsResponse()
            {
                CalculationsList = calculationsIds
            };
            return result;

        }
    }
}
