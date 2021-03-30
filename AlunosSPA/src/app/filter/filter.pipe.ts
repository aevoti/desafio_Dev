import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(value: any[], filterString: string, propName: string): any[] {
    const resultArray = []
    if (value == null || value.length === 0 || filterString === '' || propName === '') {
      return value
    }

    value.filter(function(element) {
      if(element.nome.toLowerCase().indexOf(filterString.toLowerCase()) >= 0) {
        resultArray.push(element)
      }
    })

    return resultArray
  }
}
