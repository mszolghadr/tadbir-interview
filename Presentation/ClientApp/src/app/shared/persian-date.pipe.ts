import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'persianDate'
})
export class PersianDatePipe implements PipeTransform {

  transform(value: string, ...args: string[]): string {
    let timeStyle = 'medium';
    if (args.some(a => a === 'dateOnly')) {
      timeStyle = undefined;
    }
    const options: any = { dateStyle: 'short', timeStyle, timeZone: 'Asia/Tehran' };
    const dateFormat = new Intl.DateTimeFormat('fa-IR', options);
    // added Z to show source date is UTC
    const date = Date.parse(value + (value.endsWith('Z') ? '' : 'Z'));
    return dateFormat.format(date);
  }

}
