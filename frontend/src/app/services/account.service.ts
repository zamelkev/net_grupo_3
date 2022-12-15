import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/product.model';
import { Login } from '../models/login.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  url = 'https://localhost:7028/api/account';

  constructor(private http: HttpClient) { }


  login(login: Login) {
    return this.http.post<Login>(`${this.url}/login`, login);
  }

}
