import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientComponent } from './features/client/client.component';
import { InsurancePlanComponent } from './features/insurance-plan/insurance-plan.component';

const routes: Routes = [
  { path: ClientComponent.path, component: ClientComponent },
  { path: InsurancePlanComponent.path, component: InsurancePlanComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
