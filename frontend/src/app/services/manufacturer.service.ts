import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Manufacturer } from '../models/manufacturer.model';

@Injectable({
  providedIn: 'root'
})
export class ManufacturerService {

  url = 'https://localhost:7064/api/manufacturers';

  constructor(private http: HttpClient) { }

  findAll() {
    return this.http.get<Manufacturer[]>(`${this.url}/all`);
  }

  findById(id: number) {
    return this.http.get<Manufacturer>(`${this.url}/${id}`);
  }

  create(manufacturer: Manufacturer) {
    return this.http.post<Manufacturer>(this.url, manufacturer);
  }

  update(manufacturer: Manufacturer) {
    return this.http.put<Manufacturer>(this.url, manufacturer);
  }

  deleteById(id: number) {
    return this.http.delete(`${this.url}/${id}`);
  }
 

}

