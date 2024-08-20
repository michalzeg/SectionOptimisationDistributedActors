using GeneticSharp;
using GeneticSolver.Domain.Ports;

namespace GeneticSolver.Domain.Factories
{
    public interface IFitnessFactory
    {
        IFitness Create(GeneticSolverConfiguration configuration);
    }
}
