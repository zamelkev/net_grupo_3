import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit
{

  editForm = this.createFormGroup(); // formulario
  error: boolean = false;

  constructor
    (
    private productService: ProductService,
    private router: Router,
    private activatedRoute: ActivatedRoute
    ) { }

  ngOnInit(): void
  {
    this.activatedRoute.paramMap.subscribe({
      next: pmap => {
        let id = pmap.get("id");
        // if the id is set
        // fetch the book with this id
        if (id)
          this.fetchProductWithInc(Number(id))
      }
    }) 
  }

  createFormGroup() {
    return new FormGroup({
      id: new FormControl({ value: null, disabled: true }),
      name: new FormControl(),
      cost: new FormControl(),
      price: new FormControl(),
      stock: new FormControl(),
      tax: new FormControl(),
      releaseDate: new FormControl(),
      cpu: new FormControl(),
      ram: new FormControl(),
      graphicCard: new FormControl(),

     

    });
  }
}

