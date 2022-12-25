import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';
import { ProductsCart } from '../models/products-cart';
import { CookieService } from 'ngx-cookie-service';
import { FormGroup, FormControl, FormArray, FormBuilder } from '@angular/forms'


@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  products: ProductsCart[] = [];
  cart: any[] = [];
  itemsForm: FormGroup;
  totalPrice:number = 0;
  // form



    

  // end form

  constructor(
    private cookieService: CookieService,
    private productService: ProductService,
    private fb: FormBuilder
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
  }

  onSubmit() {
    console.log(this.itemsForm.value.items);
  }

  // end form

  ngOnInit(): void {
    this.fetchCart()
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
    console.log("this is the cart")
    console.log(this.products)
    //this.cart = products.map(el => { return { id: el.id, qty: 1 } });
    this.addItems();
  }

  // this detects changes in the quantity of the products
  handleQuantityPersistence(item:any):void {
    console.log(item.value.name)
    this.calcTotal()
  }

  // calculate total
  calcTotal(): void {
    //this.totalPrice += carrier.value.price * carrier.value.quantity
    console.log(this.items.controls[0].value.quantity)
    let counter:number = 0 
    this.items.controls.forEach(el => {
      counter += el.value.quantity * el.value.price
    })
    this.totalPrice = counter;
  }

}
