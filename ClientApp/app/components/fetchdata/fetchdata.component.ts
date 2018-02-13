import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Route, Router, ActivatedRoute  } from '@angular/router';
import { EmployeeService } from '../../common/services/empservice.service';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    public forecasts: WeatherForecast[] =[];;
    public empList: EmployeeData[] = []; 

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string, private router : Router,
        private employeeService: EmployeeService) {
               this.getEmployees();         
        http.get(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
            this.forecasts = result.json() as WeatherForecast[];
        }, error => console.error(error));
    }

    getEmployees() {  
        this.employeeService.getEmployees().subscribe(  
            data => this.empList = data  
        )  
    }
    
    delete(employeeID) {  
        var ans = confirm("Do you want to delete customer with Id: " + employeeID);  
        if (ans) {  
            this.employeeService.deleteEmployee(employeeID).subscribe((data) => {  
                this.getEmployees();  
            }, error => console.error(error))   
        }  
    }  
}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}

interface EmployeeData {  
    id: number;  
    name: string;  
    gender: string;  
    department: string;  
    city: string;  
}
