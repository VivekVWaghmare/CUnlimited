import { Component } from '@angular/core';
import { Injectable, Inject } from '@angular/core';
import { Http, Response} from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class EmployeeService{
    myAppUrl : string = "";

    constructor (private http : Http, @Inject('BASE_URL') base_url : string){
        
        this.myAppUrl = base_url;
    }

    getEmployees() {
        return this.http.get(this.myAppUrl + 'api/Employee/Index')
        .map(( response : Response) => response.json())
        .catch(this.errorHandler)
    }

    getEmployeeById(id: number) {  
        return this.http.get(this.myAppUrl + "api/Employee/Details/" + id)  
            .map((response: Response) => response.json())  
            .catch(this.errorHandler)  
    } 

    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    }  

}