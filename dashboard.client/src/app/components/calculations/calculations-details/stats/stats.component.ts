import { Component } from '@angular/core';
import { calculateTimeDifference } from '../../../../shared/utils/time-difference';
import { Observable, combineLatest, map } from 'rxjs';
import { Store } from '@ngrx/store';
import { selectCurrentCalculationsState, selectLastResult } from '../../../../store/selectors';
import { removeCalculationsRequest } from '../../../../store/actions';

@Component({
  selector: 'app-stats',
  templateUrl: './stats.component.html',
  styleUrl: './stats.component.css'
})
export class StatsComponent {

  finished$: Observable<boolean>;
  chromosomes$: Observable<number>;
  time$: Observable<string>

  constructor(private readonly store: Store) {

    const lastCalculationResult$ = this.store.select(selectLastResult);

    this.finished$ = lastCalculationResult$.pipe(
      map(r => r?.finished ?? false)
    );

    this.chromosomes$ = lastCalculationResult$.pipe(
      map(r => r?.chromosomesEvaluated ?? 0)
    );

    const startedAt$ = this.store.select(selectCurrentCalculationsState).pipe(
      map(e => e?.startedAt ?? '')
    );

    this.time$ = combineLatest([
      startedAt$,
      lastCalculationResult$
    ]).pipe(
      map(([startDate, result]) => ({ startDate: new Date(startDate), endDate: result?.finished ? new Date(result.occurredAt) : new Date() })),
      map(e => calculateTimeDifference(e.startDate, e.endDate))
    );

  }

  public remove(): void {
    this.store.dispatch(removeCalculationsRequest())
  }

}
