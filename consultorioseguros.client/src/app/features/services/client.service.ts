import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Client, ClientInput } from '../../shared/models/client.model';

@Injectable({
  providedIn: 'root',
})
export class ClientService {
  private apiUrl = 'Api/Client';

  constructor(private http: HttpClient) {}

  getClients(): Observable<Client[]> {
    return this.http.get<Client[]>(this.apiUrl);
  }

  getClient(id: number): Observable<Client> {
    return this.http.get<Client>(`${this.apiUrl}/${id}`);
  }

  getClientByIdNumber(idNumber: string): Observable<Client> {
    return this.http.get<Client>(`${this.apiUrl}/Document/${idNumber}`);
  }

  addClient(client: ClientInput): Observable<Client> {
    return this.http.post<Client>(this.apiUrl, client);
  }

  addClients(clients: ClientInput[]): Observable<number> {
    return this.http.post<number>(`${this.apiUrl}/Bulk`, clients);
  }

  updateClient(id: number, client: ClientInput): Observable<Client> {
    return this.http.put<Client>(`${this.apiUrl}/${id}`, client);
  }

  deleteClient(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}