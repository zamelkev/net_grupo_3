import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products: Product[] = [];

  columnNames: string[] = ['id', 'name', 'cost', 'price', 'stock', 'tax','releaseDate'];

  constructor(private service: ProductService) { }

  ngOnInit(): void {
    this.findAll();
  }

  private findAll() {
    this.service.findAll().subscribe(
      {
        next: products => this.products = products,
        error: err => console.log(err)
      }
    );
  }

}
