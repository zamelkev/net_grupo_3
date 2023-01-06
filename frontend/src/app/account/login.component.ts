import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { CookieService } from 'ngx-cookie-service';

import { AccountService } from '../services/account.service';
import { AlertService } from '../services/alert.service';

@Component({ templateUrl: 'login.component.html' })
export class LoginComponent implements OnInit {
  form!: FormGroup;
  loading = false;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService,
    private alertService: AlertService,
    private cookieService: CookieService
  ) { }

  ngOnInit() {
    this.form = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  // convenience getter for easy access to form fields
  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;

    // reset alerts on submit
    this.alertService.clear();

    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }

    this.loading = true;
    this.accountService.login(this.f['email'].value, this.f['password'].value)
      .pipe(first())
      .subscribe({
        next: userFromDB => {
          // get return url from query parameters or default to home page
          //
          //const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
          //this.router.navigateByUrl(returnUrl);
          this.cookieService.set('token_access', "User", 4, '/');
          console.log("entrar cookie: " + this.cookieService.get('token_access'));
          this.cookieService.set('token_user', userFromDB!.username + '', 4, '/');
          //this.router.navigate(['/']);
          console.log(userFromDB)
        },
        error: error => {
          this.alertService.error(error);
          this.loading = false;
        }
      });
  }
}
