import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { combineLatest, interval, map, takeUntil, tap } from 'rxjs';
import { DestroyableComponent } from '../../shared/destroylable-component';
import { environment } from '../../../../environments/environment';
import { Store } from '@ngrx/store';
import { getProgressRequest, setCurrentCalculationId } from '../../../store/actions';
import { selectCurrentCalculationId } from '../../../store/selectors';



@Component({
  selector: 'app-calculations-details',
  templateUrl: './calculations-details.component.html',
  styleUrl: './calculations-details.component.css'
})
export class CalculationsDetailsComponent extends DestroyableComponent implements OnInit {
  constructor(private readonly route: ActivatedRoute, private readonly store: Store) { super(); }

  ngOnInit(): void {

    this.route.paramMap.pipe(
      takeUntil(this.destroyed$),
      map(params => params.get('calculationId')),
      map(e => e ?? ''),
      tap(e => this.store.dispatch(setCurrentCalculationId({ currentCalculationId: e })))
    ).subscribe();

    combineLatest([
      interval(environment.refreshInterval),
      this.store.select(selectCurrentCalculationId)
    ]).pipe(
      takeUntil(this.destroyed$),
      tap(() => this.store.dispatch(getProgressRequest()))
    ).subscribe();
  }
}
