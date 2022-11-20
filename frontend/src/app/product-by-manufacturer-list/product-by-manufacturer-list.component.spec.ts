import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductByManufacturerListComponent } from './product-by-manufacturer-list.component';

describe('ProductByManufacturerListComponent', () => {
  let component: ProductByManufacturerListComponent;
  let fixture: ComponentFixture<ProductByManufacturerListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductByManufacturerListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductByManufacturerListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
