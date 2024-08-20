using MediatR;

namespace SectionOptimisation.Application.Commands.RemoveCalculationsCommand
{
    public class RemoveCalculationsCommand : IRequest
    {
        public Guid CalculationId { get; }

        public RemoveCalculationsCommand(Guid calculationId)
        {
            CalculationId = calculationId;
        }
    }
}
