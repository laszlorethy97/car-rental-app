import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GeneralRentCar } from './general-rent-car';

describe('GeneralRentCar', () => {
  let component: GeneralRentCar;
  let fixture: ComponentFixture<GeneralRentCar>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GeneralRentCar],
    }).compileComponents();

    fixture = TestBed.createComponent(GeneralRentCar);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
