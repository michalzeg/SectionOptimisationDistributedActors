import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { Drawing2dDirective } from '../../../shared/drawing2d.directive';
import { SectionDrawing } from '../../../../shared/drawing2d/section-drawing';
import { Store } from '@ngrx/store';
import { selectCurrentCalculationId, selectLastResult, selectResults } from '../../../../store/selectors';
import { filter, map, takeUntil, tap, withLatestFrom } from 'rxjs';
import { DestroyableComponent } from '../../../shared/destroylable-component';
import { Section } from '../../../../shared/drawing2d/section';


@Component({
  selector: 'app-drawing',
  templateUrl: './drawing.component.html',
  styleUrl: './drawing.component.css'
})
export class DrawingComponent extends DestroyableComponent implements AfterViewInit {
  @ViewChild(Drawing2dDirective)
  drawing2dElement!: Drawing2dDirective;

  private sectionDrawing!: SectionDrawing;

  constructor(private readonly store: Store) {
    super();

    this.store.select(selectCurrentCalculationId).pipe(
      takeUntil(this.destroyed$),
      withLatestFrom(this.store.select(selectLastResult)),
      tap(() => {
        this.sectionDrawing?.reset();
      }),
      map(([, result]) => result),
      filter(e => !!e),
      map(e => new Section(e!.bottomFlangeWidth, e!.bottomFlangeThickness, e!.webThickness, e!.webHeight, e!.topFlangeWidth, e!.topFlangeThickness)),
      tap(e => this.sectionDrawing.draw(e))
    ).subscribe();

    this.store.select(selectResults).pipe(
      takeUntil(this.destroyed$),
      withLatestFrom(this.store.select(selectCurrentCalculationId)),
      map(([results, id]) => results.find(e => e.calculationId === id)?.results.slice(-1)[0]),
      filter(e => !!e),
      map(e => new Section(e!.bottomFlangeWidth, e!.bottomFlangeThickness, e!.webThickness, e!.webHeight, e!.topFlangeWidth, e!.topFlangeThickness)),
      tap(e => this.sectionDrawing.draw(e))
    ).subscribe();

  }

  ngAfterViewInit(): void {
    const canvasId = this.drawing2dElement.getCanvasId();
    this.sectionDrawing = new SectionDrawing(canvasId);
  }
}
