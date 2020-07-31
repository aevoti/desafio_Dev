import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'aln-paginator',
  templateUrl: './paginator.component.html',
  styleUrls: ['./paginator.component.scss']
})
export class PaginatorComponent implements OnInit {

  @Input() total = 0;
  @Input() currentPage = 0;
  @Input() pageSize = 0;

  @Output() pageChange = new EventEmitter<number>();

  get totalPages() {
    return Math.ceil(this.total / this.pageSize);
  }

  get lastPage() {
    return this.totalPages - 1;
  }

  constructor() { }

  ngOnInit(): void {
  }

  get prevPages() {
    let prevPages = [];
    for (let x = 1; x < 3; x++) {
      if (this.currentPage - x >= 0)
        prevPages.push(this.currentPage - x);
      else
        break;
    }

    return prevPages.reverse();
  }

  get nextPages() {
    let nextPages = [];
    for (let x = 1; x < 3; x++) {
      if (this.currentPage + x <= this.lastPage)
        nextPages.push(this.currentPage + x);
      else
        break;
    }

    return nextPages;
  }

  get canGoBack() {
    return this.currentPage > 0;
  }

  get canGoFurther() {
    return this.currentPage < this.lastPage;
  }

  goToPage(page: number) {
    this.pageChange.emit(page);
  }

  goToPrevPage() {
    this.goToPage(this.currentPage - 1);
  }

  goToNextPage() {
    this.goToPage(this.currentPage + 1);
  }

  goToFirstPage() {
    this.goToPage(0);
  }

  goToLastPage() {
    this.goToPage(this.lastPage);
  }
}
