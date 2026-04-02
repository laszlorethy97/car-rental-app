import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminAddNewCar } from './admin-add-new-car';

describe('AdminAddNewCar', () => {
  let component: AdminAddNewCar;
  let fixture: ComponentFixture<AdminAddNewCar>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminAddNewCar],
    }).compileComponents();

    fixture = TestBed.createComponent(AdminAddNewCar);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
