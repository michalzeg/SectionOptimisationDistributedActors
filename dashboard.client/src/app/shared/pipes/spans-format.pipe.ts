import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'spansFormat',
})
export class SpansFormatPipe implements PipeTransform {

  transform(value: number[]): string {
    const result = value.map(e => Math.floor(e).toString()).reduce((p, n) => `${p} - ${n}`);

    return result;
  }

}
