import { Component, OnInit, Output, EventEmitter, OnDestroy } from '@angular/core';

import { Subject, Subscription } from 'rxjs';
import { debounceTime } from 'rxjs/operators';

@Component({
  selector: 'aln-search-input',
  templateUrl: './search-input.component.html',
  styleUrls: ['./search-input.component.scss']
})
export class SearchInputComponent implements OnInit, OnDestroy {

  @Output() search = new EventEmitter<string>();

  debounce = new Subject<string>();
  
  constructor() { }

  private debounceSub: Subscription
  ngOnInit(): void {
    this.debounceSub = this.debounce
      .pipe(debounceTime(300))
      .subscribe(filter =>
        this.search.next(filter))
  }

  ngOnDestroy() : void {
    this.debounceSub.unsubscribe();
  }

}
