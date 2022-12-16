import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../services/account.service';
import { CookieService } from 'ngx-cookie-service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})


export class LoginComponent implements OnInit {

  editForm = this.createFormGroup(); // formulario

  constructor(private accountService: AccountService, private cookieService: CookieService, private router: Router) { }

  ngOnInit(): void {
  }

  createFormGroup() {
    return new FormGroup({

      email: new FormControl('', {
        nonNullable: true,
        validators: [Validators.required, Validators.email]
      }),

      password: new FormControl('', {
        nonNullable: true,
        validators: [Validators.min(8), Validators.max(30)]
      }),

    });
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
  save() {
    let login = {
      email: this.editForm.get("email")?.value,
      password: this.editForm.get("password")?.value
    } as any;


    this.accountService.login(login).subscribe({
      next: response => console.log(response),
      error: err => console.log(err)
    });

  }
}
