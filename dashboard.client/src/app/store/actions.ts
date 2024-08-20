import { createAction, props } from '@ngrx/store';
import { CalculationsInput } from '../models/calculations-input';
import { uuid } from '../shared/uuid';
import { CalculationResult } from '../models/calculation-result';

export const redirectToCurrentCalculationId = createAction('[Router] router redirect');

export const creatorFormChanged = createAction('[Form] form changed', props<{ form: CalculationsInput }>());

export const startCalculationsRequest = createAction('[Http] start calculations');
export const startCalculationsOk = createAction('[Http] start calculations ok');
export const startCalculationsFailed = createAction('[Http] start calculations failed');

export const getProgressRequest = createAction('[Http] get progress');
export const getProgressOk = createAction('[Http] get progress ok', props<{ startedAt: string, calculationResults: CalculationResult[] }>());
export const getProgressFailed = createAction('[Http] get progress failed');

export const getCalculationsRequest = createAction('[Http] get calculations');
export const getCalculationsOk = createAction('[Http] get calculations ok', props<{ calculationsInput: CalculationsInput[] }>());
export const getCalculationsFailed = createAction('[Http] get calculations failed');

export const removeCalculationsRequest = createAction('[Http] remove calculations');
export const removeCalculationsOk = createAction('[Http] remove calculations ok')
export const removeCalculationsFailed = createAction('[Http] remove calculations failed');

export const setCurrentCalculationId = createAction('[Calculations] set current calculation id', props<{ currentCalculationId: uuid }>());
