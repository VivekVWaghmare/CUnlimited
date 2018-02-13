import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl} from '@angular/forms';
import { EmployeeService } from '../../common/services/empservice.service'; 
import {  Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'addEmployee',
    templateUrl: './addEmployee.component.html',
    styleUrls: ['./addEmployee.component.css']
})

export class AddEmployeeComponent implements OnInit {
    employeeForm: FormGroup;
    title: string = "Add";
    id: number =0;
    errorMessage: any;
    employeeService: EmployeeService;
    
    constructor(private _fb:FormBuilder, private _avRoute:ActivatedRoute,
        private _employeeService: EmployeeService, private _router: Router)
    {
        this.employeeService = _employeeService;
        
        if(this._avRoute.snapshot.params["id"]){
            this.id =this._avRoute.snapshot.params["id"];
        }

        this.employeeForm = this._fb.group({
            id: 0,
            name: ['', [Validators.required]],
            gender: ['', [Validators.required]],
            department: ['', [Validators.required]],
            city: ['', [Validators.required]]
        })
    }
    ngOnInit() {  
        if (this.id > 0) {  
            this.title = "Edit";  
            this.employeeService.getEmployeeById(this.id)  
                .subscribe(resp => this.employeeForm.setValue(resp)  
                , error => this.errorMessage = error);  
        }  
    } 

    cancel(){

    }

    get name() { return this.employeeForm.get('name'); }  
    get gender() { return this.employeeForm.get('gender'); }  
    get department() { return this.employeeForm.get('department'); }  
    get city() { return this.employeeForm.get('city'); } 
}
