
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
        public int StockQty { get; set; }   
        public int ReorderQty { get; set; }  
        public int PriorityStatus { get; set; }  
    }  
}