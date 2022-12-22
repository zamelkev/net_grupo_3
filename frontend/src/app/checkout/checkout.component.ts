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
  skillsForm: FormGroup;
  // form



    

  // end form

  constructor(
    private cookieService: CookieService,
    private productService: ProductService,
    private fb: FormBuilder
  ) {
    this.skillsForm = this.fb.group({
      //name: '',
      skills: this.fb.array([]),
    });
  }

  // form
  get skills(): FormArray {
    return this.skillsForm.get("skills") as FormArray
  }

  //newSkill(): FormGroup {
  //  return this.fb.group({
  //    skill: '',
  //    exp: '',
  //  })
  //}

  newSkill(id:any, name:any, quantity:any, category:any, manufacturer:any, img:any, price:any, stock:any): FormGroup {
    return this.fb.group({
      skill: id,
      exp: name,
      quantity: quantity,
      category: category,
      manufacturer: manufacturer,
      img: img,
      price: price,
      stock: stock,

    })
  }

  addSkills() {
    //this.skills.push(this.newSkill());
    this.products.forEach(el => {
      this.skills.push(this.newSkill(el.id,el.name,el.quantity, el.category, el.manufacturer, el.imgUrl, el.price, el.stock))
    })
  }

  removeSkill(i: number) {
    this.skills.removeAt(i);
  }

  onSubmit() {
    console.log(this.skillsForm.value.skills);
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
    this.addSkills();
  }

}
