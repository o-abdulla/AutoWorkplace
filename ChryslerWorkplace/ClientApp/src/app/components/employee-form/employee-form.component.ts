import { Component } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { DepartmentsService } from 'src/app/services/departments.service';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent {

  employeeList: Employee[] = [];
  person: Employee = {} as Employee;

  constructor(private _departmentService: DepartmentsService,
    private _employeeService: EmployeesService,
  ) { }


  ngOnInit():void {

  }

  showEmployees():Employee[]{
    this._employeeService.GetEmployees().subscribe((response:Employee[]) => {
      console.log(response)
      this.employeeList = response;
    });
    return this.employeeList;
  }
}
