import { Component, OnInit } from '@angular/core';
import { InsurancePlan } from '../../shared/models/insurance-plan.model';
import { InsurancePlanService } from '../services/insurance-plan.service';

@Component({
  selector: 'app-insurance-plan',
  templateUrl: './insurance-plan.component.html',
  styleUrl: './insurance-plan.component.css'
})
export class InsurancePlanComponent implements OnInit {

  public static path: string = 'plans';

  public plans: InsurancePlan[] = [];
  public model: InsurancePlan = {
    code: 0,
    name: '',
    amount: 0,
    premium: 0
  };

  constructor(private service: InsurancePlanService) {}

  ngOnInit(): void {
    this.getAllPlans();
  }

  getAllPlans() {
    this.service
    .getPlans()
    .subscribe(
      {
        next: (plans: InsurancePlan[]) => {
          this.plans = plans;
        },
        error: (err) => {
          console.error(err);
        }
      }
    );
  }

  onSubmit() {
    this.service
      .addPlan(this.model)
      .subscribe({
        next: () => this.getAllPlans(),
        error: (err) => {
          alert("Ocurrió un error al tratar de crear el plan");
          console.error(err);
        }
      });
  }
}
