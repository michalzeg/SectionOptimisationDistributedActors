import { Pipe, PipeTransform } from '@angular/core';


@Pipe({
  name: 'multiplyNumber'
})
export class MultiplyNumberPipe implements PipeTransform {

  transform(value: number | null, factor: number = 1000): number | null {
    if (!value || isNaN(value)) {
      return value;
    }

    const result = value * factor;
    return result;
  }

}
