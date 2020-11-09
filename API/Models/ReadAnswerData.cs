using System;
using System.Security.AccessControl;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using TAS_Project.Interfaces;

namespace TAS_Project.Models
{
    public class ReadAnswerData : IReadAnsData
    {
        public List<Answer> GetAllAnswers()
        {
            List <Answer> allAnswers = new List<Answer>();
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
                return allAnswers;
            }
            using var con = new SQLiteConnection(cs);
            con.Open();
            string stm = "SELECT * FROM Answer"; //Pulls the data from the table
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();
            
            while(rdr.Read()){ //Reads in each new row of data
                Answer temp = new Answer(){AnsId=rdr.GetInt32(0), AnsNumeric=rdr.GetInt32(1), AnsText=rdr.GetString(2), SurveyId=rdr.GetInt32(3), InputChoiceId=rdr.GetInt32(4), QstId=rdr.GetInt32(5)};
                allAnswers.Add(temp);
            }
            return allAnswers;


        }
        public Answer GetAnswer(int AnsId)
        {
            string cs;
            try
            {
                cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\API\Database\TAS.db"; 
            }
            catch (FileNotFoundException e) //Error Check
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong.....returning blank object. {0}", e);
                Console.ForegroundColor = ConsoleColor.White;
                return new Answer(){AnsId=-1, AnsNumeric=-1, AnsText ="",  SurveyId=-1, InputChoiceId=-1, QstId=-1};
            }
            using var con=new SQLiteConnection(cs);
            con.Open();

            string stm= "SELECT * FROM Answer WHERE AnswerId=@id";
            using var cmd=new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", AnsId);
            cmd.Prepare();
            using SQLiteDataReader rdr=cmd.ExecuteReader();

            rdr.Read();
            return new Answer(){AnsId=rdr.GetInt32(0), AnsNumeric=rdr.GetInt32(1), AnsText=rdr.GetString(2), SurveyId=rdr.GetInt32(3), InputChoiceId=rdr.GetInt32(4), QstId=rdr.GetInt32(5)};
        }
        
    }
}