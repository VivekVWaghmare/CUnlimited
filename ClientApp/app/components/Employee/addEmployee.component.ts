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
    title: string = "Create";
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
            id:0,
            firstName: ['', [Validators.required]],
            lastName: ['', [Validators.required]],
            genderId: ['', [Validators.required]],
            genderName: ['', [Validators.required]],
            departmentId: ['', [Validators.required]],
            department: ['', [Validators.required]],
            phoneNo: [ , [Validators.required]],
            city:'',
        })
    }
    ngOnInit() {  
        if (this.id > 0) {  
            console.log(this.id);
            this.title = "Edit";  
            this.employeeService.getEmployeeById(this.id)  
                .subscribe(resp => {this.employeeForm.setValue(resp), console.log(resp)  }
                , error => this.errorMessage = error);  
        }  
    } 

    save() {  
  
        if (!this.employeeForm.valid) {  
            return;  
        }  
  
        if (this.title == "Create") {  
            this._employeeService.saveEmployee(this.employeeForm.value)  
                .subscribe((data) => {  
                    this._router.navigate(['/fetch-data']);  
                }, error => this.errorMessage = error)  
        }  
        else if (this.title == "Edit") {
            console.log(this.employeeForm.value);  
            this._employeeService.updateEmployee(this.employeeForm.value)  
                .subscribe((data) => {  
                    this._router.navigate(['/fetch-data']);  
                }, error => this.errorMessage = error)   
        }  
    } 

    cancel(){
        this._router.navigate(['/fetch-data']);  
    }

    get firstName() { return this.employeeForm.get('firstName'); } 
    get lastName() { return this.employeeForm.get('lastName'); }  
    get genderName() { return this.employeeForm.get('genderName'); }  
    get department() { return this.employeeForm.get('department'); }  
    //get city() { return this.employeeForm.get('city'); } 
}
