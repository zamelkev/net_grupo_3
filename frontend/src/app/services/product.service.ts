import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  url = 'https://localhost:7064/api/products';

  constructor(private http: HttpClient) { }

  findAll() { 
    return this.http.get<Product[]>(this.url);
  }

  findById(id: number) {
    return this.http.get<Product>(`${this.url}/${id}`);
  }

  findByManufacturerId(id: number) {
    return this.http.get<Product[]>(`${this.url}/manufacturer/${id}`);
  }

}

