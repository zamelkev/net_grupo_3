import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-shopping-status',
  templateUrl: './shopping-status.component.html',
  styleUrls: ['./shopping-status.component.css']
})
export class ShoppingStatusComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }
  backToHome(): void {
    this.router.navigate(["/"]);
  }
  viewOrders(): void {
    this.router.navigate(["orders_list"]);
  }

}
