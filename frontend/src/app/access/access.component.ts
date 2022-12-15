import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-access',
  templateUrl: './access.component.html',
  styleUrls: ['./access.component.css']
})
export class AccessComponent implements OnInit {
  //private cookieValue: string;
  constructor(private cookieService: CookieService, private router: Router) { }

  

  ngOnInit(): void {
  }
  onEnter() {
    
    this.cookieService.set('token_access', "User", 4, '/');
    console.log("entrar cookie: " + this.cookieService.get('token_access'));
    this.router.navigate(['/home']);
  }
  onExit() {
    
    this.cookieService.set('token_access', "NoUser", 4, '/');
    console.log("salir cookie: " + this.cookieService.get('token_access'));
    this.router.navigate(['/home']);
  }
}
