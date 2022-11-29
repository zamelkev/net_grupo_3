import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product-detail-crud',
  templateUrl: './product-detail-crud.component.html',
  styleUrls: ['./product-detail-crud.component.css']
})
export class ProductDetailCrudComponent implements OnInit {

  product: Product | undefined;

  constructor(
    private service: ProductService,
    private activatedRoute: ActivatedRoute,
    private router: Router
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
    this.router.navigate(["/back_office/products"]);
  }

  public onDelete(id: number | string | undefined): void {
    this.service.deleteById(Number(id)).subscribe(
      {
        next: res => this.navigateToList(),
        error: err => console.log(err)
      }
    )
  }


}
