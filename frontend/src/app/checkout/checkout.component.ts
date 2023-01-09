import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';
import { ProductsCart } from '../models/products-cart';
import { ShoppingService } from '../services/shopping.service';
import { CookieService } from 'ngx-cookie-service';
import { FormGroup, FormControl, FormArray, FormBuilder } from '@angular/forms'
import { ActivatedRoute, Router } from '@angular/router';
import { Order } from '../models/order.model';
import { AccountService } from '../services/account.service';


@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  products: ProductsCart[] = [];
  cart: any[] = [];
  itemsForm: FormGroup;
  totalPrice: number = 0;
  // global cart component
  cartTracking: Product[] = [];
  errorReport: any = {
    isError : false,
    text: ''
  }
  userId: number = 0

  constructor(
    private cookieService: CookieService,
    private productService: ProductService,
    private fb: FormBuilder,
    private shoppingService: ShoppingService,
    private router: Router,
    private accountService: AccountService,
  ) {
    this.itemsForm = this.fb.group({
      //name: '',
      items: this.fb.array([]),
    });
  }

  // form
  get items(): FormArray {
    return this.itemsForm.get("items") as FormArray
  }

  newItem(id:any, name:any, quantity:any, category:any, manufacturer:any, img:any, price:any, stock:any): FormGroup {
    return this.fb.group({
      id: id,
      name: name,
      quantity: quantity,
      category: category,
      manufacturer: manufacturer,
      img: img,
      price: price,
      stock: stock,

    })
  }

  addItems() {
    //this.skills.push(this.newSkill());
    this.products.forEach(el => {
      this.items.push(this.newItem(el.id,el.name,el.quantity, el.category, el.manufacturer, el.imgUrl, el.price, el.stock))
    })
    // then sum (initialize)
    this.calcTotal()
  }

  removeItem(i: number) {
    this.items.removeAt(i);
    this.calcTotal()
    this.handleRemoveItemFromCartIcon(i)
  }

  handleUserId() {
    const userName = this.cookieService.get('token_user')

    if (userName != '') {
      this.accountService.findUserIdByUserName(userName).subscribe(
        {
          next: response => this.userId = response,
          error: err => this.handleResponse(err)
        }
      );
    }
  }

  // posting the order
  onSubmit() {
    // Control de usuario
    const userName = this.cookieService.get('token_user')
    if (userName == '') {
      this.router.navigate(['/login']);
      return
    }
    
    

    const formattedArray = this.itemsForm.value.items.map((el:any )=> { return { productId: el.id, quantity: el.quantity } })
    const tzoffset:number = (new Date()).getTimezoneOffset() * 60000; //offset in milliseconds
    const orderDate: string = (new Date(Date.now() - tzoffset)).toISOString().slice(0, -1);
    const order: Order = {
      "orderTime": orderDate,
      "orderDetails": formattedArray,
      "userId": this.userId
    }
    // post order to shopping service
    this.shoppingService.create(order).subscribe(
      {
        next: response => this.handleResponse(response),
        error: err => this.handleResponse(err)
      }
    );
  }

  handleResponse(response: any) {
    console.log("response: " + this.cookieService.get('error_http') + " status: " + this.cookieService.get('error_http_status'));
    var status = this.cookieService.get('error_http_status');
    var msg = this.cookieService.get('error_http');
    if (status == '200')
      // redirect to success page here
      this.handleSuccessfulOrder();

    else if (status == '500') {
      this.errorReport.isError = true
      this.errorReport.text = msg;
      console.log(msg);
    }
    else {
      this.errorReport.isError = true
      this.errorReport.text = msg;
      console.log(msg);
    }
  }
  handleSuccessfulOrder() {
    this.shoppingService.emptyCart();
    this.router.navigate(["/shopping_report"]);
  }

  // end form

  ngOnInit(): void {
    this.fetchCart()
    // global cart interaction
    this.shoppingService.cartTracking.subscribe(p => {
      this.cartTracking = this.cookieService.get('cart') == "" ? [] : JSON.parse(this.cookieService.get('cart'));
      if (this.cartTracking.length == 0)
        this.redirectToHome()
    })
    this.handleUserId()
  }
  fetchCart() {
    const ids: number[] = JSON.parse(this.cookieService.get('cart')).map((el: { id: any; }) => Number(el.id));
      this.productService.findProductsById(ids).subscribe(
        {
          next: products => this.handleProducts(products),
          error: err => console.log(err)
        }
      );
    }
  handleProducts(products: Product[]): void {
    this.products = products.map(el => { return { ...el, quantity: 1 } as ProductsCart });
    this.addItems();
  }

  // this detects changes in the quantity of the products
  handleQuantityPersistence(item:any):void {
    this.calcTotal()
  }

  // calculate total
  calcTotal(): void {
    this.totalPrice = Math.round(this.items.controls.reduce(
      (total, currEl) =>
        total += currEl.value.price * currEl.value.quantity, 0
    ) * 100) / 100
  }

  // calc single item * quantity price (handles decimal rounding)
  calcSingleItemPrice(quantity:number, price:number): number {
    return Math.round(quantity * price * 100) / 100
  }



  // removes item from global cart icon handler
  // handles async event
  handleRemoveItemFromCartIcon(position: number) {
    this.shoppingService.removeItemFromCart(position)
  }


  // on empty cart say hello
  redirectToHome() {
    this.router.navigate(["/"]);
  }
}
