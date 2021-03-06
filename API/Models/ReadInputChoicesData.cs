using System.Xml.Schema;
using System.IO;
using System;
using System.Security.AccessControl;
using System.Collections.Generic;
using System.Data.SQLite;
using TAS_Project.Interfaces;

namespace TAS_Project.Models
{
    public class ReadInputChoicesData : IReadInputChoicesData
    {
        public List<InputChoices> GetAllInputChoices(){
            List<InputChoices> allInputChoices = new List<InputChoices>();
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
                return allInputChoices;
            }
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM InputChoices"; //Pulls the data from the table
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();
            
            while(rdr.Read()){ //Reads in each new row of data
                InputChoices temp= new InputChoices(){InputChoiceId=rdr.GetInt32(0), InputChoiceName=rdr.GetString(1), InputTypeId=rdr.GetInt32(2)};
                allInputChoices.Add(temp);
            }

            return allInputChoices; //Returns a list containing the data from the database
        }

        public InputChoices GetInputChoice(int InputChoiceId){
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
                return new InputChoices(){InputChoiceId=-1, InputChoiceName="", InputTypeId=-1};
            }
            using var con=new SQLiteConnection(cs);
            con.Open();

            string stm= "SELECT * FROM InputChoices WHERE InputChoiceId=@id";
            using var cmd=new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", InputChoiceId);
            cmd.Prepare();
            using SQLiteDataReader rdr=cmd.ExecuteReader();

            rdr.Read();
            return new InputChoices(){InputChoiceId=rdr.GetInt32(0), InputChoiceName=rdr.GetString(1), InputTypeId=rdr.GetInt32(2)};
        }
    }
}