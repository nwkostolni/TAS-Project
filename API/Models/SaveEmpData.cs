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

        public void DeleteEmployee(Employee value){ //Method for removing an individual employee
            string cs;
            try
            {
                cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\API\Database\TAS.db";
            }
            catch (FileNotFoundException e) //Error Check
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong.....employee was not deleted. {0}", e);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            using var con= new SQLiteConnection(cs);
            con.Open(); //Open a connection to the database

            using var cmd= new SQLiteCommand(con);

            cmd.CommandText=$@"DELETE FROM Employee WHERE EmployeeId={value.EmpId}"; //Remove the employee that the user specified
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void EditEmployee(Employee Value)
        {
            string cs = @"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\API\Database\TAS.db";
                using var con = new SQLiteConnection(cs);
                con.Open();
                string stm = $@"DELETE FROM Employee WHERE EmployeeId = {Value.EmpId}";
                using var cmd = new SQLiteCommand(stm, con);

                cmd.Parameters.AddWithValue("@EmployeeId", Value.EmpId);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                using var con2 = new SQLiteConnection(cs);
                con2.Open();
                using var cmd2 = new SQLiteCommand(con2);
                cmd.CommandText = @"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
                cmd.Parameters.AddWithValue("@EmployeeId", Value.EmpId); 
                cmd.Parameters.AddWithValue("@FirstName", Value.EmpFirst);
                cmd.Parameters.AddWithValue("@LastName", Value.EmpLast); 
                cmd.Parameters.AddWithValue("@EmployeeEmail", Value.EmpEmail); 
                cmd.Parameters.AddWithValue("@EmployeeDepartment", Value.EmpDep); 
                cmd.Parameters.AddWithValue("@EmploymentLevel", Value.EmpLvl); 
                cmd.Parameters.AddWithValue("@Admin", Value.Admin); 
                cmd.Parameters.AddWithValue("@Password", Value.Password); 
                cmd.Parameters.AddWithValue("@MgrId", Value.MgrId);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
        }
    }
}