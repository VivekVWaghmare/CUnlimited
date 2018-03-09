using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using System.Data.SqlClient;  
using System.Data;  
using CUnlimited.Model; 

namespace CUnlimited.Controllers
{
    public class AttendanceController : Controller  
    {  
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();  
  
        [HttpGet]  
        [Route("api/Attendance/Index")]  
        public IEnumerable<EmployeeDetails> Index()  
        {  
            return objemployee.GetAllEmployees();  
        }  
  
  
        [HttpGet]  
        [Route("api/Attendance/Details/{id}")]  
        public EmployeeDetails Details(int id)  
        {  
            return objemployee.GetEmployeeData(id);  
        }  
  
        [HttpPut]  
        [Route("api/Attendance/Edit")]  
        public int Edit([FromBody]EmployeeDetails employee)  
        {  
            return objemployee.UpdateEmployee(employee);  
        }  
    }
}
