import { Component } from '@angular/core';
import { CalculationResult } from '../../../../models/calculation-result';
import { Observable, map, tap } from 'rxjs';
import { Store } from '@ngrx/store';
import { selectCurrentCalculationsState } from '../../../../store/selectors';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrl: './table.component.css'
})
export class TableComponent {
  results$: Observable<CalculationResult[]>;

  constructor(private readonly store: Store) {
    this.results$ = this.store.select(selectCurrentCalculationsState).pipe(
      map(e => e?.results ?? []),
      map(e => [...e]),
      tap(e => e.reverse())
    );

  }
}
