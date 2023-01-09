import { Component, OnInit } from '@angular/core';
import { Order } from '../models/order.model';
import { OrderService } from '../services/order.service';
import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';
import { AccountService } from '../services/account.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.css']
})
export class OrdersListComponent implements OnInit {
  orders: Order[] = [];
  userId: number = 0;

  constructor(
    private orderService: OrderService,
    private productService: ProductService,
    private accountService: AccountService,
    private cookieService: CookieService
) { }

  ngOnInit(): void {
    this.handleUserId()
    //this.findOrders()
  }
    findOrders(userId: number) {
      this.orderService.findAll(userId).subscribe(
        {
          next: ordersFromBackend => this.orders = ordersFromBackend,
          error: err => console.log(err)
        })
      
  }
  calcTotalItems(order: Order): number {
    return order.orderDetails!.reduce((accumulator: number, el: any) => accumulator += el.quantity,0);

  }
  calcTotalPrice(order: Order): number {
    return order.orderDetails!.reduce((accumulator: number, el: any) => accumulator += el.quantity * el.product.price, 0);
  }
  calcTotalPricePerProduct(price: number = 0, quantity: number = 0): number {
    return price * quantity
  }

  handleUserId() {
    const userName = this.cookieService.get('token_user')

    if (userName != '') {
      this.accountService.findUserIdByUserName(userName).subscribe(
        {
          next: response => this.findOrders(response),
          error: err => console.log(err)
        }
      );
    }
  }
}
