import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminCarModify } from './admin-car-modify';

describe('AdminCarModify', () => {
  let component: AdminCarModify;
  let fixture: ComponentFixture<AdminCarModify>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminCarModify],
    }).compileComponents();

    fixture = TestBed.createComponent(AdminCarModify);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
