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
    public class DepartmentController : Controller  
    {  
         EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();  
  
        [HttpGet]  
        [Route("api/Department/Index")]  
        public IEnumerable<Department> Index()  
        {  
            return objemployee.GetAllDepartment();  
        } 
    }
}