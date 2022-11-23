import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
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

  constructor(
    private categoriesService: CategoriesService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) { }

  createFormGroup() {
    return new FormGroup({
      id: new FormControl({ value: null, disabled: true }),
      fullName: new FormControl(),
      slug: new FormControl(),
      imgUrl: new FormControl(),
     
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
    this.categoriesService.findById(Number(id)).subscribe(
      {
        next: categoriesFromBackend => {

          this.editForm.reset(
            {
              id: { value: categoriesFromBackend.id, disabled: true},
              fullName: categoriesFromBackend.name,
              slug: categoriesFromBackend.slug,
              imgUrl: categoriesFromBackend.img_url

            } as any);

        },
        error: err => console.log(err)
      }
    );
  }

  save() {

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
    this.router.navigate(["/categories"]);
  }

}
