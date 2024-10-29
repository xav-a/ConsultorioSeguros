import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsurancePlanComponent } from './insurance-plan.component';

describe('InsurancePlanComponent', () => {
  let component: InsurancePlanComponent;
  let fixture: ComponentFixture<InsurancePlanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [InsurancePlanComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InsurancePlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
