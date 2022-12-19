import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Product } from '../models/product.model';
import { CookieService } from 'ngx-cookie-service';


@Injectable({
  providedIn: 'root'
})
export class ShoppingService {
  counter  = 1;
  count: BehaviorSubject<number>;
  cart: Product[] = [];
  cartTracking: BehaviorSubject<Product[]>;
  constructor(private cookieService: CookieService) {
    this.count = new BehaviorSubject(this.counter);
    this.cartTracking = new BehaviorSubject(this.cart)
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
  addProduct(product: Product) {
    const myCart: Product[] | any[] = JSON.parse(this.cookieService.get('cart'));
    if (myCart.indexOf(product) == -1) {
      myCart.push(product)
      this.cookieService.set('cart', JSON.stringify(myCart), 4, '/');
      this.cartTracking.next([...myCart])
    }
  }
}
