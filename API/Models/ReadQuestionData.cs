using System;
using System.Security.AccessControl;
using System.Collections.Generic;
using System.Data.SQLite;
using TAS_Project.Interfaces;

namespace TAS_Project.Models
{
    public class ReadQuestionData :IReadQuestionData
    {
        public List<Question> GetAllQuestions(){
            string cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\API\Database\TAS.db";
            using var con = new SQLiteConnection(cs);
           con.Open();
           string stm = "SELECT * FROM Question";
           using var cmd = new SQLiteCommand(stm, con);
           
           using SQLiteDataReader rdr = cmd.ExecuteReader();
            List<Question> allQuestions = new List<Question>();
           while(rdr.Read())
           {
               allQuestions.Add(new Question(){QstId=rdr.GetInt32(0), QstText= rdr.GetString(1),QstRequired= rdr.GetBoolean(2), AnsRequired=rdr.GetBoolean(3), AllowMultipleAnswers=rdr.GetBoolean(4), QstCategory=rdr.GetString(5),InputTypeId= rdr.GetInt32(6)});

           }
           return allQuestions;
        }
    }
}