import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminRentalHistory } from './admin-rental-history';

describe('AdminRentalHistory', () => {
  let component: AdminRentalHistory;
  let fixture: ComponentFixture<AdminRentalHistory>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminRentalHistory],
    }).compileComponents();

    fixture = TestBed.createComponent(AdminRentalHistory);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
