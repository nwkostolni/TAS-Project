using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System;
using System.Data.SQLite;
using System.IO;
using TAS_Project.Interfaces;

namespace TAS_Project.Models
{
    public class SaveSurveyData : ISaveSurveyData
    {
        public void UpdateSurvey(Survey survey){ //Method for saving survey data
            string cs;
            try
            {
                cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\API\Database\TAS.db";
            }
            catch (FileNotFoundException e) //Error Check
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong.....survey data was not updated. {0}", e);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            using var con= new SQLiteConnection(cs); 
            con.Open(); //opens a connection to the database

            using var cmd= new SQLiteCommand(con);
            
            cmd.CommandText=@"INSERT INTO Survey(SurveyId, Cycle, DateDue, BeenCompleted, DateCompleted, ReviewerEmpId, SubjectEmpId) VALUES(@SurveyId, @Cycle, @DateDue, @BeenCompleted, @DateCompleted, @ReviewerEmpId, @SubjectEmpId)";
            cmd.Parameters.AddWithValue("@SurveyId", survey.SurveyId); 
            cmd.Parameters.AddWithValue("@Cycle", survey.Cycle);
            cmd.Parameters.AddWithValue("@DateDue", survey.DateDue); //needs to be converted from datetime to string
            cmd.Parameters.AddWithValue("@BeenCompleted", survey.BeenCompleted); 
            cmd.Parameters.AddWithValue("@DateCompleted", survey.DateCompleted); //needs to be converted from datetime to string
            cmd.Parameters.AddWithValue("@ReviewerEmpId", survey.ReviewerEmpId); 
            cmd.Parameters.AddWithValue("@SubjectEmpId", survey.SubjectEmpId); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void DeleteSurvey(Survey value){ //Method for removing an individual survey
            string cs;
            try
            {
                cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\API\Database\TAS.db";
            }
            catch (FileNotFoundException e) //Error Check
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong.....survey was not deleted. {0}", e);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            using var con= new SQLiteConnection(cs);
            con.Open(); //Open a connection to the database

            using var cmd= new SQLiteCommand(con);

            cmd.CommandText=$@"DELETE FROM Survey WHERE SurveyId={value.SurveyId}"; //Remove the survey that the user specified
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void EditSurvey(Survey Value){
            string cs = @"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\API\Database\TAS.db";
                using var con = new SQLiteConnection(cs);
                con.Open();

                using var cmd= new SQLiteCommand(con);

                cmd.CommandText=$@"UPDATE Survey SET Cycle=@Cycle, DateDue=@DateDue, BeenCompleted=@BeenCompleted, DateCompleted=@DateCompleted, ReviewerEmpId=@ReviewerEmpId, SubjectEmpId=@SubjectEmpId WHERE SurveyId={Value.SurveyId}"; //Edits existing post in the database
                cmd.Parameters.AddWithValue("@Cycle", Value.Cycle);
                cmd.Parameters.AddWithValue("@DateDue", Value.DateDue); 
                cmd.Parameters.AddWithValue("@BeenCompleted", Value.BeenCompleted); 
                cmd.Parameters.AddWithValue("@DateCompleted", Value.DateCompleted); 
                cmd.Parameters.AddWithValue("@ReviewerEmpId", Value.ReviewerEmpId); 
                cmd.Parameters.AddWithValue("@SubjectEmpId", Value.SubjectEmpId); 
                cmd.Prepare();
                cmd.ExecuteNonQuery(); 
        }
    }
}