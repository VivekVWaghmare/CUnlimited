using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using System.Data.SqlClient;  
using System.Data;  
using CUnlimited.Model; 

namespace CUnlimited.Model
{
   // [Produces("application/json")]  
    //[Route("api/InventoryAPI")] 
    public class InventoryAPIController : Controller
    {
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();
        // GET: api/InventoryMasterAPI  

        [HttpGet]
        [Route("api/InventoryAPI/Inventory")]
        public IEnumerable<InventoryMaster> GetInventoryMaster() => objemployee.GetAllStock();

        [HttpPost]  
        [Route("api/InventoryAPI/AddInventory")]
        public int Create([FromBody] InventoryMaster item)  
        {  
            return objemployee.AddInventory(item);  
        } 

        [HttpGet]  
        [Route("api/InventoryAPI/Details/{id}")]  
        public InventoryMaster Details(int id)  
        {  
            return objemployee.GetInventoryItem(id);  
        }  
  
        [HttpPut]  
        [Route("api/InventoryAPI/Edit")]  
        public int Edit([FromBody]InventoryMaster item)  
        {  
            return objemployee.UpdateInventory(item);  
        }  
  
        [HttpDelete]  
        [Route("api/InventoryAPI/Delete/{id}")]  
        public int Delete(int id)  
        {  
            return objemployee.DeleteInventorItem(id);  
        }  
    }
    
}