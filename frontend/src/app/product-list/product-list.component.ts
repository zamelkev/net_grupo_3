import { DataSource } from '@angular/cdk/collections';
import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';

@Component({
  /*standalone: true,
  imports: [MatPaginator],*/
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
  
export class ProductListComponent implements OnInit {

  products: Product[] = [];

  dataSource = new MatTableDataSource(this.products);
  dataSourceWithPageSize = new MatTableDataSource(this.products);

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

  @ViewChild('paginator')
    paginator!: MatPaginator;
  @ViewChild('paginatorPageSize')
    paginatorPageSize!: MatPaginator;

  pageSizes = [3, 5, 7];

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSourceWithPageSize.paginator = this.paginatorPageSize;
  }

  
    
}
