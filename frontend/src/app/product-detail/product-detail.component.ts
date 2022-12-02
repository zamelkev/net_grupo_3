import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  product: Product | undefined;

  constructor(
    private service: ProductService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private location: Location
  ) { }

  ngOnInit(): void {
    // extrae el id de la URL
    this.activatedRoute.paramMap.subscribe(
      {
        next: pmap => this.fetchProduct(pmap.get("id")),
        error: err => console.log(err)
      }
    );
  }

  private fetchProduct(id: string | number | null) {

    this.service.fingByIdWithInclude(Number(id)).subscribe(
      {
        next: productFromBackend => this.product = productFromBackend,
        error: err => console.log(err)
      }
    );
  }

  private navigateToList() {
    this.router.navigate(["/products"]);
  }

  public back(): void {
    this.location.back()
  }

  public buy(): void {
  }

  public formatInt(myNumber: number | undefined): string {
    return Number(String(myNumber).split(".")[0]).toLocaleString('en-US').replace(/,/g, ".")
  }
}