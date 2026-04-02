import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminModifyRental } from './admin-modify-rental';

describe('AdminModifyRental', () => {
  let component: AdminModifyRental;
  let fixture: ComponentFixture<AdminModifyRental>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminModifyRental],
    }).compileComponents();

    fixture = TestBed.createComponent(AdminModifyRental);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
