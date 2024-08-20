using FEM2D.Structures;

namespace FemCalculator.Domain.Builders
{
    public interface IFemStructureBuilder
    {
        Structure Build(FemCalculationInput femConfiguration);
    }
}