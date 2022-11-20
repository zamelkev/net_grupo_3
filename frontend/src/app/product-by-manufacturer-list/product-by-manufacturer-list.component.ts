import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';

import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';


@Component({
  selector: 'app-product-by-manufacturer-list',
  templateUrl: './product-by-manufacturer-list.component.html',
  styleUrls: ['./product-by-manufacturer-list.component.css'],
})
export class ProductByManufacturerListComponent implements OnInit {

  products: Product[] = [];

  columnNames: string[] = ['id', 'name', 'cost', 'price', 'stock', 'tax', 'releaseDate'];

  constructor(
    private service: ProductService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    // extrae el id de la URL
    this.activatedRoute.paramMap.subscribe(
      {
        next: pmap => this.findByManufacturer(pmap.get("id")),
        error: err => console.log(err)
      }
    );
  }

  private findByManufacturer(id: string | number | null) {
    this.service.findByManufacturerId(Number(id)).subscribe(
      {
        next: products => this.products = products,
        error: err => console.log(err)
      }
    );
  }

}
