import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { CookieService } from 'ngx-cookie-service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  //private tokenKey = 'token';

  loginForm: FormGroup;

  //loginForm = new FormGroup({
  //  username: new FormControl(''),
  //  password: new FormControl(''),
  //});

  constructor(
    public fb: FormBuilder,
    public authService: AuthService,
    public router: Router
  ) {
    this.loginForm = this.fb.group({
      email: [''],
      password: [''],
    });
  }

  //submit() {
  //  if (this.form.valid) {
  //    this.submitEM.emit(this.form.value);
  //  }
  //}
  
  //@Output() submitEM = new EventEmitter();
  
  //constructor(private accountService: AccountService, private cookieService: CookieService, private router: Router) { }



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

  ngOnInit(): void {
  }

  loginUser() {
    this.authService.signIn(this.loginForm.value);
  }

  //public isLoggedIn(): boolean {
  //  let token = localStorage.getItem(this.tokenKey);
  //  return token != null && token.length > 0;
  //}

  //public getToken(): string | null {
  //  return this.isLoggedIn() ? localStorage.getItem(this.tokenKey) : null;
  //}

  //editForm = this.createFormGroup(); // formulario

  //constructor(private accountService: AccountService, private cookieService: CookieService, private router: Router) { }

  //ngOnInit(): void {
  //}

  //createFormGroup() {
  //  return new FormGroup({

  //    email: new FormControl('', {
  //      nonNullable: true,
  //      validators: [Validators.required, Validators.email]
  //    }),

  //    password: new FormControl('', {
  //      nonNullable: true,
  //      validators: [Validators.min(8), Validators.max(30)]
  //    }),

  //  });
  //}
  //onEnter() {

  //  this.cookieService.set('token_access', "User", 4, '/');
  //  console.log("entrar cookie: " + this.cookieService.get('token_access'));
  //  this.router.navigate(['/home']);
  //}
  //onExit() {

  //  this.cookieService.set('token_access', "NoUser", 4, '/');
  //  console.log("salir cookie: " + this.cookieService.get('token_access'));
  //  this.router.navigate(['/home']);
  //}
  //save() {
  //  let login = {
  //    email: this.editForm.get("email")?.value,
  //    password: this.editForm.get("password")?.value
  //  } as any;


  //  this.accountService.login(login).subscribe({
  //    next: response => console.log(response),
  //    error: err => console.log(err)
  //  });

  //}
}
