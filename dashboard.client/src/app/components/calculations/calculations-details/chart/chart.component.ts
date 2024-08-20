import { Component } from '@angular/core';
import { ChartData, ChartOptions } from 'chart.js';
import { StressFormatPipe } from '../../../../shared/pipes/stress-format.pipe';
import { DestroyableComponent } from '../../../shared/destroylable-component';
import { takeUntil, tap } from 'rxjs';
import { Store } from '@ngrx/store';
import { selectCurrentCalculationId, selectCurrentCalculationsState } from '../../../../store/selectors';
import { CalculationsState } from '../../../../store/state';

const documentStyle = getComputedStyle(document.documentElement);
const textColor = documentStyle.getPropertyValue('--text-color');
const textColorSecondary = documentStyle.getPropertyValue('--text-color-secondary');
const surfaceBorder = documentStyle.getPropertyValue('--surface-border');
const borderColor1 = documentStyle.getPropertyValue('--blue-500');
const borderColor2 = documentStyle.getPropertyValue('--green-500');

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrl: './chart.component.css'
})
export class ChartComponent extends DestroyableComponent {
  data: ChartData;
  options: ChartOptions;


  constructor(private readonly store: Store) {
    super();
    this.options = this.getOptions();
    this.data = {
      labels: [],
      datasets: [
        {
          label: 'Total weight [kN]',
          fill: false,
          borderColor: borderColor1,
          yAxisID: 'y',
          tension: 0.4,
          data: []
        },
        {
          label: 'Stress [N/mm2]',
          fill: false,
          borderColor: borderColor2,
          yAxisID: 'y1',
          tension: 0.4,
          data: []
        }
      ]
    };

    this.store.select(selectCurrentCalculationId).pipe(
      takeUntil(this.destroyed$),
      tap(() => {
        this.data.labels = [];
        this.data.datasets[0].data = [];
        this.data.datasets[1].data = [];
        this.data = { ...this.data };
      })
    ).subscribe();

    this.store.select(selectCurrentCalculationsState).pipe(
      takeUntil(this.destroyed$),
      tap(e => this.refreshChart(e))
    ).subscribe();

  }

  private refreshChart(calculationsState: CalculationsState | undefined) {
    if (!calculationsState) {
      return;
    }

    const labels = this.data.labels;
    if (!labels) {
      return;
    }

    if (calculationsState.results.length <= labels.length) {
      return;
    }

    const difference = calculationsState.results.filter((e, i) => i > labels.length - 1);
    const length = labels.length;
    for (let index = 0; index < difference.length; index++) {
      const item = difference[index];

      this.data.labels?.push(length + index);
      this.data.datasets[0].data.push(item.totalWeight);
      this.data.datasets[1].data.push(StressFormatPipe.format(item.maxStress));
    }

    this.data = { ...this.data };

  }

  private getOptions(): ChartOptions {
    return {
      maintainAspectRatio: false,
      aspectRatio: 0.5,
      animation: false,
      plugins: {
        legend: {
          labels: {
            color: textColor
          }
        }
      },
      scales: {
        x: {
          ticks: {
            color: textColorSecondary
          },
          grid: {
            color: surfaceBorder
          }
        },
        y: {
          type: 'linear',
          display: true,
          position: 'left',
          ticks: {
            color: textColorSecondary
          },
          grid: {
            color: surfaceBorder
          },
          title: {
            text: 'Total Weight [kN]',
            display: true,
            color: textColorSecondary
          }
        },
        y1: {
          type: 'linear',
          display: true,
          position: 'right',
          ticks: {
            color: textColorSecondary
          },
          grid: {
            drawOnChartArea: false,
            color: surfaceBorder
          },
          title: {
            text: 'Stress [N/mm2]',
            display: true,
            color: textColorSecondary
          }
        }
      }
    };
  }

}
