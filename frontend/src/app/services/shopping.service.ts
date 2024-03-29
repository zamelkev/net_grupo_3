import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs';
import { Product } from '../models/product.model';
import { Order } from '../models/order.model';
import { CookieService } from 'ngx-cookie-service';


@Injectable({
  providedIn: 'root'
})
export class ShoppingService {

  url = 'https://localhost:7064/api/orders';
  
  counter  = 1;
  count: BehaviorSubject<number>;
  cart: Product[] = [];
  cartTracking: BehaviorSubject<Product[]>;
  constructor(private cookieService: CookieService, private http: HttpClient) {
    this.count = new BehaviorSubject(this.counter);
    this.cartTracking = new BehaviorSubject(this.cart); 
  }
  
  // API Orders
  create(order: Order) {
    return this.http.post<Order | Error>(this.url, order, { observe: 'response' });
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

    const myCart: any[] = this.cookieService.get('cart') == "" ? [] : JSON.parse(this.cookieService.get('cart'));
    if (!myCart.some(el => el.id == product.id)) {
      myCart.push({
        id: product.id
      })
      this.cookieService.set('cart', JSON.stringify(myCart), 4, '/');
      this.cartTracking.next([...myCart])
    }
  }
  emptyCart() {
    this.cookieService.set('cart', "[]", 4, '/');
    this.cartTracking.next([])
  }
  removeItemFromCart(position:number) {
    let myCart: any[] = this.cookieService.get('cart') == "" ? [] : JSON.parse(this.cookieService.get('cart'));
    myCart = myCart.slice(0, position).concat(myCart.slice(position + 1))
    this.cookieService.set('cart', JSON.stringify(myCart), 4, '/');
    this.cartTracking.next([...myCart])
  }
  
}
