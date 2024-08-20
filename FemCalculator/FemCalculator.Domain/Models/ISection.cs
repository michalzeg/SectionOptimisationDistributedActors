using Common.Geometry;
using FEM2DCommon.Sections;

namespace FemCalculator.Domain.Models
{
    public readonly struct ISection
    {
        public ISection(double bottomFlangeWidth, double bottomFlangeThickness, double webHeight, double webThickness, double topFlangeWidth, double topFlangeThickness)
        {
            var coordinates = new List<PointD>()
            {
                new(){X = 0,Y = 0},
                new(){X = bottomFlangeWidth/2,Y=0},
                new(){X = bottomFlangeWidth/2,Y=bottomFlangeThickness},
                new(){X = webThickness/2,Y=bottomFlangeThickness},
                new(){X = webThickness/2,Y=bottomFlangeThickness+webHeight},
                new(){X = topFlangeWidth/2,Y=bottomFlangeThickness+webHeight},
                new(){X = topFlangeWidth/2,Y=bottomFlangeThickness+webHeight+topFlangeThickness},
                new(){X =-topFlangeWidth/2,Y=bottomFlangeThickness+webHeight+topFlangeThickness},
                new(){X =-topFlangeWidth/2,Y=bottomFlangeThickness+webHeight},
                new(){X =-webThickness/2,Y=bottomFlangeThickness+webHeight},
                new(){X =-webThickness/2,Y=bottomFlangeThickness},
                new(){X =-bottomFlangeWidth/2,Y=bottomFlangeThickness},
                new(){X =-bottomFlangeWidth/2,Y=0},
            };

            var perimeter = new Perimeter(coordinates);

            FemSection = new Section([perimeter]);
        }
        internal Section FemSection { get; }
    }
}
