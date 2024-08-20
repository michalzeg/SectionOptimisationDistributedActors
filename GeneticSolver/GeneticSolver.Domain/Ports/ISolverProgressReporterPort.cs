namespace GeneticSolver.Domain.Ports
{
    public interface ISolverProgressReporterPort
    {
        public ValueTask ReportProgress(SolverProgress progress);
        public ValueTask ReportEvaluations(EvaluationProgress progress);
    }
}
