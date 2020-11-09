using System.Security.AccessControl;
using System;
using System.IO;
using System.Data.SQLite;
using TAS_Project.Interfaces;

namespace TAS_Project.Models
{
    public class SaveEmpData : ISaveEmpData
    {   

        public void UpdateEmployee(Employee employee){ //Method for saving an emplyoyee
            string cs;
            try
            {
                cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\API\Database\TAS.db";
            }
            catch (FileNotFoundException e) //Error Check
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong.....employee was not updated. {0}", e);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            using var con= new SQLiteConnection(cs); 
            con.Open(); //opens a connection to the database

            using var cmd= new SQLiteCommand(con);
            
            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)"; //Adds new employee into the database
            cmd.Parameters.AddWithValue("@EmployeeId", employee.EmpId); 
            cmd.Parameters.AddWithValue("@FirstName", employee.EmpFirst);
            cmd.Parameters.AddWithValue("@LastName", employee.EmpLast); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", employee.EmpEmail); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", employee.EmpDep); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", employee.EmpLvl); 
            cmd.Parameters.AddWithValue("@Admin", employee.Admin); 
            cmd.Parameters.AddWithValue("@Password", employee.Password); 
            cmd.Parameters.AddWithValue("@MgrId", employee.MgrId); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}