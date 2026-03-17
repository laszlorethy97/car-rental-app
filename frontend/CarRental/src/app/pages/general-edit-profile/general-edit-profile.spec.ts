import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GeneralEditProfile } from './general-edit-profile';

describe('GeneralEditProfile', () => {
  let component: GeneralEditProfile;
  let fixture: ComponentFixture<GeneralEditProfile>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GeneralEditProfile],
    }).compileComponents();

    fixture = TestBed.createComponent(GeneralEditProfile);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
