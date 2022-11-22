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

  create(product: Product) {
    return this.http.post<Product>(`${this.url}`, product);
  }

  update(product: Product) {
    return this.http.post<Product>(`${this.url}`, product);
  }

  // home
  findByManufacturerSlug(slug: string | null) {
    return this.http.get<Product[]>(`${this.url}/manufactuer/slug/${slug}`);
  }
  findByCategorySlug(slug: string | null) {
    return this.http.get<Product[]>(`${this.url}/category/slug/${slug}`);
  }
}

