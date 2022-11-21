import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Manufacturer } from '../models/manufacturer.model';
import { ManufacturerService } from '../services/manufacturer.service';

@Component({
  selector: 'app-manufacturer-form',
  templateUrl: './manufacturer-form.component.html',
  styleUrls: ['./manufacturer-form.component.css']
})
export class ManufacturerFormComponent implements OnInit {

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
      fullName: new FormControl(),
      foundationDate: new FormControl()
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
              foundationDate: manufacturerFromBackend.foundationDate             

            } as any);

        },
        error: err => console.log(err)
      }
    );
  }

  save() {

    let manufacturer = {
      name: this.editForm.get("fullName")?.value,
      foundationDate: this.editForm.get("foundationDate")?.value, 
    } as any;

    let id = this.editForm.get("id")?.value;

    console.log("id: " + id + " fullName: " + manufacturer.name + " foundationDate: " + manufacturer.foundationDate);
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
    this.router.navigate(["/manufacturers"]);
  }

}
