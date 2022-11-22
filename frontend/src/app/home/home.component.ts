import { Component, OnInit } from '@angular/core';
import { Manufacturer } from '../models/manufacturer.model';
import { ManufacturerService } from '../services/manufacturer.service';

import { Category } from '../models/category.model';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  manufacturers: Manufacturer[] = []
  categories: Category[] = [];


  constructor(
    private manufacturerService: ManufacturerService,
    private categoryService: CategoryService
  ) { }

  ngOnInit(): void {
    this.fetchFromDb();
  }

  private fetchFromDb() {
    this.manufacturerService.findAll().subscribe(
      {
        next: manufacturers => this.manufacturers = manufacturers,
        error: err => console.log(err)
      }
    )
    this.categoryService.findAll().subscribe(
      {
        next: categories => this.categories = categories,
        error: err => console.log(err)
      }
    )
  }

}
