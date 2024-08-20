import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, exhaustMap, filter, map, switchMap, tap, withLatestFrom } from 'rxjs/operators';
import * as actions from './actions';
import { Store } from '@ngrx/store';
import { AppState } from './state';
import { of } from 'rxjs';
import { HttpService } from '../services/http.service';
import { Router } from '@angular/router';
import { selectCreatorInput, selectCurrentCalculationId } from './selectors';
@Injectable()
export class AppEffects {

  constructor(
    private actions$: Actions,
    private readonly store: Store<AppState>,
    private readonly http: HttpService,
    private readonly router: Router
  ) { }

  getCalculationsRequest$ = createEffect(() => this.actions$.pipe(
    ofType(actions.getCalculationsRequest),
    switchMap(() => this.http.getCalculations().pipe(
      map(result => actions.getCalculationsOk({ calculationsInput: result.calculationsList })),
      catchError(() => of(actions.getCalculationsFailed()))
    ))
  ));

  getCalculationsOk$ = createEffect(() => this.actions$.pipe(
    ofType(actions.getCalculationsOk),
    map(() => actions.redirectToCurrentCalculationId())
  ));

  getProgressRequest$ = createEffect(() => this.actions$.pipe(
    ofType(actions.getProgressRequest),
    withLatestFrom(this.store.select(selectCurrentCalculationId)),
    map(([, currentCalculationId]) => currentCalculationId),
    filter(id => id !== ''),
    switchMap(id => this.http.getProgress(id).pipe(
      map(result => actions.getProgressOk({ startedAt: result.startedAt, calculationResults: result.calculationResults })),
      catchError(() => of(actions.getProgressFailed()))
    ))
  ));

  removeCalculation$ = createEffect(() => this.actions$.pipe(
    ofType(actions.removeCalculationsRequest),
    withLatestFrom(this.store.select(selectCurrentCalculationId)),
    map(([, id]) => id),
    exhaustMap(id => this.http.removeCalculations(id).pipe(
      map(() => actions.removeCalculationsOk()),
      catchError(() => of(actions.getProgressFailed()))
    ))
  ));

  removeCalculationsOk$ = createEffect(() => this.actions$.pipe(
    ofType(actions.removeCalculationsOk),
    map(() => actions.getCalculationsRequest()),
  ));

  redirectToCurrentCalculationId$ = createEffect(() => this.actions$.pipe(
    ofType(actions.redirectToCurrentCalculationId),
    withLatestFrom(this.store.select(selectCurrentCalculationId)),
    tap(([, id]) => this.router.navigate([`calculations/${id}`],)),
  ), { dispatch: false });

  startCalculationsRequest$ = createEffect(() => this.actions$.pipe(
    ofType(actions.startCalculationsRequest),
    withLatestFrom(this.store.select(selectCreatorInput)),
    map(([, input]) => ({
      ...input,
      maxStress: input.maxStress * 1_000,
      modulusOfElasticity: input.modulusOfElasticity * 1000_000
    })),
    switchMap(input => this.http.startCalculations(input).pipe(
      map(() => actions.startCalculationsOk()),
      catchError(() => of(actions.startCalculationsFailed()))
    ))
  ));

}


