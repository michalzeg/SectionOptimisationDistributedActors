using Common.Geometry;
using FEM2DCommon.Sections;

namespace FemCalculator.Domain.Models
{
    public readonly struct BoxSection
    {
        public BoxSection(double bottomFlangeWidth, double bottomFlangeThickness, double totalHeight, double webThickness, double topFlangeWidth, double topFlangeThickness)
        {
            var coordinates = new List<PointD>()
            {
                new(){X = 0, Y = 0},
                new(){X = bottomFlangeWidth/2, Y = 0},
                new(){X = bottomFlangeWidth/2, Y = totalHeight - topFlangeThickness},
                new(){X = topFlangeWidth/2, Y = totalHeight - topFlangeThickness},
                new(){X = topFlangeWidth/2, Y = totalHeight},
                new(){X = -topFlangeWidth/2, Y = totalHeight},
                new(){X = -topFlangeWidth/2, Y = totalHeight - topFlangeThickness},
                new(){X = -bottomFlangeWidth/2, Y = totalHeight - topFlangeThickness},
                new(){X = -bottomFlangeWidth/2, Y = 0},
                new(){X = 0, Y = 0},
                new(){X = 0, Y = bottomFlangeThickness},
                new(){X = -bottomFlangeWidth + webThickness, Y = bottomFlangeThickness},
                new(){X = -bottomFlangeWidth + webThickness, Y = totalHeight - topFlangeThickness},
                new(){X = bottomFlangeWidth - webThickness, Y = totalHeight - topFlangeThickness},
                new(){X = bottomFlangeWidth - webThickness, Y = bottomFlangeThickness},
                new(){X = 0, Y = bottomFlangeThickness},
                new(){X = 0, Y = 0}
            };

            var perimeter = new Perimeter(coordinates);

            FemSection = new Section([perimeter]);
        }
        internal Section FemSection { get; }
    }
}
