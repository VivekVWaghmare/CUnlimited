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
        //string connectionString = "DefaultConnection";  
  string connectionString = "Data Source=LAPTOP-8OC40J3I;Initial Catalog=PayRoll;User ID=vivek;Password=vivek123";
        //To View all employees details  
        public IEnumerable<EmployeeDetails> GetAllEmployees()  
        {  
            try  
            {  
                List<EmployeeDetails> lstemployee = new List<EmployeeDetails>();  
  
                using (SqlConnection con = new SqlConnection(connectionString))  
                {  
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);  
                    cmd.CommandType = CommandType.StoredProcedure;  
  
                    con.Open();  
                    SqlDataReader rdr = cmd.ExecuteReader();  
  
                    while (rdr.Read())  
                    {  
                        EmployeeDetails employee = new EmployeeDetails();  
  
                        employee.ID = Convert.ToInt32(rdr["EmployeeID"]);  
                        employee.FirstName = rdr["FirstName"].ToString(); 
                        employee.LastName = rdr["LastName"].ToString(); 
                        employee.GenderId = Convert.ToInt32(rdr["GenderId"]);
                        employee.GenderName = rdr["GenderName"].ToString(); 
                        employee.DepartmentId = Convert.ToInt32(rdr["DepartmentId"]); 
                        employee.Department = rdr["DepartmentName"].ToString();
  
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
        public int AddEmployee(EmployeeDetails employee)  
        {  
            try  
            {  
                using (SqlConnection con = new SqlConnection(connectionString))  
                {  
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);  
                    cmd.CommandType = CommandType.StoredProcedure;  
  
                    cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);  
                    cmd.Parameters.AddWithValue("@LastName", employee.LastName); 
                    cmd.Parameters.AddWithValue("@Gender", employee.GenderId);  
                    cmd.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);  
                    cmd.Parameters.AddWithValue("@PhoneNo", employee.PhoneNo);  
  
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
        public int UpdateEmployee(EmployeeDetails employee)  
        {  
            try  
            {  
                using (SqlConnection con = new SqlConnection(connectionString))  
                {  
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);  
                    cmd.CommandType = CommandType.StoredProcedure;  
  
                    cmd.Parameters.AddWithValue("@EmpId", employee.ID);  
                    cmd.Parameters.AddWithValue("@FirstName", employee.FirstName); 
                    cmd.Parameters.AddWithValue("@LastName", employee.LastName);  
                    cmd.Parameters.AddWithValue("@Gender", employee.GenderId);  
                    cmd.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
                    cmd.Parameters.AddWithValue("@PhoneNo", employee.PhoneNo);
  
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
        public EmployeeDetails GetEmployeeData(int id)  
        {  
            try  
            {  
                EmployeeDetails employee = new EmployeeDetails();  
  
                using (SqlConnection con = new SqlConnection(connectionString))  
                {  
                    SqlCommand cmd = new SqlCommand("spGetAllEmployeesbyId", con);  
                    cmd.CommandType = CommandType.StoredProcedure;  
                    cmd.Parameters.AddWithValue("@EmpId", id);  
  
                    con.Open();  
                    SqlDataReader rdr = cmd.ExecuteReader(); 
                    while (rdr.Read())  
                    {  
                        employee.ID = Convert.ToInt32(rdr["EmployeeID"]);  
                        employee.FirstName = rdr["FirstName"].ToString(); 
                        employee.LastName = rdr["LastName"].ToString(); 
                        employee.GenderId = Convert.ToInt32(rdr["GenderId"]);
                        employee.GenderName = rdr["GenderName"].ToString(); 
                        employee.DepartmentId = Convert.ToInt32(rdr["DepartmentId"]); 
                        employee.Department = rdr["DepartmentName"].ToString();  
                        employee.PhoneNo = Convert.ToDouble(rdr["PhoneNo"]); 
                    }  
                    con.Close(); 
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
                    SqlCommand cmd = new SqlCommand("spGetAllStock", con);  
                    cmd.CommandType = CommandType.StoredProcedure;  
  
                    con.Open();  
                    SqlDataReader rdr = cmd.ExecuteReader();  
  
                    while (rdr.Read())  
                    {  
                        InventoryMaster inventory = new InventoryMaster();  
  
                        inventory.InventoryID = Convert.ToInt32(rdr["Id"]);  
                        inventory.ItemName = rdr["Name"].ToString();  
                        inventory.StockQty = Convert.ToInt32(rdr["Quantity"]);  
                        inventory.InQuantity = Convert.ToDouble(rdr["InQuantity"]); 
                        inventory.OutQuantity = Convert.ToDouble(rdr["OutQuantity"]); 
                        inventory.DepartmentId = Convert.ToInt32(rdr["DepartmentId"]);
                        inventory.DepartmentName = rdr["DepartmentName"].ToString(); 
                        //inventory.ReorderQty = Convert.ToInt32(rdr["ReorderQty"]);  
                        //inventory.PriorityStatus = Convert.ToInt32(rdr["PriorityStatus"]);
  
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
                    SqlCommand cmd = new SqlCommand("spAddStock", con);  
                    cmd.CommandType = CommandType.StoredProcedure;  
  
                    cmd.Parameters.AddWithValue("@Name", item.ItemName);  
                    cmd.Parameters.AddWithValue("@Quantity", item.StockQty);
                    cmd.Parameters.AddWithValue("@InQuantity", item.InQuantity);
                    cmd.Parameters.AddWithValue("@OutQuantity", item.OutQuantity);
                    cmd.Parameters.AddWithValue("@DepartmentId", item.DepartmentId);
                    cmd.Parameters.AddWithValue("@UserId", 1);
                    // cmd.Parameters.AddWithValue("@ReorderQty", item.ReorderQty);  
                    // cmd.Parameters.AddWithValue("@PriorityStatus", item.PriorityStatus);  
  
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
                    SqlCommand cmd = new SqlCommand("spUpdateStock", con);  
                    cmd.CommandType = CommandType.StoredProcedure;  
  
                    cmd.Parameters.AddWithValue("@InventoryID", item.InventoryID);  
                    cmd.Parameters.AddWithValue("@Name", item.ItemName);  
                    cmd.Parameters.AddWithValue("@Quantity", item.StockQty);
                    cmd.Parameters.AddWithValue("@InQuantity", item.InQuantity);
                    cmd.Parameters.AddWithValue("@OutQuantity", item.OutQuantity);
                    cmd.Parameters.AddWithValue("@DepartmentId", item.DepartmentId); 
                    cmd.Parameters.AddWithValue("@UserId", 1); 
                    // cmd.Parameters.AddWithValue("@ReorderQty", item.ReorderQty);  
                    // cmd.Parameters.AddWithValue("@PriorityStatus", item.PriorityStatus);  
  
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
                        item.InQuantity = Convert.ToDouble(rdr["InQuantity"]); 
                        item.OutQuantity = Convert.ToDouble(rdr["OutQuantity"]); 
                        item.DepartmentId = Convert.ToInt32(rdr["DepartmentId"]);
                        item.DepartmentName = rdr["DepartmentName"].ToString();   
                        // item.ReorderQty = Convert.ToInt32(rdr["ReorderQty"]);  
                        // item.PriorityStatus = Convert.ToInt32(rdr["PriorityStatus"]);  
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
                    SqlCommand cmd = new SqlCommand("spDeleteStock", con);  
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

         public IEnumerable<Department> GetAllDepartment()  
        {  
            try  
            {  
                List<Department> lstDepartment = new List<Department>();  
  
                using (SqlConnection con = new SqlConnection(connectionString))  
                {  
                    SqlCommand cmd = new SqlCommand("spGetDepartment", con);  
                    cmd.CommandType = CommandType.StoredProcedure;  
  
                    con.Open();  
                    SqlDataReader rdr = cmd.ExecuteReader();  
  
                    while (rdr.Read())  
                    {  
                        Department department = new Department();  
  
                        department.Id = Convert.ToInt32(rdr["Id"]);  
                        department.DepartmentName = rdr["DepartmentName"].ToString();  
  
                        lstDepartment.Add(department);  
                    }  
                    con.Close();  
                }  
                return lstDepartment;  
            }  
            catch  
            {  
                throw;  
            }  
        }

        public int UpdateAttendance(Attendance item)  
        {  
            try  
            {  
                using (SqlConnection con = new SqlConnection(connectionString))  
                {  
                    SqlCommand cmd = new SqlCommand("spUpdateAttendanceForDay", con);  
                    cmd.CommandType = CommandType.StoredProcedure;  
  
                    cmd.Parameters.AddWithValue("@EmployeeId", item.ID);  
                    cmd.Parameters.AddWithValue("@Present", item.Present);
                    cmd.Parameters.AddWithValue("@ExtraHour", item.ExtraWorkHr);  
                    //cmd.Parameters.AddWithValue("@Quantity", item.AttendDate); 
                    // cmd.Parameters.AddWithValue("@ReorderQty", item.ReorderQty);  
                    // cmd.Parameters.AddWithValue("@PriorityStatus", item.PriorityStatus);  
  
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