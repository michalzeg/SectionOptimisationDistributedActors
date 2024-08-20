using GeneticSolver.Domain.Genetic;
using GeneticSolver.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticSolver.Domain.Utils
{
    public static class Mapper
    {
        public static FemCalculationInput ToFemCalculationInput(this BeamGeometry geometry, GeneticSolverConfiguration configuration) => new()
        {
            BeamGeometry = geometry,
            Spans = configuration.Spans,
            BeamLength = configuration.BeamLength,
            ExternalLoad = configuration.ExternalLoad,
            ModulusOfElasticity = configuration.ModulusOfElasticity,
            Weight = configuration.Weight
        };

        public static SolverProgress ToSolverProgress(this FemCalculationResult result, BeamGeometry geometry, bool finished) => new()
        {
            MaxStress = double.IsNaN(result.MaxStress) ? 0 : result.MaxStress,
            TotalWeight = result.TotalWeight,
            BeamGeometry = geometry,
            Finished = finished,
        };

        public static Evaluation ToEvaluation(this FemCalculationResult calculationResult, BeamGeometry geometry, GeneticSolverConfiguration configuration) => new()
        {
            TopFlangeThickness = geometry.TopFlangeThickness,
            TopFlangeWidth = geometry.TopFlangeWidth,
            WebHeight = geometry.WebHeight,
            WebThickness = geometry.WebThickness,
            BottomFlangeWidth = geometry.BottomFlangeWidth,
            BottomFlangeThickness = geometry.BottomFlangeThickness,
            AllowedStress = configuration.AllowedStress,
            BeamLength = configuration.BeamLength,
            MaxStress = calculationResult.MaxStress,
            TotalWeight = calculationResult.TotalWeight,
        };
    }
}
