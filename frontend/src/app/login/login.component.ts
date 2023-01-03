import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { AccountService } from '../services/account.service';
import { CookieService } from 'ngx-cookie-service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  loginForm!: FormGroup;

  loading = false;

  submitted = false;

  error = '';



  constructor(

    private formBuilder: FormBuilder,

    private route: ActivatedRoute,

    private router: Router,

    private authService: AccountService

  ) {

    // redirect to home if already logged in

    if (this.authService.userValue) {

      this.router.navigate(['/']);

    }

  }



  ngOnInit() {

    this.loginForm = this.formBuilder.group({

      username: ['', Validators.required],

      password: ['', Validators.required]

    });

  }



  // convenience getter for easy access to form fields

  get f() { return this.loginForm.controls; }



  onSubmit() {

    this.submitted = true;



    // stop here if form is invalid

    if (this.loginForm.invalid) {

      return;

    }



    this.loading = true;

    this.authService.login(this.f.username.value, this.f.password.value)

      .pipe(first())

      .subscribe({

        next: () => {

          // get return url from route parameters or default to '/'

          const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';

          this.router.navigate([returnUrl]);

        },

        error: error => {

          this.error = error;

          this.loading = false;

        }

      });

  }
}
