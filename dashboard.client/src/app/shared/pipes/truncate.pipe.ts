import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'truncate',
})
export class TruncatePipe implements PipeTransform {

  transform(value: string): string {
    if (!value) return '';
    return value.length > 10 ? value.substring(0, 10) + '...' : value;
  }

}
