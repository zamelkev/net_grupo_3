import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';


import { ProductListComponent } from './product-list/product-list.component';
import { ProductByManufacturerListComponent } from './product-by-manufacturer-list/product-by-manufacturer-list.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductFormComponent } from './product-form/product-form.component';
import { ManufacturerDetailComponent } from './manufacturer-detail/manufacturer-detail.component';
import { ManufacturerListComponent } from './manufacturer-list/manufacturer-list.component';
import { ManufacturerFormComponent } from './manufacturer-form/manufacturer-form.component';


import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatMenuModule } from '@angular/material/menu';


@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    ProductByManufacturerListComponent,
    ProductDetailComponent,
    ManufacturerDetailComponent,
    ManufacturerListComponent,
    ManufacturerFormComponent,
    ProductFormComponent
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

    FontAwesomeModule,

    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'products', pathMatch: 'full' },

      { path: 'products', component: ProductListComponent },

      { path: 'products/manufacturer/:id', component: ProductByManufacturerListComponent },

      { path: 'products/:id/detail', component: ProductDetailComponent },
     
      { path: 'manufacturers', component: ManufacturerListComponent },
      { path: 'manufacturers/new', component: ManufacturerFormComponent },
      { path: 'manufacturers/:id/edit', component: ManufacturerFormComponent },
      { path: 'manufacturers/:id/detail', component: ManufacturerDetailComponent },
     
     

      { path: 'products/:id/edit', component: ProductFormComponent },
      { path: 'products/new', component: ProductFormComponent }, 

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
