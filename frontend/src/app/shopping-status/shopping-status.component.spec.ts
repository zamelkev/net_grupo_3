import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingStatusComponent } from './shopping-status.component';

describe('ShoppingStatusComponent', () => {
  let component: ShoppingStatusComponent;
  let fixture: ComponentFixture<ShoppingStatusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShoppingStatusComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoppingStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
