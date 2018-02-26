import { Component } from '@angular/core';
import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch'
import 'rxjs/add/observable/throw';

@Injectable()
export class DepartmentService{
    myAppUrl : string = "";

    constructor (private http : Http, @Inject('BASE_URL') base_url : string){
        this.myAppUrl = base_url;
    }

    getDepartment() {
        return this.http.get(this.myAppUrl + 'api/Department/Index')
        .map(( response : Response) => response.json())
        .catch(this.errorHandler)
    }

    errorHandler(error: Response) {  
        console.log(error);  
        return Observable.throw(error);  
    }
}