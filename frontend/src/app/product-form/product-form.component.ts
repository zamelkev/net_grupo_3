import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../models/product.model';
import { ProductService } from '../services/product.service';
import { Category } from '../models/category.model';
import { CategoryService } from '../services/category.service';
import { Manufacturer } from '../models/manufacturer.model';
import { ManufacturerService } from '../services/manufacturer.service';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit
{
  product: Product | undefined;
  categories: Category[] | undefined;
  manufacturers: Manufacturer[] | undefined;
  id: number | undefined;
  editForm = this.createFormGroup(); // formulario
  error: boolean = false;

  constructor
    (
    private productService: ProductService,
    private categoryService: CategoryService,
    private manufacturerService: ManufacturerService,
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
    this.fetchCategories()
    this.fetchManufacturers()
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
      categoryId: new FormControl(),
      manufacturerId: new FormControl(),
    });
  }
  fetchProductWithInc(id: number | string | undefined) {
    this.id = Number(id);
    this.productService.findById(Number(id)).subscribe({
      next: productFromBackend => this.steUpProductUpdate(productFromBackend),
      error: err => console.log(err)
    })
  }

  fetchCategories() {
    this.categoryService.findAll().subscribe({
      next: categoryFromBackend => this.categories = categoryFromBackend,
      error: err => console.log(err)
    })
  }
  fetchManufacturers() {
    this.manufacturerService.findAll().subscribe({
      next: manufacturerFromBackend => this.manufacturers = manufacturerFromBackend,
      error: err => console.log(err)
    })  }

  steUpProductUpdate(productFromBackend: Product): void {
    this.product = productFromBackend
    this.editForm.reset(
      {
        id: { value: productFromBackend.id, disabled: true },
        name: productFromBackend.name,
        cost: productFromBackend.cost,
        price: productFromBackend.price,
        stock: productFromBackend.stock,
        tax: productFromBackend.tax,
        releaseDate: productFromBackend.releaseDate,
        cpu: productFromBackend.cpu,
        ram: productFromBackend.ram,
        graphicCard: productFromBackend.graphicCard,
        categoryId: productFromBackend.categoryId,
        manufacturerId: productFromBackend.manufacturerId
      } as any);

  }


  save() {
    // extraer los datos del formulario y enviar al backend con BookService.create POST
    // console.log(this.editForm.get("title")?.value);

    let product = {
      name: this.editForm.get("name")?.value,
      price: Number(this.editForm.get("price")?.value),
      cost: Number(this.editForm.get("cost")?.value),
      stock: Number(this.editForm.get("stock")?.value),
      tax: Number(this.editForm.get("tax")?.value),
      releaseDate: this.editForm.get("releaseDate")?.value,
      cpu: this.editForm.get("cpu")?.value,
      ram: this.editForm.get("ram")?.value,
      graphicCard: this.editForm.get("graphicCard")?.value,
      categoryId: this.editForm.get("categoryId")?.value,
      manufacturerId: this.editForm.get("manufacturerId")?.value

    } as any;

    console.log(product);

    // detectar si es actualizar o creación
    let id = this.editForm.get("id")?.value;
    if (id) {
      product.id = id;
      this.productService.update(product).subscribe({
        next: response => this.navigateToList(),
        error: err => this.showError(err)
      });

    } else {
      this.productService.create(product).subscribe({
        next: response => this.navigateToList(),
        error: err => this.showError(err)
      });
    }
  }
    showError(err: any): void {
      console.log(err);
      this.error = true;
    }
    navigateToList(): void {
      this.router.navigate(["/back_office/products"]);
  }

  public onDelete(): void {
    this.productService.deleteById(Number(this.id)).subscribe(
      {
        next: res => this.navigateToList(),
        error: err => console.log(err)
      }
    )
  }
}

