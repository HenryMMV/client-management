import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Client } from '../models/client.model';

@Injectable({ providedIn: 'root' })
export class ClientsService {
  private readonly baseUrl = 'https://localhost:44360/clientes';

  constructor(private http: HttpClient) {}

  getClients(): Observable<Client[]> {
    return this.http.get<Client[]>(this.baseUrl);
  }

  getClientByRuc(ruc: string): Observable<Client> {
    return this.http.get<Client>(`${this.baseUrl}/${ruc}`);
  }
}
