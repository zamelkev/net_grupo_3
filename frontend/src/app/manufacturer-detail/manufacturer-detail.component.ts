import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Manufacturer } from '../models/manufacturer.model';

@Component({
  selector: 'app-author-detail',
  templateUrl: './manufacturer-detail.component.html',
  styleUrls: ['./manufacturer-detail.component.css']
})
export class ManufacturerDetailComponent implements OnInit {
  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router

  ) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe({
      next: pmap => {
        // extrae el id de la URL
        let id = pmap.get("id");
      },
      error: err => console.log(err)
    });
  }





  private navigateToList() {
    this.router.navigate(["/manufacturers"]);
  }
}
