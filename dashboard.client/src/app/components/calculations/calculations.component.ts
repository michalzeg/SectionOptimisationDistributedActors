import { Component, OnInit } from '@angular/core';
import { TabInfo } from '../../models/tab-info';
import { DestroyableComponent } from '../shared/destroylable-component';
import { Observable, map } from 'rxjs';
import { uuid } from '../../shared/uuid';
import { Store } from '@ngrx/store';
import { getCalculationsRequest, redirectToCurrentCalculationId, setCurrentCalculationId } from '../../store/actions';
import { selectCalculationInputs, selectCurrentCalculationId } from '../../store/selectors';

@Component({
  selector: 'app-calculations',
  templateUrl: './calculations.component.html',
  styleUrl: './calculations.component.css'
})
export class CalculationsComponent extends DestroyableComponent implements OnInit {

  tabs$: Observable<TabInfo[]>;
  currentCalculationId$: Observable<uuid>;

  constructor(private readonly store: Store) {
    super();

    this.currentCalculationId$ = this.store.select(selectCurrentCalculationId);

    this.tabs$ = this.store.select(selectCalculationInputs).pipe(
      map(e => e.map(f => ({ label: f.label, calculationId: f.calculationId }))),
    );
  }

  ngOnInit(): void {
    this.store.dispatch(getCalculationsRequest());
  }

  tabChanged(calculationId: uuid): void {
    this.store.dispatch(setCurrentCalculationId({ currentCalculationId: calculationId }));
    this.store.dispatch(redirectToCurrentCalculationId());
  }
}
