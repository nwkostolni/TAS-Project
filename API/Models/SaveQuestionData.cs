using System.Security.AccessControl;
using System;
using System.Data.SQLite;
using System.IO;
using TAS_Project.Interfaces;

namespace TAS_Project.Models
{
    public class SaveQuestionData : ISaveQuestionData
    {
        public void UpdateQuestion(Question value){ //Method for adding an individual Question
            string cs;
            try
            {
                cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\API\Database\TAS.db";
            }
            catch (FileNotFoundException e) //Error Check
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong.....question was not added. {0}", e);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            using var con= new SQLiteConnection(cs); 
            con.Open(); //opens a connection to the database

            using var cmd= new SQLiteCommand(con);
            
            cmd.CommandText=@"INSERT INTO Question(QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionText", value.QstText); //Adds new question into the database. Id # is autogenerated
            cmd.Parameters.AddWithValue("@QuestionRequired", value.QstRequired); 
            cmd.Parameters.AddWithValue("@AnswerRequired", value.AnsRequired); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", value.AllowMultipleAnswers); 
            cmd.Parameters.AddWithValue("@QuestionCategory", value.QstCategory ); 
            cmd.Parameters.AddWithValue("@InputTypeId", value.InputTypeId); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}