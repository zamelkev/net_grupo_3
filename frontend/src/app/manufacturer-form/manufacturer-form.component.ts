import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Manufacturer } from '../models/manufacturer.model';
import { ManufacturerService } from '../services/manufacturer.service';

@Component({
  selector: 'app-manufacturer-form',
  templateUrl: './manufacturer-form.component.html',
  styleUrls: ['./manufacturer-form.component.css']
})
export class ManufacturerFormComponent implements OnInit {

  id: number | string | undefined;
  editForm = this.createFormGroup(); // formulario
  error: boolean = false;

  constructor(
    private manufacturerService: ManufacturerService,
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
        validators: [Validators.required, Validators.minLength(2), Validators.maxLength(100), Validators.pattern('(^[a-z]+)(?![A-Z])([a-z_0-9]*$)')]
      }),
      imgUrl: new FormControl('', {
        nonNullable: true,
        validators: [Validators.required]
      }),
      foundationDate: new FormControl('', {
        nonNullable: true,
        validators: [Validators.required]
      })
    })
  }

  ngOnInit(): void {

    this.activatedRoute.paramMap.subscribe({
      next: pmap => {
        let id = pmap.get("id");
        if (id) {
          this.getManufacturerAndLoadInForm(id);
        }
      }
    });

  }

  private getManufacturerAndLoadInForm(id: string) {
    this.manufacturerService.findById(Number(id)).subscribe(
      {
        next: manufacturerFromBackend => {

          this.editForm.reset(
            {
              id: { value: manufacturerFromBackend.id, disabled: true},
              fullName: manufacturerFromBackend.name,
              slug: manufacturerFromBackend.slug,
              imgUrl: manufacturerFromBackend.imgUrl,
              foundationDate: manufacturerFromBackend?.foundationDate?.substring(0, 10)             

            } as any);
          this.id = manufacturerFromBackend.id;
        },
        error: err => console.log(err)
      }
    );
  }

  save() {
    if (!this.editForm.valid) return
    let manufacturer = {
      name: this.editForm.get("fullName")?.value,
      slug: this.editForm.get("slug")?.value,
      imgUrl: this.editForm.get("imgUrl")?.value, 
      foundationDate: this.editForm.get("foundationDate")?.value, 
    } as any;

    let id = this.editForm.get("id")?.value;

    console.log(manufacturer);
    if (id) { // actualización
      manufacturer.id = id;
      this.manufacturerService.update(manufacturer).subscribe({
        next: response => this.navigateToList(),
        error: err => this.showError(err)
      });

    } else { // creación
      this.manufacturerService.create(manufacturer).subscribe({
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
    this.router.navigate(["/back_office/manufacturers"]);
  }
  onDelete() {
    this.manufacturerService.deleteById(Number(this.id)).subscribe(
      {
        next: response => this.navigateToList(),
        error: err => console.log(err)
      }
    );
  }
}
