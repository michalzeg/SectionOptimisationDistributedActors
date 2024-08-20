import { Component } from '@angular/core';
import { takeUntil, tap } from 'rxjs';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { getAllMutationTypes } from '../../models/mutation-type';
import { getAllSelectionTypes } from '../../models/selection-type';
import { getAllCrossoverTypes } from '../../models/crossover-type';
import { DestroyableComponent } from '../shared/destroylable-component';
import { Store } from '@ngrx/store';
import { creatorFormChanged, startCalculationsRequest } from '../../store/actions';
import { initialForm } from '../../store/state';

@Component({
  selector: 'app-creator',
  templateUrl: './creator.component.html',
  styleUrl: './creator.component.css'
})
export class CreatorComponent extends DestroyableComponent {

  mutations = getAllMutationTypes();
  selections = getAllSelectionTypes();
  crossovers = getAllCrossoverTypes();

  form: FormGroup;

  constructor(private readonly fb: FormBuilder, private readonly store: Store) {
    super();
    this.form = this.fb.group({
      mutation: [initialForm.mutation, Validators.required],
      selection: [initialForm.selection, Validators.required],
      crossover: [initialForm.crossover, Validators.required],
      termination: [initialForm.termination, Validators.required],
      population: [[...initialForm.population], Validators.required],
      load: [initialForm.load, Validators.min(1)],
      modulusOfElasticity: [initialForm.modulusOfElasticity, Validators.min(1)],
      weight: [initialForm.weight, Validators.min(1)],
      spans: [initialForm.spans, Validators.min(1)],
      maxStress: [initialForm.maxStress, Validators.min(1)],
      length: [initialForm.length, Validators.min(1)],
      label: [initialForm.label, Validators.required]
    });

    this.form.valueChanges.pipe(
      tap(form => this.store.dispatch(creatorFormChanged({ form }))),
      takeUntil(this.destroyed$)
    ).subscribe();

  }

  onSubmit(): void {
    if (this.form?.valid) {
      this.store.dispatch(startCalculationsRequest());
    }
  }

}
