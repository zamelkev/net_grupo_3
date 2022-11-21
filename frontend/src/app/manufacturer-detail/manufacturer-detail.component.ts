import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Manufacturer } from '../models/manufacturer.model';
import { ManufacturerService } from '../services/manufacturer.service';

@Component({
  selector: 'app-author-detail',
  templateUrl: './manufacturer-detail.component.html',
  styleUrls: ['./manufacturer-detail.component.css']
})
export class ManufacturerDetailComponent implements OnInit {

  manufacturer: Manufacturer | undefined;

  constructor(
    private manufacturerService: ManufacturerService,
    private router: Router,
    private activatedRoute: ActivatedRoute

  ) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe({
      next: pmap => {
        // extrae el id de la URL
        let id = pmap.get("id");
        // cargar manufacturer si lo hay
        if (id)
          this.fetchManufacturer(id)
      },
      error: err => console.log(err)
    });
  }
    fetchManufacturer(id: string | number | null) {
      this.manufacturerService.findById(Number(id)).subscribe(
        {
          next: manufacturerFromBackend => this.manufacturer = manufacturerFromBackend,
          error: err => console.log(err)
        }
      )
    }
  onDelete(id: string | number | undefined) {
    console.log(id);
    this.manufacturerService.deleteById(Number(id)).subscribe(
      {
        next: response => this.navigateToList(), 
        error: err => console.log(err)
      }
    );
  }




  private navigateToList() {
    this.router.navigate(["/manufacturers"])
  }
}
