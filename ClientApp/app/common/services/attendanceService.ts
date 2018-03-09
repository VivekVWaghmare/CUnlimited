import { Component } from '@angular/core';
import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch'
import 'rxjs/add/observable/throw';

@Injectable()
export class AttendanceService {

    myAppUrl : string = "";

    constructor (private http : Http, @Inject('BASE_URL') base_url : string){
        this.myAppUrl = base_url;
        
    }

    upadateAttendance(empIitem)
    {
        console.log(this.myAppUrl + 'api/Attendance/Edit');
        console.log("servive");
        console.log(empIitem);
        return this.http.put(this.myAppUrl + 'api/Attendance/Edit', empIitem)  
            .map((response: Response) => response.json())  
            .catch(this.errorHandler);  
    }

    errorHandler(error : Response){
        console.log(error);
        return Observable.throw(error);
    }
}