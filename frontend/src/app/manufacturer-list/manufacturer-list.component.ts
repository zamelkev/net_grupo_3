import { Component, OnInit } from '@angular/core';
import { Manufacturer } from '../models/manufacturer.model';
import { ManufacturerService } from '../services/manufacturer.service';

@Component({
  selector: 'app-manufacturer-list',
  templateUrl: './manufacturer-list.component.html',
  styleUrls: ['./manufacturer-list.component.css']
})
export class ManufacturerListComponent implements OnInit {

  manufacturers: Manufacturer[] = [];

  columnNames: string[] = ['id', 'name', 'foundationDate'];

  constructor(private service: ManufacturerService) { }

  ngOnInit(): void {
    this.findAll();
  }

  private findAll() {
    this.service.findAll().subscribe(
      {
        next: manufacturers => this.manufacturers = manufacturers,
        error: err => console.log(err)
      }
    );
  }

}
