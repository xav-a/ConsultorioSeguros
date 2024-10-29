import { Component, OnInit } from '@angular/core';
import { ClientComponent } from './features/client/client.component';
import { InsurancePlanComponent } from './features/insurance-plan/insurance-plan.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  clientPath: string = ClientComponent.path;
  insurancePlanPath: string = InsurancePlanComponent.path;
  
  constructor() {}

  ngOnInit() {
    console.log("App Start");
  }

  title = 'consultorioseguros.client';
}
