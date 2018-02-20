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
    public class EmployeeController : Controller  
    {  
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();  
  
        [HttpGet]  
        [Route("api/Employee/Index")]  
        public IEnumerable<EmployeeDetails> Index()  
        {  
            return objemployee.GetAllEmployees();  
        }  
  
        [HttpPost]  
        [Route("api/Employee/Create")]  
        public int Create([FromBody] EmployeeDetails employee)  
        {  
            return objemployee.AddEmployee(employee);  
        }  
  
        [HttpGet]  
        [Route("api/Employee/Details/{id}")]  
        public EmployeeDetails Details(int id)  
        {  
            return objemployee.GetEmployeeData(id);  
        }  
  
        [HttpPut]  
        [Route("api/Employee/Edit")]  
        public int Edit([FromBody]EmployeeDetails employee)  
        {  
            return objemployee.UpdateEmployee(employee);  
        }  
  
        [HttpDelete]  
        [Route("api/Employee/Delete/{id}")]  
        public int Delete(int id)  
        {  
            return objemployee.DeleteEmployee(id);  
        }  
    }
}