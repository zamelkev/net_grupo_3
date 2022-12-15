import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShoppingService {
  counter  = 1;
  count: BehaviorSubject<number>;
  constructor() {

    this.count = new BehaviorSubject(this.counter);
  }

  nextCount() {
    this.count.next(++this.counter);
  }
  prevCount() {
    this.count.next(--this.counter);
  }
  setCount(num: number) {
    this.count.next(this.counter = num);
  }
}
