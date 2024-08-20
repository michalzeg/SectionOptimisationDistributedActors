using FEM2D.Structures;

namespace FemCalculator.Domain.Builders
{
    public class FemStructureBuilder : IFemStructureBuilder
    {
        private const int _segments = 2;

        private Structure _structure = new();

        public Structure Build(FemCalculationInput beamConfiguration)
        {
            _structure = new Structure();
            GenerateBeams(beamConfiguration);
            GenerateSupports(beamConfiguration);
            GenerateLoad(beamConfiguration);
            return _structure;
        }

        private void GenerateLoad(FemCalculationInput beamConfiguration)
        {
            foreach (var beam in _structure.ElementFactory.GetBeamElements())
            {
                _structure.LoadFactory.AddBeamUniformLoad(beam, beamConfiguration.ExternalLoad);
                var deadLoad = beam.Length * beam.BarProperties.Area * beamConfiguration.Weight;
                _structure.LoadFactory.AddBeamUniformLoad(beam, -deadLoad);
            }
        }

        private void GenerateSupports(FemCalculationInput beamConfiguration)
        {
            var currentX = 0d;
            var node = _structure.NodeFactory.Create(currentX, 0);
            node.SetPinnedSupport();
            foreach (var item in beamConfiguration.Spans)
            {
                currentX += item.Length;
                node = _structure.NodeFactory.Create(currentX, 0);
                node.SetPinnedSupport();
            }
        }

        private void GenerateBeams(FemCalculationInput beamConfiguration)
        {
            for (int i = 0; i < beamConfiguration.Spans.Count; i++)
            {
                var span = beamConfiguration.Spans[i];

                var baseX = beamConfiguration.Spans.Where((e, inx) => inx < i).Select(e => e.Length).Sum();

                var segmentLength = span.Length / _segments;
                for (var j = 0; j < _segments; j++)
                {
                    var x1 = baseX + segmentLength * j;
                    var x2 = x1 + segmentLength;
                    var node1 = _structure.NodeFactory.Create(x1, 0);
                    var node2 = _structure.NodeFactory.Create(x2, 0);
                    var beam = _structure.ElementFactory.CreateBeam(node1, node2, span.BarProperties);
                }
            }
        }
    }
}
