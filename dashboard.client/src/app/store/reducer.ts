import { createReducer, on } from '@ngrx/store';
import * as actions from './actions';
import { AppState, CalculationsState, initialState } from './state';

export type AppStateReducer = (state: AppState) => AppState;


export const appReducer = createReducer(
  initialState,

  on(actions.creatorFormChanged, (state, { form }) => ({ ...state, creatorInput: { ...form } })),

  on(actions.setCurrentCalculationId, (state, { currentCalculationId }) => ({ ...state, currentCalculationId })),

  on(actions.getCalculationsOk, (state, { calculationsInput }) => {
    const calculations: CalculationsState[] = [];
    calculationsInput.forEach(element => {
      calculations.push({ input: element, results: [], calculationId: element.calculationId, startedAt: '' })
    });

    const currentCalculationId = calculations.length === 0 ? '' : calculations[0].calculationId;

    const result = <AppState>{
      ...state,
      calculations: calculations,
      currentCalculationId
    };
    return result;
  }),

  on(actions.getProgressOk, (state, { startedAt, calculationResults }) => {
    const calculation = state.calculations.find(e => e.calculationId === state.currentCalculationId);
    if (!calculation) {
      return state;
    }

    const newCalculations = <CalculationsState>{
      input: calculation.input,
      startedAt,
      calculationId: calculation.calculationId,
      results: calculationResults
    }


    const newState = <AppState>{
      ...state,
      calculations: state.calculations.map(e => e.calculationId === state.currentCalculationId ? newCalculations : e)
    }

    return newState
  }),
);
