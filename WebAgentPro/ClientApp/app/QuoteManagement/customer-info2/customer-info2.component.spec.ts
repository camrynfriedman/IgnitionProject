import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerInfo2Component } from './customer-info2.component';

describe('CustomerInfo2Component', () => {
  let component: CustomerInfo2Component;
  let fixture: ComponentFixture<CustomerInfo2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerInfo2Component ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerInfo2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
