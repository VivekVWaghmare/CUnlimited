import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { EmployeeService } from './common/services/empservice.service';


import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { AddEmployeeComponent} from './components/Employee/addEmployee.component'
import { EmpTodayAttendanceComponent } from './components/employeeAttendance/employeeAttendance.component';
import { GodownComponent } from './components/godown/godown.component';
import { StockService } from './common/services/stock.service';
import { SalaryComponent } from './components/salary/salary.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        GodownComponent,
        AddEmployeeComponent,
        EmpTodayAttendanceComponent,
        SalaryComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            {path: 'add-employee', component: AddEmployeeComponent},
            {path: 'employee-attendance', component: EmpTodayAttendanceComponent},
            {path: 'godown', component: GodownComponent},
            {path: 'salary', component: SalaryComponent},
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [EmployeeService, StockService]
})
export class AppModuleShared {
}
