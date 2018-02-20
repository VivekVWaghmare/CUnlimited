using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
  
namespace CUnlimited.Model  
{  
    public class EmployeeDetails  
    {  
        public int ID { get; set; }  
        public string FirstName { get; set; }  
        public string LastName { get; set; }  
        public int GenderId { get; set; }  
        public string GenderName { get; set; }  
        public int DepartmentId { get; set; } 
        public string Department { get; set; }  
        public double PhoneNo { get; set; }
  
        public string City { get; set; }  
    }  
}