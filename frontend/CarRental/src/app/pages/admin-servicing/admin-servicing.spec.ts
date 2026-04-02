import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminServicing } from './admin-servicing';

describe('AdminServicing', () => {
  let component: AdminServicing;
  let fixture: ComponentFixture<AdminServicing>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminServicing],
    }).compileComponents();

    fixture = TestBed.createComponent(AdminServicing);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
