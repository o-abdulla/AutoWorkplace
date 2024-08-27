import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Department } from '../models/department';

@Injectable({
  providedIn: 'root'
})
export class DepartmentsService {

  constructor(private http:HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  GetDepts():Observable<Department[]>{
    return this.http.get<Department[]>(`${this.baseUrl}department`);
  }

  GetByDeptId(id: number):Observable<Department>{
    return this.http.get<Department>(`${this.baseUrl}department/${id}`);
  }

  GetByDeptNumber(deptNum: number):Observable<Department>{
    return this.http.get<Department>(`${this.baseUrl}department/${deptNum}`);
  }

  AddDept(dept: Department):Observable<Department>{
    return this.http.post<Department>(`${this.baseUrl}department/`, dept);
  }

  UpdateDept(id: number, department: Department):Observable<Department>{
    return this.http.put<Department>(`${this.baseUrl}department/${id}`, department);
  }

  deleteDept(id:number):Observable<Department>{
    return this.http.delete<Department>(`${this.baseUrl}department/${id}`);
  }
}
