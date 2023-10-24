import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from '../cadastro/models/cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  private apiUrl = environment.apiUrl;
  
  constructor(private http: HttpClient) {}

  getCustomers(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(`${this.apiUrl}/customer`);
  }

  getCustomer(id: string): Observable<Cliente> {
    return this.http.get<Cliente>(`${this.apiUrl}/customer/${id}`);
  }
  
  postCustomer(data: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/customer`, data);
  }

  // HTTP PUT request
  putCustomer(data: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/customer`, data);
  }

  // HTTP DELETE request
  deleteCustomer(id: string): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/customer?id=` + id);
  }
  // You can create more methods for other API endpoints as needed
}
