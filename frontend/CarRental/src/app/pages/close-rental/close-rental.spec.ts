import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CloseRental } from './close-rental';

describe('CloseRental', () => {
  let component: CloseRental;
  let fixture: ComponentFixture<CloseRental>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CloseRental],
    }).compileComponents();

    fixture = TestBed.createComponent(CloseRental);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
