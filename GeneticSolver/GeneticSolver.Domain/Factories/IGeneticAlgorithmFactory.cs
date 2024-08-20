using GeneticSharp;
using GeneticSolver.Domain.Ports;

namespace GeneticSolver.Domain.Factories
{
    public interface IGeneticAlgorithmFactory
    {
        GeneticAlgorithm Create(GeneticSolverConfiguration configuration);
    }
}