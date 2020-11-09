using System.IO.Enumeration;
using System.Security.AccessControl;
using System;
using System.Data.SQLite;
using System.IO;
using TAS_Project.Interfaces;

namespace TAS_Project.Models
{
    public class Employee
    {
        public int EmpId {get;set;}
        public string EmpFirst {get;set;}
        public string EmpLast {get;set;}
        public string EmpEmail {get;set;}
        public string EmpDep {get;set;}
        public string EmpLvl {get;set;}
        public bool Admin {get;set;}
        public int MgrId {get;set;}
        public string Password {get;set;}



        public Employee()
        {

        }



        public void AddEmployee()
        {
            Console.Clear();
           Console.WriteLine("To add a new employee, type employee ID and press enter:");
           int tempId = Int32.Parse(Console.ReadLine()); //Get employee ID
           Console.WriteLine("Type employee first name and press enter:");
           string tempFirst = Console.ReadLine();
           Console.WriteLine("Type employee last name and press enter:");
           string tempLast = Console.ReadLine();
           Console.WriteLine("Type employee email and press enter:");
           string tempMail = Console.ReadLine();
           Console.WriteLine("Type employee department and press enter:");
           string tempDep = Console.ReadLine();
           Console.WriteLine("Type employee level and press enter:");
           string tempLvl = Console.ReadLine();
           Console.WriteLine("Is the employee and admin? 0 = no, 1 = yes");
           bool tempAdmin = Boolean.Parse(Console.ReadLine());
           Console.WriteLine("Type employee manager ID and press enter:");
           int tempMgrid = Int32.Parse(Console.ReadLine());
           Console.WriteLine("Type employee password and press enter:");
           string tempPass = Console.ReadLine();
           Employee tempEmp = new Employee(){EmpId=tempId, EmpFirst=tempFirst, EmpLast=tempLast, EmpEmail=tempMail, EmpDep=tempDep, EmpLvl=tempLvl, Admin=tempAdmin, MgrId=tempMgrid, Password=tempPass}; //make a single object of the new employee
           ISaveEmpData updateObject = new SaveEmpData();
           updateObject.UpdateEmployee(tempEmp); //add new employee to the database
           Console.WriteLine("\nEmployee has been added. Press any key to return to main menu.");
           Console.ReadKey();
        }



        public void RemoveEmployee(Employee employee)
        {
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
            con.Open(); //Open a connection to the database

            using var cmd= new SQLiteCommand(con);
            
            cmd.CommandText=$@"DELETE FROM employees WHERE id={employee.EmpId}"; //Remove the employee that the user specified
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }



        public void EditEmployee()
        {

        }
    }
}