import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpRequest, HttpHandler } from "@angular/common/http";
import { AccountService } from "../services/account.service";
@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private authService: AccountService) { }
  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const authToken = this.authService.getToken();
    req = req.clone({
      setHeaders: {
        Authorization: "Bearer " + authToken
      }
    });
    return next.handle(req);
  }
}
