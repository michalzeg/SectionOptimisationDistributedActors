using FEM2DCommon.ElementProperties;
using FEM2DCommon.ElementProperties.Builder;
using FEM2DCommon.Sections;

namespace FemCalculator.Domain.Models
{
    public readonly struct RectangularSection
    {
        public RectangularSection(double height, double width)
        {
            Width = width;
            Height = height;
            FemSection = Section.FromRectangle(width, height);
        }

        public double Width { get; }
        public double Height { get; }

        internal Section FemSection { get; }
    }
}
