export interface CalculationResult {
  totalWeight: number;
  maxStress: number;

  bottomFlangeWidth: number;
  bottomFlangeThickness: number;
  webHeight: number;
  webThickness: number;
  topFlangeWidth: number;
  topFlangeThickness: number;

  finished: boolean;
  chromosomesEvaluated: number;
  occurredAt: string;
}
