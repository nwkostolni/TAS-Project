using System.Data.SQLite;
using System.Collections.Generic;
using System;
using System.IO;
using TAS_Project.Interfaces;

namespace TAS_Project.Models
{
    public class SeedEmployeeData : ISeedData
    {
        public void SeedData(){ //Method for Reseeding all the Employees
            string cs;
            try
            {
                cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\API\Database\TAS.db";
            }
            catch (FileNotFoundException e) //Error Check
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong.....database was not re-seeded. {0}", e);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            using var con= new SQLiteConnection(cs);
            con.Open();

            using var cmd= new SQLiteCommand(con);

            cmd.CommandText = "DROP TABLE IF EXISTS Employee"; //Deletes any pre-existing tables
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"CREATE TABLE Employee(EmployeeId INTEGER PRIMARY KEY, FirstName TEXT, LastName TEXT, EmployeeEmail TEXT, EmployeeDepartment TEXT, EmploymentLevel TEXT, Admin BOOLEAN, Password TEXT, MgrId INTEGER, FOREIGN KEY(MgrId) REFERENCES Employee(EmployeeId))"; //Creates a new table
            cmd.ExecuteNonQuery();

            //Resets the database to the original.
            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "1"); 
            cmd.Parameters.AddWithValue("@FirstName", "Melisa");
            cmd.Parameters.AddWithValue("@LastName", "Rann"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "mrann@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Audit"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Partner"); 
            cmd.Parameters.AddWithValue("@Admin", "1"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", ""); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "2"); 
            cmd.Parameters.AddWithValue("@FirstName", "Barnabe");
            cmd.Parameters.AddWithValue("@LastName", "Ackerley"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "backerley@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Advisory"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Partner"); 
            cmd.Parameters.AddWithValue("@Admin", "1"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", ""); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "3"); 
            cmd.Parameters.AddWithValue("@FirstName", "Anastassia");
            cmd.Parameters.AddWithValue("@LastName", "Covil"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "acovil@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Tax"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Partner"); 
            cmd.Parameters.AddWithValue("@Admin", "1"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", ""); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "4"); 
            cmd.Parameters.AddWithValue("@FirstName", "Ailey");
            cmd.Parameters.AddWithValue("@LastName", "Hurrell"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "ahurrell@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Audit"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Manager"); 
            cmd.Parameters.AddWithValue("@Admin", "0"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "5"); 
            cmd.Parameters.AddWithValue("@FirstName", "Tiebout");
            cmd.Parameters.AddWithValue("@LastName", "Galpin"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "tgalpin@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Audit"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Manager"); 
            cmd.Parameters.AddWithValue("@Admin", "0"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "6"); 
            cmd.Parameters.AddWithValue("@FirstName", "Nanette");
            cmd.Parameters.AddWithValue("@LastName", "Rings"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "nrings@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Tax"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Manager"); 
            cmd.Parameters.AddWithValue("@Admin", "0"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", "2"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "7"); 
            cmd.Parameters.AddWithValue("@FirstName", "Shellysheldon");
            cmd.Parameters.AddWithValue("@LastName", "Pomphrey"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "spomphrey@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Tax"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Manager"); 
            cmd.Parameters.AddWithValue("@Admin", "0"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", "2"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "8"); 
            cmd.Parameters.AddWithValue("@FirstName", "Rubie");
            cmd.Parameters.AddWithValue("@LastName", "Creser"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "rcreser@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Advisory"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Manager"); 
            cmd.Parameters.AddWithValue("@Admin", "0"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", "3"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "9"); 
            cmd.Parameters.AddWithValue("@FirstName", "Stacee");
            cmd.Parameters.AddWithValue("@LastName", "Fookes"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "sfookes@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Advisory"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Manager"); 
            cmd.Parameters.AddWithValue("@Admin", "0"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", "3"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "10"); 
            cmd.Parameters.AddWithValue("@FirstName", "Harris");
            cmd.Parameters.AddWithValue("@LastName", "Maxwaile"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "hmaxwaile@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Advisory"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Associate"); 
            cmd.Parameters.AddWithValue("@Admin", "0"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", "9"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "11"); 
            cmd.Parameters.AddWithValue("@FirstName", "Flo");
            cmd.Parameters.AddWithValue("@LastName", "Doyley"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "fdoyley@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Tax"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Associate"); 
            cmd.Parameters.AddWithValue("@Admin", "0"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", "6"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "12"); 
            cmd.Parameters.AddWithValue("@FirstName", "Ginnie");
            cmd.Parameters.AddWithValue("@LastName", "Gauford"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "ggauford@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Tax"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Associate"); 
            cmd.Parameters.AddWithValue("@Admin", "0"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", "7"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "13"); 
            cmd.Parameters.AddWithValue("@FirstName", "Cletus");
            cmd.Parameters.AddWithValue("@LastName", "McLucky"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "cmclucky@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Audit"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Associate"); 
            cmd.Parameters.AddWithValue("@Admin", "0"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", "4"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "14"); 
            cmd.Parameters.AddWithValue("@FirstName", "Della");
            cmd.Parameters.AddWithValue("@LastName", "Ellett"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "dellett@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Audit"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Associate"); 
            cmd.Parameters.AddWithValue("@Admin", "0"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", "4"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "15"); 
            cmd.Parameters.AddWithValue("@FirstName", "Marketa");
            cmd.Parameters.AddWithValue("@LastName", "Baitson"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "mbaitson@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Advisory"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Associate"); 
            cmd.Parameters.AddWithValue("@Admin", "0"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", "9"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "16"); 
            cmd.Parameters.AddWithValue("@FirstName", "Lyndsie");
            cmd.Parameters.AddWithValue("@LastName", "Pinkstone"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "lpinkstone@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Tax"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Associate"); 
            cmd.Parameters.AddWithValue("@Admin", "0"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", "6"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "17"); 
            cmd.Parameters.AddWithValue("@FirstName", "Hadley");
            cmd.Parameters.AddWithValue("@LastName", "Allan"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "hallan@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Advisory"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Associate"); 
            cmd.Parameters.AddWithValue("@Admin", "0"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", "8"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "18"); 
            cmd.Parameters.AddWithValue("@FirstName", "Wynny");
            cmd.Parameters.AddWithValue("@LastName", "Curror"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "wcurror@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Advisory"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Associate"); 
            cmd.Parameters.AddWithValue("@Admin", "0"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", "8"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "19"); 
            cmd.Parameters.AddWithValue("@FirstName", "Cordelie");
            cmd.Parameters.AddWithValue("@LastName", "Ellings"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "cellings@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Audit"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Associate"); 
            cmd.Parameters.AddWithValue("@Admin", "0"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", "5"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Employee(EmployeeId, FirstName, LastName, EmployeeEmail, EmployeeDepartment, EmploymentLevel, Admin, Password, MgrId) VALUES(@EmployeeId, @FirstName, @LastName, @EmployeeEmail, @EmployeeDepartment, @EmploymentLevel, @Admin, @Password, @MgrId)";
            cmd.Parameters.AddWithValue("@EmployeeId", "20"); 
            cmd.Parameters.AddWithValue("@FirstName", "Olivette");
            cmd.Parameters.AddWithValue("@LastName", "Lamp"); 
            cmd.Parameters.AddWithValue("@EmployeeEmail", "olamp@TAS.com"); 
            cmd.Parameters.AddWithValue("@EmployeeDepartment", "Tax"); 
            cmd.Parameters.AddWithValue("@EmploymentLevel", "Associate"); 
            cmd.Parameters.AddWithValue("@Admin", "0"); 
            cmd.Parameters.AddWithValue("@Password", "setup1234"); 
            cmd.Parameters.AddWithValue("@MgrId", "7"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}