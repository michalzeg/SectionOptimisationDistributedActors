using Coordinator.Grain;
using FemCalculator;
using FemCalculator.Grain;
using FitnessEvaluator.Grain;
using GeneticSolver.Domain.Genetic;
using GeneticSolver.Domain.Ports;
using GeneticSolver.Grain;
using System;

namespace GeneticSolver.Silo.Utils
{
    public static class Mapper
    {
        public static SpanDetails Map(this BeamGeometry chromosomeDetails, double length, double modulusOfElasticity) => new()
        {
            Length = length,
            ModulusOfElasticity = modulusOfElasticity,
            TopFlangeWidth = chromosomeDetails.TopFlangeWidth,
            TopFlangeThickness = chromosomeDetails.TopFlangeThickness,
            BottomFlangeThickness = chromosomeDetails.BottomFlangeThickness,
            BottomFlangeWidth = chromosomeDetails.BottomFlangeWidth,
            WebHeight = chromosomeDetails.WebHeight,
            WebThickness = chromosomeDetails.WebThickness
        };

        public static GeneticSolverConfiguration ToGeneticSolverConfiguration(this GeneticSolverExecutionRequest request) => new()
        {
            ExternalLoad = request.ExternalLoad,
            MaxPopulation = request.MaxPopulation,
            AllowedStress = request.MaxStress,
            MinPopulation = request.MinPopulation,
            ModulusOfElasticity = request.ModulusOfElasticity,
            Weight = request.Weight,
            Spans = request.Spans,
            BeamLength = request.BeamLength,
            Termination = request.Termination,
            MutationType = request.MutationType,
            SelectionType = request.SelectionType,
            CrossoverType = request.CrossoverType
        };

        public static ProgressDetails ToProgressDetails(this SolverProgress progress, EvaluationProgress evaluationProgress) => new() 
        {
            MaxStress = progress.MaxStress,
            TotalWeight = progress.TotalWeight,
            TopFlangeThickness = progress.BeamGeometry.TopFlangeThickness,
            TopFlangeWidth = progress.BeamGeometry.TopFlangeWidth,
            BottomFlangeThickness = progress.BeamGeometry.BottomFlangeThickness,
            BottomFlangeWidth = progress.BeamGeometry.BottomFlangeWidth,
            WebHeight = progress.BeamGeometry.WebHeight,
            WebThickness = progress.BeamGeometry.WebThickness,
            Finished = progress.Finished,
            ChromosomesEvaluated = evaluationProgress.ChromosomesEvaluated 
        };

        public static EvaluationRequest ToEvaluationRequest(this Evaluation evaluation) => new() 
        {
            TopFlangeWidth = evaluation.TopFlangeWidth,
            TopFlangeThickness = evaluation.TopFlangeThickness,
            WebThickness = evaluation.WebThickness,
            WebHeight = evaluation.WebHeight,
            BottomFlangeWidth = evaluation.BottomFlangeWidth,
            BottomFlangeThickness = evaluation.BottomFlangeThickness,
            AllowedStress = evaluation.AllowedStress,
            BeamLength = evaluation.BeamLength,
            MaxStress = evaluation.MaxStress,
            TotalWeight = evaluation.TotalWeight
        };

        public static CalculationRequest ToCalculationRequest(this FemCalculationInput input) => new()
        {
            Weight = input.Weight,
            ExternalLoad = input.ExternalLoad,
            Spans = Enumerable.Range(0, input.Spans).Select(e => input.BeamGeometry.Map(input.BeamLength / input.Spans, input.ModulusOfElasticity)).ToArray()
        };

        public static FemCalculationResult ToFemCalculationResult(this CalculationResponse calculationResult) => new()
        {
            MaxStress = calculationResult.MaxStress,
            TotalWeight = calculationResult.TotalWeight,
        };
    }
}
