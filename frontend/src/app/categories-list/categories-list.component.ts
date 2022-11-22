import { Component, OnInit } from '@angular/core';
import { Categories } from '../models/categories.model';
import { CategoriesService } from '../services/categories.service';

@Component({
  selector: 'app-categories-list',
  templateUrl: './categories-list.component.html',
  styleUrls: ['./categories-list.component.css']
})
export class CategoriesListComponent implements OnInit {

  categories: Categories[] = [];

  columnNames: string[] = ['id', 'name', 'slug', 'imgUrl'];

  constructor(private service: CategoriesService) { }

  ngOnInit(): void {
    this.findAll();
  }

  private findAll() {
    this.service.findAll().subscribe(
      {
        next: categories => this.categories = categories,
        error: err => console.log(err)
      }
    );
  }

}
