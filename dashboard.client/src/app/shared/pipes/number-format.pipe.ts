import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'numberFormat'
})
export class NumberFormatPipe implements PipeTransform {

  transform(value: number | null): string {
    if (!value || isNaN(value)) {
      return '';
    }

    // Convert the number to string and split it into an array of characters
    const numString = value.toString().split('');

    // Reverse the array to make it easier to add spaces
    numString.reverse();

    // Add spaces after every third digit
    for (let i = 3; i < numString.length; i += 4) {
      numString.splice(i, 0, ' ');
    }

    // Reverse the array again and join it to get the formatted number
    return numString.reverse().join('');
  }

}


