using Coordinator.Grain;
using GeneticSolver.Grain;
using GeneticSolver.Shared.Types;

namespace Coordinator.Silo.Utils
{
    public static class Mapper
    {
        public static GeneticSolverExecutionRequest ToGeneticSolverExecutionRequest(this StartCalculationsRequest request) => new()
        {
            ExternalLoad = request.ExternalLoad,
            ModulusOfElasticity = request.ModulusOfElasticity,
            MaxStress = request.MaxStress,
            BeamLength = request.BeamLength,
            Spans = request.Spans,
            Weight = request.Weight,
            MinPopulation = request.MinPopulation,
            MaxPopulation = request.MaxPopulation,
            Termination = request.Termination,
            MutationType = Enum.Parse<MutationType>(request.MutationType!),
            CrossoverType = Enum.Parse<CrossoverType>(request.CrossoverType!),
            SelectionType = Enum.Parse<SelectionType>(request.SelectionType!)
        };
    }
}
