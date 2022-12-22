import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { Observable } from 'rxjs';
import { Product } from '../models/product.model';
import { Login } from '../models/login.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private tokenKey = 'token';

  url = 'https://localhost:7028/api/account';

  constructor(
    private http: HttpClient,
    //private authService: AccountService,
    private authService: any,
    private router: Router
    
  ) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    if (!this.authService.isLoggedIn()) {
      this.router.navigate(['/login']);
    }

    return true;
  }

  public logout() {
    localStorage.removeItem(this.tokenKey);
    this.router.navigate(['/login']);
  }

  public isLoggedIn(): boolean {
    let token = localStorage.getItem(this.tokenKey);
    return token != null && token.length > 0;
  }

  public getToken(): string | null {
    return this.isLoggedIn() ? localStorage.getItem(this.tokenKey) : null;
  }


  
  //url = 'https://localhost:7028/api/account';

  //constructor(private http: HttpClient) { }

  //login(login: Login) {
  //  return this.http.post<Login>(`${this.url}/login`, login);
  //}

}
