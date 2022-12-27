import { Injectable } from '@angular/core';
import { User } from '../shared/user';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import {
  HttpClient,
  HttpHeaders,
  HttpErrorResponse,
} from '@angular/common/http';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private userSubject: BehaviorSubject<User | null>;

  public user: Observable<User | null>;



  constructor(

    private router: Router,

    private http: HttpClient

  ) {

    this.userSubject = new BehaviorSubject<User | null>(null);

    this.user = this.userSubject.asObservable();

  }



  public get userValue() {

    return this.userSubject.value;

  }



  login(username: string, password: string) {

    return this.http.post<any>(`/users/authenticate`, { username, password }, { withCredentials: true })

      .pipe(map(user => {

        this.userSubject.next(user);

        this.startRefreshTokenTimer();

        return user;

      }));

  }



  logout() {

    this.http.post<any>(`/users/revoke-token`, {}, { withCredentials: true }).subscribe();

    this.stopRefreshTokenTimer();

    this.userSubject.next(null);

    this.router.navigate(['/login']);

  }



  refreshToken() {

    return this.http.post<any>(`/users/refresh-token`, {}, { withCredentials: true })

      .pipe(map((user) => {

        this.userSubject.next(user);

        this.startRefreshTokenTimer();

        return user;

      }));

  }



  // helper methods



  private refreshTokenTimeout?: any;



  private startRefreshTokenTimer() {

    // parse json object from base64 encoded jwt token

    const jwtBase64 = this.userValue!.jwtToken!.split('.')[1];

    const jwtToken = JSON.parse(atob(jwtBase64));



    // set a timeout to refresh the token a minute before it expires

    const expires = new Date(jwtToken.exp * 1000);

    const timeout = expires.getTime() - Date.now() - (60 * 1000);

    this.refreshTokenTimeout = setTimeout(() => this.refreshToken().subscribe(), timeout);

  }



  private stopRefreshTokenTimer() {

    clearTimeout(this.refreshTokenTimeout);

  }


  //endpoint: string = 'http://localhost:7064/api';
  //headers = new HttpHeaders().set('Content-Type', 'application/json');
  //currentUser = {};
  //constructor(private http: HttpClient, public router: Router) { }
  //// Sign-up
  //signUp(user: User): Observable<any> {
  //  let api = `${this.endpoint}/register-user`;
  //  return this.http.post(api, user).pipe(catchError(this.handleError));
  //}
  //// Sign-in
  //signIn(user: User) {
  //  return this.http
  //    .post<any>(`${this.endpoint}/account`, user)
  //    .subscribe((res: any) => {
  //      localStorage.setItem('access_token', res.token);
  //      this.getUserProfile(res._id).subscribe((res) => {
  //        this.currentUser = res;
  //        //this.router.navigate(['user-profile/' + res.msg._id]);
  //      });
  //    });
  //}
  //getToken() {
  //  return localStorage.getItem('access_token');
  //}
  //get isLoggedIn(): boolean {
  //  let authToken = localStorage.getItem('access_token');
  //  return authToken !== null ? true : false;
  //}
  //doLogout() {
  //  let removeToken = localStorage.removeItem('access_token');
  //  if (removeToken == null) {
  //    this.router.navigate(['log-in']);
  //  }
  //}
  //// User profile
  //getUserProfile(id: any): Observable<any> {
  //  let api = `${this.endpoint}/user-profile/${id}`;
  //  return this.http.get(api, { headers: this.headers }).pipe(
  //    map((res) => {
  //      return res || {};
  //    }),
  //    catchError(this.handleError)
  //  );
  //}
  //// Error
  //handleError(error: HttpErrorResponse) {
  //  let msg = '';
  //  if (error.error instanceof ErrorEvent) {
  //    // client-side error
  //    msg = error.error.message;
  //  } else {
  //    // server-side error
  //    msg = `Error Code: ${error.status}\nMessage: ${error.message}`;
  //  }
  //  return throwError(msg);
  //}
}
