using GeneticSolver.Domain.Ports;

namespace GeneticSolver.Domain
{
    public interface IGeneticSolver
    {
        ValueTask Start(GeneticSolverConfiguration configuration);
    }
}