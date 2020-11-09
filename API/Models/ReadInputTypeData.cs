using System.IO.Enumeration;
using System;
using System.Security.AccessControl;
using System.Collections.Generic;
using System.IO;
using System.Data.SQLite;
using TAS_Project.Interfaces;

namespace TAS_Project.Models
{
    public class ReadInputTypeData : IReadInputTypeData
    {
        public List<InputType> GetAllInputTypes(){
            List<InputType> allInputType = new List<InputType>();
            string cs;
            try
            {
                cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\API\Database\TAS.db"; 
            }
            catch (FileNotFoundException e) //Error Check
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong.....returning blank list. {0}", e);
                Console.ForegroundColor = ConsoleColor.White;
                return allInputType;
            }
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM InputType"; //Pulls the data from the table
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();
            
            while(rdr.Read()){ //Reads in each new row of data
                InputType temp= new InputType(){InputTypeId=rdr.GetInt32(0), InputTypeName=rdr.GetString(1)};
                allInputType.Add(temp);
            }

            return allInputType; //Returns a list containing the data from the database
        }
        public InputType GetInputType(int InputTypeId){
            string cs;
            try
            {
                cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\API\Database\TAS.db"; 
            }
            catch (FileNotFoundException e) //Error Check
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong.....returning a blank object. {0}", e);
                Console.ForegroundColor = ConsoleColor.White;
                return new InputType(){InputTypeId=-1, InputTypeName=""};
            }
            using var con=new SQLiteConnection(cs);
            con.Open();

            string stm= "SELECT * FROM InputType WHERE InputTypeId=@id";
            using var cmd=new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", InputTypeId);
            cmd.Prepare();
            using SQLiteDataReader rdr=cmd.ExecuteReader();

            rdr.Read();
            return new InputType(){InputTypeId=rdr.GetInt32(0), InputTypeName=rdr.GetString(1)};
        }
    }
}