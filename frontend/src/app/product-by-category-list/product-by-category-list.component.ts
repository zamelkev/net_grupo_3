import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';

import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';


@Component({
  selector: 'app-product-by-category-list',
  templateUrl: './product-by-category-list.component.html',
  styleUrls: ['./product-by-category-list.component.css'],
})
export class ProductByCategoryListComponent implements OnInit {

  products: Product[] = [];

  columnNames: string[] = ['name', 'cost', 'price', 'stock', 'tax', 'releaseDate'];

  constructor(
    private service: ProductService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    // extrae el id de la URL
    this.activatedRoute.paramMap.subscribe(
      {
        next: pmap => this.findByCategory(pmap.get("slug")),
        error: err => console.log(err)
      }
    );
  }

  private findByCategory(slug: string | null) {
    this.service.findByCategorySlug(slug).subscribe(
      {
        next: products => this.products = products,
        error: err => console.log(err)
      }
    );
  }
  public formatInt(myNumber: number | undefined) : string {
    return Number(String(myNumber).split(".")[0]).toLocaleString('en-US').replace(/,/g, ".")
  }
}
