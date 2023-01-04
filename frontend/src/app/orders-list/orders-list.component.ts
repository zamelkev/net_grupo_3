import { Component, OnInit } from '@angular/core';
import { Order } from '../models/order.model';
import { OrderService } from '../services/order.service';
import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.css']
})
export class OrdersListComponent implements OnInit {
  orders: Order[] = [];

  constructor(
    private orderService: OrderService,
    private productService: ProductService
) { }

  ngOnInit(): void {
    this.findOrders()
  }
    findOrders() {
      this.orderService.findAll(1).subscribe(
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
  calcTotalPricePerProduct(price: number | undefined, quantity: number | undefined): number {
    return Number(price) * Number(quantity)
  }
}
