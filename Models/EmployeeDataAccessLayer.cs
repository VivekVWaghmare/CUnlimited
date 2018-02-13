using System;  
using System.Collections.Generic;  
using System.Data;  
using System.Data.SqlClient;  
using System.Linq;  
using System.Threading.Tasks;
using CUnlimited.Model;

namespace CUnlimited.Model
{
public class EmployeeDataAccessLayer  
    {  
        string connectionString = "Put Your Connection string here";  
  
        //To View all employees details  
        public IEnumerable<Employee> GetAllEmployees()  
        {  
            try  
            {  
                List<Employee> lstemployee = new List<Employee>();  
  
                using (SqlConnection con = new SqlConnection(connectionString))  
                {  
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);  
                    cmd.CommandType = CommandType.StoredProcedure;  
  
                    con.Open();  
                    SqlDataReader rdr = cmd.ExecuteReader();  
  
                    while (rdr.Read())  
                    {  
                        Employee employee = new Employee();  
  
                        employee.ID = Convert.ToInt32(rdr["EmployeeID"]);  
                        employee.Name = rdr["Name"].ToString();  
                        employee.Gender = rdr["Gender"].ToString();  
                        employee.Department = rdr["Department"].ToString();  
                        employee.City = rdr["City"].ToString();  
  
                        lstemployee.Add(employee);  
                    }  
                    con.Close();  
                }  
                return lstemployee;  
            }  
            catch  
            {  
                throw;  
            }  
        }  
  
        //To Add new employee record   
        public int AddEmployee(Employee employee)  
        {  
            try  
            {  
                using (SqlConnection con = new SqlConnection(connectionString))  
                {  
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);  
                    cmd.CommandType = CommandType.StoredProcedure;  
  
                    cmd.Parameters.AddWithValue("@Name", employee.Name);  
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);  
                    cmd.Parameters.AddWithValue("@Department", employee.Department);  
                    cmd.Parameters.AddWithValue("@City", employee.City);  
  
                    con.Open();  
                    cmd.ExecuteNonQuery();  
                    con.Close();  
                }  
                return 1;  
            }  
            catch  
            {  
                throw;  
            }  
        }  
  
        //To Update the records of a particluar employee  
        public int UpdateEmployee(Employee employee)  
        {  
            try  
            {  
                using (SqlConnection con = new SqlConnection(connectionString))  
                {  
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);  
                    cmd.CommandType = CommandType.StoredProcedure;  
  
                    cmd.Parameters.AddWithValue("@EmpId", employee.ID);  
                    cmd.Parameters.AddWithValue("@Name", employee.Name);  
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);  
                    cmd.Parameters.AddWithValue("@Department", employee.Department);  
                    cmd.Parameters.AddWithValue("@City", employee.City);  
  
                    con.Open();  
                    cmd.ExecuteNonQuery();  
                    con.Close();  
                }  
                return 1;  
            }  
            catch  
            {  
                throw;  
            }  
        }  
  
        //Get the details of a particular employee  
        public Employee GetEmployeeData(int id)  
        {  
            try  
            {  
                Employee employee = new Employee();  
  
                using (SqlConnection con = new SqlConnection(connectionString))  
                {  
                    string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeID= " + id;  
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);  
  
                    con.Open();  
                    SqlDataReader rdr = cmd.ExecuteReader();  
  
                    while (rdr.Read())  
                    {  
                        employee.ID = Convert.ToInt32(rdr["EmployeeID"]);  
                        employee.Name = rdr["Name"].ToString();  
                        employee.Gender = rdr["Gender"].ToString();  
                        employee.Department = rdr["Department"].ToString();  
                        employee.City = rdr["City"].ToString();  
                    }  
                }  
                return employee;  
            }  
            catch  
            {  
                throw;  
            }  
        }  
  
        //To Delete the record on a particular employee  
        public int DeleteEmployee(int id)  
        {  
            try  
            {  
                using (SqlConnection con = new SqlConnection(connectionString))  
                {  
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);  
                    cmd.CommandType = CommandType.StoredProcedure;  
  
                    cmd.Parameters.AddWithValue("@EmpId", id);  
  
                    con.Open();  
                    cmd.ExecuteNonQuery();  
                    con.Close();  
                }  
                return 1;  
            }  
            catch  
            {  
                throw;  
            }  
        }

         public IEnumerable<InventoryMaster> GetAllStock()  
        {  
            try  
            {  
                List<InventoryMaster> lstInventory = new List<InventoryMaster>();  
  
                using (SqlConnection con = new SqlConnection(connectionString))  
                {  
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);  
                    cmd.CommandType = CommandType.StoredProcedure;  
  
                    con.Open();  
                    SqlDataReader rdr = cmd.ExecuteReader();  
  
                    while (rdr.Read())  
                    {  
                        InventoryMaster inventory = new InventoryMaster();  
  
                        inventory.InventoryID = Convert.ToInt32(rdr["InventoryID"]);  
                        inventory.ItemName = rdr["Name"].ToString();  
                        inventory.StockQty = Convert.ToInt32(rdr["Quantity"]);  
                        inventory.ReorderQty = Convert.ToInt32(rdr["ReorderQty"]);  
                        inventory.PriorityStatus = Convert.ToInt32(rdr["PriorityStatus"]);
  
                        lstInventory.Add(inventory);  
                    }  
                    con.Close();  
                }  
                return lstInventory;  
            }  
            catch  
            {  
                throw;  
            }  
        }
        
         public int AddInventory(InventoryMaster item)  
        {  
            try  
            {  
                using (SqlConnection con = new SqlConnection(connectionString))  
                {  
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);  
                    cmd.CommandType = CommandType.StoredProcedure;  
  
                    cmd.Parameters.AddWithValue("@Name", item.ItemName);  
                    cmd.Parameters.AddWithValue("@Quantity", item.StockQty);  
                    cmd.Parameters.AddWithValue("@ReorderQty", item.ReorderQty);  
                    cmd.Parameters.AddWithValue("@PriorityStatus", item.PriorityStatus);  
  
                    con.Open();  
                    cmd.ExecuteNonQuery();  
                    con.Close();  
                }  
                return 1;  
            }  
            catch  
            {  
                throw;  
            }  
        }  
            
        public int UpdateInventory(InventoryMaster item)  
        {  
            try  
            {  
                using (SqlConnection con = new SqlConnection(connectionString))  
                {  
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);  
                    cmd.CommandType = CommandType.StoredProcedure;  
  
                    cmd.Parameters.AddWithValue("@InventoryID", item.InventoryID);  
                    cmd.Parameters.AddWithValue("@Name", item.ItemName);  
                    cmd.Parameters.AddWithValue("@Quantity", item.StockQty);  
                    cmd.Parameters.AddWithValue("@ReorderQty", item.ReorderQty);  
                    cmd.Parameters.AddWithValue("@PriorityStatus", item.PriorityStatus);  
  
                    con.Open();  
                    cmd.ExecuteNonQuery();  
                    con.Close();  
                }  
                return 1;  
            }  
            catch  
            {  
                throw;  
            }  
        } 

        public InventoryMaster GetInventoryItem(int id)  
        {  
            try  
            {  
                InventoryMaster item = new InventoryMaster();  
  
                using (SqlConnection con = new SqlConnection(connectionString))  
                {  
                    string sqlQuery = "SELECT * FROM InventoryMaster WHERE InventoryID= " + id;  
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);  
  
                    con.Open();  
                    SqlDataReader rdr = cmd.ExecuteReader();  
  
                    while (rdr.Read())  
                    {  
                        item.InventoryID = Convert.ToInt32(rdr["InventoryID"]);  
                        item.ItemName = rdr["Name"].ToString();  
                        item.StockQty = Convert.ToInt32(rdr["Quantity"]);  
                        item.ReorderQty = Convert.ToInt32(rdr["ReorderQty"]);  
                        item.PriorityStatus = Convert.ToInt32(rdr["PriorityStatus"]);  
                    }  
                }  
                return item;  
            }  
            catch  
            {  
                throw;  
            }  
        }  

        public int DeleteInventorItem(int id)  
        {  
            try  
            {  
                using (SqlConnection con = new SqlConnection(connectionString))  
                {  
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);  
                    cmd.CommandType = CommandType.StoredProcedure;  
  
                    cmd.Parameters.AddWithValue("@InventoryID", id);  
  
                    con.Open();  
                    cmd.ExecuteNonQuery();  
                    con.Close();  
                }  
                return 1;  
            }  
            catch  
            {  
                throw;  
            }  
        }
    } 
}