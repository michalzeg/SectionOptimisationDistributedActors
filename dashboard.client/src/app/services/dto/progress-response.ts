import { CalculationResult } from "../../models/calculation-result";

export interface ProgressResponse {
  calculationResults: CalculationResult[];
  startedAt: string;
}
