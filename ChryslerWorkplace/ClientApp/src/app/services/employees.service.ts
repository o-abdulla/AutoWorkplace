import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, } from '@angular/core';
import { Employee } from '../models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  constructor(private http:HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  GetEmployees(){
    return this.http.get<Employee[]>(`${this.baseUrl}employee`);
  }

}
