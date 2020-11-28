using System.Reflection.PortableExecutable;
using System.IO.Enumeration;
using System.Security.AccessControl;
using System;
using System.IO;
using System.Data.SQLite;
using TAS_Project.Interfaces;

namespace TAS_Project.Models
{
    public class SaveAnswerData : ISaveAnswerData
    {
        public void UpdateAnswer(Answer value){
            string cs;
            try
            {
                cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\API\Database\TAS.db"; 
            }
            catch (FileNotFoundException e) //Error Check
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong.....answer was not added. {0}", e);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            using var con = new SQLiteConnection(cs);
            con.Open(); //opens a connection to the database
             
            using var cmd= new SQLiteCommand(con);
  
            
       
            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", value.AnsId); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", value.AnsNumeric);
            cmd.Parameters.AddWithValue("@AnswerText", value.AnsText);
            cmd.Parameters.AddWithValue("@SurveyId", value.SurveyId);
            cmd.Parameters.AddWithValue("@InputChoiceId", value.InputChoiceId);
            cmd.Parameters.AddWithValue("@QuestionId", value.QstId);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        } 

        public void AddAnswers(Answer[] arrayOfAnswers){
            for(int i=0; i<58; i++){
                Console.WriteLine(arrayOfAnswers[i].AnsNumeric);
            }
        }
    }
}