import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {
  public isLoading: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  constructor() { }

  showLoading(): void {
    this.isLoading.next(true);
  }

  hideLoading(): void {
    this.isLoading.next(false);
  }
}
