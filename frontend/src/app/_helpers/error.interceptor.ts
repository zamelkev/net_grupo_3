import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { CookieService } from 'ngx-cookie-service';
import { AccountService } from '../services/account.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private accountService: AccountService, private cookieService: CookieService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return next.handle(request).pipe(catchError(err => {
      console.log("interceptando error err: " + JSON.stringify(err.error));
      this.cookieService.set('error_http', err.error, 4, '/');
      this.cookieService.set('error_http_status', err.status, 4, '/');
      if ([401, 403].includes(err.status) && this.accountService.userValue) {
        // auto logout if 401 or 403 response returned from api
        this.accountService.logout();
      }

      const error = err.error?.message || err.statusText;
      console.error(err);
      return throwError(() => error);
    }))
  }
}
