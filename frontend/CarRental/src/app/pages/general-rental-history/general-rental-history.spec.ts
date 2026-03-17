import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GeneralRentalHistory } from './general-rental-history';

describe('GeneralRentalHistory', () => {
  let component: GeneralRentalHistory;
  let fixture: ComponentFixture<GeneralRentalHistory>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GeneralRentalHistory],
    }).compileComponents();

    fixture = TestBed.createComponent(GeneralRentalHistory);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
