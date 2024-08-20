namespace GeneticSolver.Domain.Ports
{
    public interface IFitnessEvaluationPort
    {
        ValueTask<EvaluationResult> Evaluate(Evaluation evaluation);
    }
}
