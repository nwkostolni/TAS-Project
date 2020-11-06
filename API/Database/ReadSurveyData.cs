using System.Collections.Generic;
using System.Data.SQLite;

namespace TAS_Project.Database
{
    public class ReadSurveyData : IReadSurveyData
    {
            public List<Survey> GetAllSurveys(){
            string cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\Database\TAS.db";
            using var con = new SQLiteConnection(cs);
           con.Open();
           string stm = "SELECT * FROM survey";
           using var cmd = new SQLiteCommand(stm, con);
           
           using SQLiteDataReader rdr = cmd.ExecuteReader();
            List<Survey> allSurveys = new List<Survey>();
           while(rdr.Read())
           {
                
                allSurveys.Add(new Survey(){SurveyId=rdr.GetInt32(0), Cycle =rdr.GetString(1),ReviewerEmpId=rdr.GetInt31(2), SubjectEmpId=rdr.GetString(3),DateDue=rdr.GetDateTime(4), BeenCompleted=rdr.GetDateTime(5),DateCompleted=rdr.GetDateTime(6) });
           }
           return allSurveys;
        }

        public Survey GetSurvey(int id)
        {
            string cs = @"URI=file:C:\Users\snibb\source\repos\MIS321\TAS-Project\Database\survey.db";
            using var con = new SQLiteConnection(cs);
            con.Open();
            string stm = "SELECT * FROM survey WHERE id =@id";
            using var cmd = new SQLiteCommand(stm, con);
        
            cmd.Parameters.AddWithValue("@id",id);  
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            return new Survey(){SurveyId=rdr.GetInt32(0),Cycle =rdr.GetString(1),ReviewerEmpId=rdr.GetInt31(2), SubjectEmpId=rdr.GetString(3),DateDue=rdr.GetDateTime(4), BeenCompleted=rdr.GetDateTime(5),DateCompleted=rdr.GetDateTime(6),};
        }

        
    }
}