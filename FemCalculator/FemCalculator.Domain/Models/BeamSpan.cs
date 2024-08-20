using FEM2DCommon.ElementProperties;

namespace FemCalculator.Domain.Models
{
    public struct BeamSpan
    {
        public required ISection Section { get; init; }
        public required double Length { get; init; }
        public required double ModulusOfElasticity { get; init; }

        internal BarProperties BarProperties => new BarProperties()
        {
            ModulusOfElasticity = ModulusOfElasticity,
            SectionProperties = Section.FemSection.SectionProperties
        };
    }
}
