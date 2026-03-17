import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GeneralCarList } from './general-car-list';

describe('GeneralCarList', () => {
  let component: GeneralCarList;
  let fixture: ComponentFixture<GeneralCarList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GeneralCarList],
    }).compileComponents();

    fixture = TestBed.createComponent(GeneralCarList);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
