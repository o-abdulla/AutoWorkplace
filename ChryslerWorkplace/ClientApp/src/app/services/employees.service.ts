import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, } from '@angular/core';
import { Employee } from '../models/employee';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  constructor(private http:HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  GetEmployees():Observable<Employee[]>{
    return this.http.get<Employee[]>(`${this.baseUrl}employee`);
  }

  GetById(id: number):Observable<Employee>{
    return this.http.get<Employee>(`${this.baseUrl}employee/${id}`);
  }

  NewEmployee(employee: Employee):Observable<Employee>{
    return this.http.post<Employee>(`${this.baseUrl}employee`, employee);
  }

  UpdateEmployee(id: number, employee: Employee):Observable<Employee>{
    return this.http.put<Employee>(`${this.baseUrl}employee/${id}`, employee);
  }

  deleteEmpById(id:number):Observable<Employee>{
    return this.http.delete<Employee>(`${this.baseUrl}employee/${id}`);
  }
}
