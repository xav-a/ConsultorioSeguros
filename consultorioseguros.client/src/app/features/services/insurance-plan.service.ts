import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { InsurancePlan } from '../../shared/models/insurance-plan.model';

@Injectable({
  providedIn: 'root',
})
export class InsurancePlanService {
  private apiUrl = 'Api/InsurancePlan';

  constructor(private http: HttpClient) {}

  getPlans(): Observable<InsurancePlan[]> {
    return this.http.get<InsurancePlan[]>(this.apiUrl);
  }

  getPlan(id: number): Observable<InsurancePlan> {
    return this.http.get<InsurancePlan>(`${this.apiUrl}/${id}`);
  }

  addPlan(plan: InsurancePlan): Observable<InsurancePlan> {
    return this.http.post<InsurancePlan>(this.apiUrl, plan);
  }

  updatePlan(id: number, plan: InsurancePlan): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, plan);
  }

  deletePlan(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}