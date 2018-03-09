import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../../common/services/empservice.service';
import { AttendanceService } from '../../common/services/attendanceService';


@Component({
    selector: 'today-attendamce',
    templateUrl: './employeeAttendance.component.html',
    styleUrls: ['./employeeAttendance.component.css'],
})

export class EmpTodayAttendanceComponent implements OnInit{
public date: Date = new Date();
p: number = 1;

    ngOnInit(): void {
        this.employeeService.getEmployees().subscribe(
            data => this.empData= data
        ) 
    }
    public empData: EmployeeData[] = [];

    constructor(private http: Http, private router: Router, private employeeService: EmployeeService,
           private attendanceService : AttendanceService ){
        
    }

    changeCheckboxEvent(empItem){
        console.log(empItem);
        if(empItem.extraWorkHr==undefined){
            empItem.extraWorkHr =0;
        }
        this.attendanceService.upadateAttendance(empItem);
        this.empData.splice(this.empData.indexOf(empItem), 1, empItem);
        //}
    }


}

interface EmployeeData {  
    id: number;  
    firstName: string;
    lastName: string;  
    gender: string;  
    department: string; 
    date: Date;
    present: boolean; 
    extraWorkHr: number;
}