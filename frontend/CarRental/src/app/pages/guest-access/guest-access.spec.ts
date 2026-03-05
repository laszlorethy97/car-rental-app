import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GuestAccess } from './guest-access';

describe('GuestAccess', () => {
  let component: GuestAccess;
  let fixture: ComponentFixture<GuestAccess>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GuestAccess],
    }).compileComponents();

    fixture = TestBed.createComponent(GuestAccess);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
