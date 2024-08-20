import { CalculationResult } from "../models/calculation-result";
import { CalculationsInput } from "../models/calculations-input";
import { getAllCrossoverTypes } from "../models/crossover-type";
import { getAllMutationTypes } from "../models/mutation-type";
import { getAllSelectionTypes } from "../models/selection-type";
import { uuid } from "../shared/uuid";


export interface AppState {
  creatorInput: CalculationsInput;
  currentCalculationId: uuid;
  calculations: CalculationsState[];
}

export interface CalculationsState {
  input: CalculationsInput,
  results: CalculationResult[],
  calculationId: uuid,
  startedAt: string
}


export const initialForm: CalculationsInput = {
  mutation: getAllMutationTypes()[0],
  selection: getAllSelectionTypes()[0],
  crossover: getAllCrossoverTypes()[0],
  termination: 10,
  population: [50_000, 100_000],

  load: 20_000,
  modulusOfElasticity: 205,
  weight: 78,
  spans: 3,
  maxStress: 355,
  length: 10,

  label: '',
  calculationId: ''
}


export const initialState: AppState = {
  creatorInput: initialForm,
  currentCalculationId: '',
  calculations: [],
};
