import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { distinctUntilChanged, tap } from 'rxjs/operators';
import { ShoppingService } from './services/shopping.service';
import { Product } from './models/product.model';
import { CookieService } from 'ngx-cookie-service';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'frontend';
  count: number | undefined;
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
    private cookieService: CookieService
  ) { }

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
}





