using System.Data.SQLite;
using System.Collections.Generic;
using System;
using System.IO;
using TAS_Project.Interfaces;

namespace TAS_Project.Models
{
    public class SeedSurveyData : ISeedData
    {
        public void SeedData(){ //Method for Reseeding all the Survey Data
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

            cmd.CommandText = "DROP TABLE IF EXISTS Survey"; //Deletes any pre-existing tables
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"CREATE TABLE Survey(SurveyId INTEGER PRIMARY KEY, Cycle TEXT, DateDue TEXT, BeenCompleted BOOLEAN, DateCompleted TEXT, ReviewerEmpId INTEGER, SubjectEmpId INTEGER, FOREIGN KEY(ReviewerEmpId) REFERENCES Employee(EmployeeId), FOREIGN KEY(SubjectEmpId) REFERENCES Employee(EmployeeId))"; //Creates a new table
            cmd.ExecuteNonQuery();

            //Resets the database to the original.
            cmd.CommandText=@"INSERT INTO Survey(SurveyId, Cycle, DateDue, BeenCompleted, DateCompleted, ReviewerEmpId, SubjectEmpId) VALUES(@SurveyId, @Cycle, @DateDue, @BeenCompleted, @DateCompleted, @ReviewerEmpId, @SubjectEmpId)";
            cmd.Parameters.AddWithValue("@SurveyId", "1"); 
            cmd.Parameters.AddWithValue("@Cycle", "Fall 2020");
            cmd.Parameters.AddWithValue("@DateDue", "2020-12-01 00:00:00.000"); 
            cmd.Parameters.AddWithValue("@BeenCompleted", "1"); 
            cmd.Parameters.AddWithValue("@DateCompleted", "2020-11-05 00:00:00.000"); 
            cmd.Parameters.AddWithValue("@ReviewerEmpId", "17"); 
            cmd.Parameters.AddWithValue("@SubjectEmpId", "17"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Survey(SurveyId, Cycle, DateDue, BeenCompleted, DateCompleted, ReviewerEmpId, SubjectEmpId) VALUES(@SurveyId, @Cycle, @DateDue, @BeenCompleted, @DateCompleted, @ReviewerEmpId, @SubjectEmpId)";
            cmd.Parameters.AddWithValue("@SurveyId", "2"); 
            cmd.Parameters.AddWithValue("@Cycle", "Fall 2020");
            cmd.Parameters.AddWithValue("@DateDue", "2020-12-01 00:00:00.000"); 
            cmd.Parameters.AddWithValue("@BeenCompleted", "1"); 
            cmd.Parameters.AddWithValue("@DateCompleted", "2020-11-06 00:00:00.000"); 
            cmd.Parameters.AddWithValue("@ReviewerEmpId", "18"); 
            cmd.Parameters.AddWithValue("@SubjectEmpId", "17"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Survey(SurveyId, Cycle, DateDue, BeenCompleted, DateCompleted, ReviewerEmpId, SubjectEmpId) VALUES(@SurveyId, @Cycle, @DateDue, @BeenCompleted, @DateCompleted, @ReviewerEmpId, @SubjectEmpId)";
            cmd.Parameters.AddWithValue("@SurveyId", "3"); 
            cmd.Parameters.AddWithValue("@Cycle", "Fall 2020");
            cmd.Parameters.AddWithValue("@DateDue", "2020-12-01 00:00:00.000"); 
            cmd.Parameters.AddWithValue("@BeenCompleted", "0"); 
            cmd.Parameters.AddWithValue("@DateCompleted", ""); 
            cmd.Parameters.AddWithValue("@ReviewerEmpId", "15"); 
            cmd.Parameters.AddWithValue("@SubjectEmpId", "17"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Survey(SurveyId, Cycle, DateDue, BeenCompleted, DateCompleted, ReviewerEmpId, SubjectEmpId) VALUES(@SurveyId, @Cycle, @DateDue, @BeenCompleted, @DateCompleted, @ReviewerEmpId, @SubjectEmpId)";
            cmd.Parameters.AddWithValue("@SurveyId", "4"); 
            cmd.Parameters.AddWithValue("@Cycle", "Fall 2020");
            cmd.Parameters.AddWithValue("@DateDue", "2020-12-01 00:00:00.000"); 
            cmd.Parameters.AddWithValue("@BeenCompleted", "0"); 
            cmd.Parameters.AddWithValue("@DateCompleted", ""); 
            cmd.Parameters.AddWithValue("@ReviewerEmpId", "10"); 
            cmd.Parameters.AddWithValue("@SubjectEmpId", "17"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Survey(SurveyId, Cycle, DateDue, BeenCompleted, DateCompleted, ReviewerEmpId, SubjectEmpId) VALUES(@SurveyId, @Cycle, @DateDue, @BeenCompleted, @DateCompleted, @ReviewerEmpId, @SubjectEmpId)";
            cmd.Parameters.AddWithValue("@SurveyId", "5"); 
            cmd.Parameters.AddWithValue("@Cycle", "Fall 2020");
            cmd.Parameters.AddWithValue("@DateDue", "2020-12-01 00:00:00.000"); 
            cmd.Parameters.AddWithValue("@BeenCompleted", "0"); 
            cmd.Parameters.AddWithValue("@DateCompleted", ""); 
            cmd.Parameters.AddWithValue("@ReviewerEmpId", "8"); 
            cmd.Parameters.AddWithValue("@SubjectEmpId", "17"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}