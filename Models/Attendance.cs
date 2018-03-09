using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
  
namespace CUnlimited.Model  
{  
    public class Attendance  
    {  
        public int ID { get; set; }  
        public bool Present { get; set; } 
        public double ExtraWorkHr { get; set; } 
        public  DateTime AttendDate { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; } 
        public string Department { get; set; }
    }  
}