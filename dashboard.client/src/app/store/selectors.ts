import { createFeatureSelector, createSelector } from '@ngrx/store';
import { AppState } from './state';


export const selectFeature = createFeatureSelector<AppState>('app');

export const selectCreatorInput = createSelector(selectFeature, (state: AppState) => state.creatorInput);
export const selectCalculationInputs = createSelector(selectFeature, (state: AppState) => state.calculations.map(e => e.input));
export const selectCurrentCalculationId = createSelector(selectFeature, (state: AppState) => state.currentCalculationId);
export const selectCurrentCalculationsState = createSelector(selectFeature, (state: AppState) => state.calculations.find(e => e.calculationId == state.currentCalculationId));
export const selectLastResult = createSelector(selectFeature, (state: AppState) => state.calculations.find(e => e.calculationId == state.currentCalculationId)?.results.slice(-1)[0]);
export const selectResults = createSelector(selectFeature, (state: AppState) => state.calculations);
