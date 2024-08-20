import { Component } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Store } from '@ngrx/store';
import { selectCurrentCalculationsState } from '../../../../store/selectors';
import { CalculationsInput } from '../../../../models/calculations-input';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent {

  input$: Observable<CalculationsInput | undefined>;

  constructor(private readonly store: Store) {
    this.input$ = this.store.select(selectCurrentCalculationsState).pipe(
      map(e => e?.input)
    );
  }

}
