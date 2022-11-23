import { DataSource } from '@angular/cdk/collections';
import { AfterViewInit, Component, ViewChild, OnInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';

import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';

@Component({
  /*standalone: true,
  imports: [MatPaginator],*/
  selector: 'app-product-list-crud',
  templateUrl: './product-list-crud.component.html',
  styleUrls: ['./product-list-crud.component.css']
})
  
export class ProductListCrudComponent implements OnInit {

  products: Product[] = [];
  dataSource = new MatTableDataSource(this.products);
  dataSourceWithPageSize = new MatTableDataSource(this.products);

  columnNames: string[] = ['id', 'name', 'cost', 'price', 'stock', 'tax','releaseDate', 'actions'];

  constructor(
    private service: ProductService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) { }

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

  onDelete(id: number) {
    this.service.deleteById(id).subscribe(
      {
        next: response => this.findAll(),
        error: err => console.log(err)
      }
    )
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
