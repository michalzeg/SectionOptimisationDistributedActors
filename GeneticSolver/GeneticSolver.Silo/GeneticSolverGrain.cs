using GeneticSolver.Domain;
using GeneticSolver.Domain.Ports;
using GeneticSolver.Grain;
using GeneticSolver.Silo.Utils;
using Infrastructure.Shared.Utils;
using Orleans.Concurrency;

namespace GeneticSolver.Silo
{
    [StatelessWorker]
    public sealed class GeneticSolverGrain : Orleans.Grain, IGeneticSolverGrain
    {
        private readonly IGrainIdentity _grainIdentity;
        private readonly IGeneticSolver _geneticSolver;

        public GeneticSolverGrain(IGrainIdentity grainIdentity, IGeneticSolver geneticSolver)
        {
            _grainIdentity = grainIdentity;
            _geneticSolver = geneticSolver;
        }

        public async ValueTask Execute(GeneticSolverExecutionRequest request)
        {
            _grainIdentity.SetId(this.GetPrimaryKey());
            var geneticConfiguration = request.ToGeneticSolverConfiguration();
            await _geneticSolver.Start(geneticConfiguration);
        }
    }
}
