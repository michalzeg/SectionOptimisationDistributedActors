import { uuid } from '../shared/uuid';


export interface CalculationsInput {
  mutation: string;
  selection: string;
  crossover: string;
  termination: number;
  population: number[];

  load: number;
  modulusOfElasticity: number;
  weight: number;
  spans: number;
  maxStress: number;
  length: number;

  label: string;
  calculationId: uuid;
}
