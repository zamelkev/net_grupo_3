import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Categories } from '../models/categories.model';
import { CategoriesService } from '../services/categories.service';

@Component({
  selector: 'app-categories-form',
  templateUrl: './categories-form.component.html',
  styleUrls: ['./categories-form.component.css']
})
export class CategoriesFormComponent implements OnInit {

  editForm = this.createFormGroup(); // formulario
  error: boolean = false;
  id: string | undefined;

  constructor(
    private categoriesService: CategoriesService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) { }

  createFormGroup() {
    return new FormGroup({
      id: new FormControl({ value: null, disabled: true }),
      fullName: new FormControl('', {
        nonNullable: true,
        validators: [Validators.required, Validators.minLength(2), Validators.maxLength(100)]
      }),
      slug: new FormControl('', {
        nonNullable: true,
        validators: [Validators.required, Validators.minLength(5), Validators.maxLength(100), Validators.pattern('(^[a-z]+)(?![A-Z])([a-z_0-9]*$)')]
      }),
      imgUrl: new FormControl('', {
        nonNullable: true,
        validators: [Validators.required]
      }),
     
    })
  }

  ngOnInit(): void {

    this.activatedRoute.paramMap.subscribe({
      next: pmap => {
        let id = pmap.get("id");
        if (id) {
          this.getCategoriesAndLoadInForm(id);
        }
      }
    });

  }

  private getCategoriesAndLoadInForm(id: string) {
    this.id = id;
    this.categoriesService.findById(Number(id)).subscribe(
      {
        next: categoriesFromBackend => {

          this.editForm.reset(
            {
              id: { value: categoriesFromBackend.id, disabled: true},
              fullName: categoriesFromBackend.name,
              slug: categoriesFromBackend.slug,
              imgUrl: categoriesFromBackend.imgUrl

            } as any);

        },
        error: err => console.log(err)
      }
    );
  }

  save() {
    if (!this.editForm.valid) return
    let categories = {
      name: this.editForm.get("fullName")?.value,
      slug: this.editForm.get("slug")?.value,
      imgUrl: this.editForm.get("imgUrl")?.value
    } as any;

    let id = this.editForm.get("id")?.value;

    
    if (id) { // actualización
      categories.id = id;
      this.categoriesService.update(categories).subscribe({
        next: response => this.navigateToList(),
        error: err => this.showError(err)
      });

    } else { // creación
      this.categoriesService.create(categories).subscribe({
        next: response => this.navigateToList(),
        error: err => this.showError(err)
      });
    }
  }

  private showError(err: any): void {
    console.log(err);
    this.error = true;
  }


  private navigateToList() {
    this.router.navigate(["/back_office/categories"]);
  }

  public onDelete(): void {
    this.categoriesService.deleteById(Number(this.id)).subscribe(
      {
        next: res => this.navigateToList(),
        error: err => console.log(err)
      }
    )
  }

}
