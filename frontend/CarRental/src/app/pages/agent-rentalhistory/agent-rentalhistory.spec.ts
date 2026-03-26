import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgentRentalhistory } from './agent-rentalhistory';

describe('AgentRentalhistory', () => {
  let component: AgentRentalhistory;
  let fixture: ComponentFixture<AgentRentalhistory>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AgentRentalhistory],
    }).compileComponents();

    fixture = TestBed.createComponent(AgentRentalhistory);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
