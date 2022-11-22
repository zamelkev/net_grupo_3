import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Categories } from '../models/categories.model';
import { CategoriesService } from '../services/categories.service';

@Component({
  selector: 'app-categories-detail',
  templateUrl: './categories-detail.component.html',
  styleUrls: ['./categories-detail.component.css']
})
export class CategoriesDetailComponent implements OnInit {

  categories: Categories | undefined;

  constructor(
    private categoriesService: CategoriesService,
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
          this.fetchCategories(id)
      },
      error: err => console.log(err)
    });
  }
  fetchCategories(id: string | number | null) {
      this.categoriesService.findById(Number(id)).subscribe(
        {
          next: categoriesFromBackend => this.categories = categoriesFromBackend,
          error: err => console.log(err)
        }
      )
    }
  onDelete(id: string | number | undefined) {
    console.log(id);
    this.categoriesService.deleteById(Number(id)).subscribe(
      {
        next: response => this.navigateToList(), 
        error: err => console.log(err)
      }
    );
  }




  private navigateToList() {
    this.router.navigate(["/categories"])
  }
}
