using System.Threading;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace TAS_Project.Database
{
    public class ReadEmpData : IReadEmpData
    {
        public List<Employee> GetAllEmployees(){
            List<Employee> allEmployees = new List<Employee>();
            string cs;
            try
            {
                cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\Database\TAS.db"; 
            }
            catch (FileNotFoundException e) //Error Check
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong.....returning blank list. {0}", e);
                Console.ForegroundColor = ConsoleColor.White;
                return allEmployees;
            }
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Employee"; //Pulls the data from the table
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();
            
            while(rdr.Read()){ //Reads in each new row of data
                Employee temp= new Employee(){EmpId=rdr.GetInt32(0), EmpFirst=rdr.GetString(1), EmpLast=rdr.GetInt32(2), EmpEmail=rdr.GetString(3), EmpDep=rdr.GetString(4), EmpLvl=rdr.GetString(5), Admin=rdr.GetInt32(6), Password=rdr.GetString(7), MgrId=rdr.GetInt32(8)};
                allEmployees.Add(temp);
            }
            return allEmployees; //Returns a list containing the data from the database
        }

        public Employee GetEmployee(int EmpId){
            string cs;
            try
            {
                cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\Database\TAS.db"; 
            }
            catch (FileNotFoundException e) //Error Check
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong.....returning nothing. {0}", e);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            using var con=new SQLiteConnection(cs);
            con.Open();

            string stm= "SELECT * FROM Employee WHERE EmployeeId=@id";
            using var cmd=new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", EmpId);
            cmd.Prepare();
            using SQLiteDataReader reader=cmd.ExecuteReader();

            reader.Read();
            return new Employee(){EmpId=rdr.GetInt32(0), EmpFirst=rdr.GetString(1), EmpLast=rdr.GetInt32(2), EmpEmail=rdr.GetString(3), EmpDep=rdr.GetString(4), EmpLvl=rdr.GetString(5), Admin=rdr.GetInt32(6), Password=rdr.GetString(7), MgrId=rdr.GetInt32(8)};
        }
    }
}