
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  

namespace CUnlimited.Model
{
public class InventoryMaster  
    {  
        public int InventoryID { get; set; }  
        public string ItemName { get; set; }  
        public double StockQty { get; set; }   
        public double InQuantity { get; set; }
        public double OutQuantity { get; set; }  
        public int DepartmentId { get; set; }  
        public string DepartmentName { get; set; } 
        public int PriorityStatus { get; set; } 
        public int ReorderQty { get; set; } 
    }  
}