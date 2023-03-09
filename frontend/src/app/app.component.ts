import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { distinctUntilChanged, tap } from 'rxjs/operators';
import { CookieService } from 'ngx-cookie-service';
import { ShoppingService } from './services/shopping.service';
import { AccountService } from './services/account.service';
import { User } from './models/user.model';
import { Product } from './models/product.model';




@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'frontend';
  count: number | undefined;
  user?: User | null;
  cartTracking: Product[] = [];
  
  Breakpoints = Breakpoints;
  currentBreakpoint: string = '';

  readonly breakpoint$ = this.breakpointObserver
    .observe([Breakpoints.Large, Breakpoints.Medium, Breakpoints.Small, '(min-width: 500px)'])
    .pipe(
      tap(value => console.log(value)),
      distinctUntilChanged()
    );

  constructor(
    private breakpointObserver: BreakpointObserver,
    private shoppingService: ShoppingService,
    private authenticationService: AccountService,
    private cookieService: CookieService
  ) {
    this.authenticationService.user.subscribe(x => this.user = x);
  }

  ngOnInit(): void {
    this.breakpoint$.subscribe(() =>
      this.breakpointChanged()
    );
    this.shoppingService.count.subscribe(c => {
      this.count = c;
    });
    this.shoppingService.cartTracking.subscribe(p => {
      this.cartTracking = this.cookieService.get('cart') == "" ? [] : JSON.parse(this.cookieService.get('cart'));
    })
  }

  emptyCart() {
    this.shoppingService.emptyCart();
  }


  private breakpointChanged() {
    if (this.breakpointObserver.isMatched(Breakpoints.Large)) {
      this.currentBreakpoint = Breakpoints.Large;
    } else if (this.breakpointObserver.isMatched(Breakpoints.Medium)) {
      this.currentBreakpoint = Breakpoints.Medium;
    } else if (this.breakpointObserver.isMatched(Breakpoints.Small)) {
      this.currentBreakpoint = Breakpoints.Small;
    } else if (this.breakpointObserver.isMatched('(min-width: 500px)')) {
      this.currentBreakpoint = '(min-width: 500px)';
    }
  }

  logout() {

    //this.authenticationService.logout();
    this.cookieService.set('token_access', "", 4, '/');
    this.cookieService.set('token_user', "", 4, '/');
    this.cookieService.set('cart', "", 4, '/');
    this.cartTracking = [];

  }

  userIsLoggedIn() : boolean{
    return this.cookieService.get('token_user') != "";
  }

  getUserName(): string {
    return this.cookieService.get('token_user');
  }

  userIsAdmin() {
    return this.cookieService.get('token_access') == 'Admin';
  }

}





