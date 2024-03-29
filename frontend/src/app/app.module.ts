import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { distinctUntilChanged, tap } from 'rxjs/operators';
import { MAT_DATE_LOCALE, MatNativeDateModule } from "@angular/material/core";
import { CookieService } from 'ngx-cookie-service';
import { LOCALE_ID } from '@angular/core';
import localeEs from '@angular/common/locales/es';
import { registerLocaleData } from '@angular/common';
registerLocaleData(localeEs, 'es');

import { ProductListComponent } from './product-list/product-list.component';
import { ProductByManufacturerListComponent } from './product-by-manufacturer-list/product-by-manufacturer-list.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductFormComponent } from './product-form/product-form.component';
import { ProductByCategoryListComponent } from './product-by-category-list/product-by-category-list.component';
import { ManufacturerDetailComponent } from './manufacturer-detail/manufacturer-detail.component';
import { ManufacturerListComponent } from './manufacturer-list/manufacturer-list.component';
import { ManufacturerFormComponent } from './manufacturer-form/manufacturer-form.component';
import { HomeComponent } from './home/home.component';
import { CategoriesDetailComponent } from './categories-detail/categories-detail.component';
import { CategoriesListComponent } from './categories-list/categories-list.component';
import { CategoriesFormComponent } from './categories-form/categories-form.component';
import { BackOfficeComponent } from './back-office/back-office.component';
import { ProductListCrudComponent } from './product-list-crud/product-list-crud.component';
import { ProductDetailCrudComponent } from './product-detail-crud/product-detail-crud.component';
import { CheckoutComponent } from './checkout/checkout.component';


import { MatButtonModule } from '@angular/material/button';
//import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatMenuModule } from '@angular/material/menu';
import { MatDatepickerModule } from '@angular/material/datepicker'
import { LayoutModule } from '@angular/cdk/layout';
import { MatBadgeModule } from '@angular/material/badge';
import { MatExpansionModule } from '@angular/material/expansion'; 

/*import { MatPaginatorModule, MatPaginator } from '@angular/material/paginator';*/

import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { LoginComponent } from './account/login.component';
import { RegisterComponent } from './account/signup.component';
import { AuthGuardGuard } from './auth-guard.guard';
import { JwtInterceptor, ErrorInterceptor } from './_helpers';
import { AccountService } from './services/account.service';
import { environment } from '../environments/environment';
import { ShoppingStatusComponent } from './shopping-status/shopping-status.component';
import { OrdersListComponent } from './orders-list/orders-list.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    ProductByManufacturerListComponent,
    ProductByCategoryListComponent,
    ProductDetailComponent,
    ManufacturerDetailComponent,
    ManufacturerListComponent,
    ManufacturerFormComponent,
    ProductDetailComponent,
    ProductFormComponent,
    HomeComponent,
    CategoriesDetailComponent,
    CategoriesFormComponent,
    CategoriesListComponent,
    CheckoutComponent,

    BackOfficeComponent,
    ProductListCrudComponent,
    ProductDetailCrudComponent,
    LoginComponent,
    RegisterComponent,

    ShoppingStatusComponent,
    OrdersListComponent

  ],
  imports: [
    MatButtonModule,
    MatTableModule,
    MatIconModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatDividerModule,
    MatSelectModule,
    MatButtonToggleModule,
    MatListModule,
    MatToolbarModule,
    MatSidenavModule,
    MatMenuModule,
    MatExpansionModule,
    //MatTableDataSource,
    /*MatPaginatorModule,
    MatPaginator,*/
    LayoutModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatBadgeModule,

    MDBBootstrapModule,

    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path: 'home', component: HomeComponent },
      { path: 'login', component: LoginComponent },
      { path: 'signup', component: RegisterComponent },

      { path: 'products', component: ProductListComponent },
      // products filtered by manufacturer/category
      { path: 'products/manufacturer/:slug', component: ProductByManufacturerListComponent },
      { path: 'products/category/:slug', component: ProductByCategoryListComponent },

      { path: 'products/:slug/detail', component: ProductDetailComponent },
      // shopping routes
      { path: 'checkout', component: CheckoutComponent },
      { path: 'shopping_report', component: ShoppingStatusComponent },
      { path: 'orders_list', component: OrdersListComponent },

      { path: 'back_office/products/:id/edit', component: ProductFormComponent, canActivate: [AuthGuardGuard] },
      { path: 'back_office/products/new', component: ProductFormComponent, canActivate: [AuthGuardGuard] },

      //{ path: 'categories', component: CategoriesListComponent },



      // back-office routes
      { path: 'back_office', component: BackOfficeComponent, canActivate: [AuthGuardGuard] },
      { path: 'back_office/products', component: ProductListCrudComponent, canActivate: [AuthGuardGuard] },
      { path: 'back_office/products/:id/detail', component: ProductDetailCrudComponent, canActivate: [AuthGuardGuard] },

      { path: 'back_office/categories', component: CategoriesListComponent, canActivate: [AuthGuardGuard] },
      { path: 'back_office/categories/new', component: CategoriesFormComponent, canActivate: [AuthGuardGuard] },
      { path: 'back_office/categories/:id/edit', component: CategoriesFormComponent, canActivate: [AuthGuardGuard] },
      { path: 'back_office/categories/:id/detail', component: CategoriesDetailComponent, canActivate: [AuthGuardGuard] },

      { path: 'back_office/manufacturers', component: ManufacturerListComponent, canActivate: [AuthGuardGuard] },
      { path: 'back_office/manufacturers/new', component: ManufacturerFormComponent, canActivate: [AuthGuardGuard] },
      { path: 'back_office/manufacturers/:id/edit', component: ManufacturerFormComponent, canActivate: [AuthGuardGuard] },
      { path: 'back_office/manufacturers/:id/detail', component: ManufacturerDetailComponent, canActivate: [AuthGuardGuard] },

    ])
  ],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'es-ES' },
    { provide: LOCALE_ID, useValue: 'es' },
    { provide: CookieService },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    
   
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
