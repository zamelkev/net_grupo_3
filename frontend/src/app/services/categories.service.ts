import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Categories } from '../models/categories.model';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  url = 'https://localhost:7064/api/categories';

  constructor(private http: HttpClient) { }

  findAll() {
    return this.http.get<Categories[]>(`${this.url}/all`);
  }

  findById(id: number) {
    return this.http.get<Categories>(`${this.url}/${id}`);
  }

  create(categories: Categories) {
    return this.http.post<Categories>(this.url, categories);
  }

  update(categories: Categories) {
    return this.http.put<Categories>(this.url, categories);
  }

  deleteById(id: number) {
    return this.http.delete(`${this.url}/${id}`);
  }


}

