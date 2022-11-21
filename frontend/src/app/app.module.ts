import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductByManufacturerListComponent } from './product-by-manufacturer-list/product-by-manufacturer-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';


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
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ManufacturerDetailComponent } from './manufacturer-detail/manufacturer-detail.component';
import { ManufacturerListComponent } from './manufacturer-list/manufacturer-list.component';
import { ManufacturerFormComponent } from './manufacturer-form/manufacturer-form.component';



@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    ProductByManufacturerListComponent,
    ProductDetailComponent,
    ManufacturerDetailComponent,
    ManufacturerListComponent,
    ManufacturerFormComponent
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
     
     
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
