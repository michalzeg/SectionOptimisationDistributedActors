using Coordinator.Grain;
using GeneticSolver.Domain.Ports;
using GeneticSolver.Silo.Utils;
using Infrastructure.Shared.Utils;

namespace GeneticSolver.Silo.Adapters
{
    public class SolverProgressReporterAdapter : ISolverProgressReporterPort
    {
        private readonly IGrainFactory _grainFactory;
        private readonly IGrainIdentity _grainIdentity;

        private EvaluationProgress _evaluationProgress;

        public SolverProgressReporterAdapter(IGrainFactory grainFactory, IGrainIdentity grainIdentity)
        {
            _grainFactory = grainFactory;
            _grainIdentity = grainIdentity;
        }

        public ValueTask ReportEvaluations(EvaluationProgress progress)
        {
            _evaluationProgress = progress;
            return ValueTask.CompletedTask;
        }

        public ValueTask ReportProgress(SolverProgress progress)
        {
            var progressDetails = progress.ToProgressDetails(_evaluationProgress);
            var grain = _grainFactory.GetGrain<ICoordinatorGrain>(Constants.Coordinator);
            return grain.ReportProgress(_grainIdentity.GetId(), progressDetails);
        }
    }
}
