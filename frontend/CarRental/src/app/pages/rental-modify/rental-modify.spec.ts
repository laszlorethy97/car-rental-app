import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RentalModify } from './rental-modify';

describe('InvoiceModify', () => {
  let component: RentalModify;
  let fixture: ComponentFixture<RentalModify>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RentalModify],
    }).compileComponents();

    fixture = TestBed.createComponent(RentalModify);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
