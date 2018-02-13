import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../../common/services/empservice.service';


@Component({
    selector: 'today-attendamce',
    templateUrl: './employeeAttendance.component.html',
    styleUrls: ['./employeeAttendance.component.css'],
})

export class EmpTodayAttendanceComponent implements OnInit{
    ngOnInit(): void {
        this.employeeService.getEmployees().subscribe(
            data => this.empData= data
        ) 
    }
    public empData: EmployeeData[] = [];

    constructor(private http: Http, private router: Router, private employeeService: EmployeeService){
        
    }


}

interface EmployeeData {  
    id: number;  
    name: string;  
    gender: string;  
    department: string;  
    city: string;  
}