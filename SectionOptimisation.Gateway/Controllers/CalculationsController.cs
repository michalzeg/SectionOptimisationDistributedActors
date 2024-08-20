using MediatR;
using Microsoft.AspNetCore.Mvc;
using SectionOptimisation.Application.Commands.RemoveCalculationsCommand;
using SectionOptimisation.Application.Commands.StartCalculationsCommand;
using SectionOptimisation.Application.Queries.GetCalculationsIdsQuery;
using SectionOptimisation.Application.Queries.GetCalculationsProgressQuery;

namespace PortalApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CalculationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{calculationId:guid}")]
        public async Task<IActionResult> GetProgress(Guid calculationId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetCalculationsProgressQuery(calculationId), cancellationToken);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{calculationId:guid}")]
        public async Task<IActionResult> Delete(Guid calculationId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new RemoveCalculationsCommand(calculationId), cancellationToken);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCalculations(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetCalculationsQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        [Route("{calculationId:guid}")]
        public async Task<IActionResult> StartCalculations(Guid calculationId, [FromBody] StartCalculationsCommand command, CancellationToken cancellationToken)
        {
            var extendedCommand = new StartCalculationsExtendedCommand()
            {
                CalculationId = calculationId,
                Crossover = command.Crossover,
                Label = command.Label,
                Length = command.Length,
                Load = command.Load,
                MaxStress = command.MaxStress,
                ModulusOfElasticity = command.ModulusOfElasticity,
                Mutation = command.Mutation,
                Population = command.Population,
                Selection = command.Selection,
                Spans = command.Spans,
                Termination = command.Termination,
                Weight = command.Weight
            };
            await _mediator.Send(extendedCommand, cancellationToken);
            return Ok();
        }
    }
}
