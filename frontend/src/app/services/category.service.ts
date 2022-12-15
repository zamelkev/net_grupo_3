import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '../models/category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  url = 'https://localhost:7064/api/categories';

  constructor(private http: HttpClient) { }

  findAll() {
    return this.http.get<Category[]>(`${this.url}/all`);
  }

  findById(id: number) {
    return this.http.get<Category>(`${this.url}/${id}`);
  }

  create(manufacturer: Category) {
    return this.http.post<Category>(this.url, manufacturer);
  }

  update(manufacturer: Category) {
    return this.http.put<Category>(this.url, manufacturer);
  }

  deleteById(id: number) {
    return this.http.delete(`${this.url}/${id}`);
  }
}

