import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Order } from '../models/order.model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  url = 'https://localhost:7064/api/orders';

  constructor(private http: HttpClient) { }

  findAll(id:number) {
    return this.http.get<Order[]>(`${this.url}/client_id/${id}`);
  }

  cancelById(id: number) {
    return this.http.delete(`${this.url}/${id}`);
  }
}

