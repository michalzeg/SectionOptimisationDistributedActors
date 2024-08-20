import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'stressFormat',
})
export class StressFormatPipe implements PipeTransform {

  public static format(value: number): number {
    return Math.round(value / 1000);
  }

  transform(value: number): string {
    return StressFormatPipe.format(value).toString();
  }
}
