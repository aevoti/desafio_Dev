import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'aln-sort-btn',
  templateUrl: './sort-btn.component.html',
  styleUrls: ['./sort-btn.component.scss']
})
export class SortBtnComponent implements OnInit {

  @Input() property: string = '';
  @Input() sortType = SortType.IDLE;
  @Input() allowIdle: boolean = true;

  @Output() sort = new EventEmitter<SortType>(); 


  constructor() { }

  ngOnInit(): void {
  }

  isDecSort(sortType: SortType) {
    return sortType == SortType.DEC;
  }

  isAscSort(sortType: SortType) {
    return sortType == SortType.ASC;
  }

  onButtonClick() {
    switch(this.sortType){
      case SortType.IDLE:
        this.sortType = SortType.ASC;
        break;
      case SortType.ASC:
        this.sortType = SortType.DEC;
        break;
      case SortType.DEC:
        if (this.allowIdle)
          this.sortType = SortType.IDLE;
        else
          this.sortType = SortType.ASC
        break;
    }
    
    this.sort.emit(this.sortType);
  }
}

export enum SortType {
  ASC,
  DEC,
  IDLE
}
