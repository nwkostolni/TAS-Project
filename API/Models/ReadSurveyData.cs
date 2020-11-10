using System.Runtime.Serialization;
using System.Resources;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.AccessControl;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Threading;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Data.SQLite;
using TAS_Project.Interfaces;
using System;

namespace TAS_Project.Models
{
    public class ReadSurveyData : IReadSurveyData
    {
        public List<Survey> GetAllSurveys(){
            string cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\API\Database\TAS.db";
            using var con = new SQLiteConnection(cs);
           con.Open();
           string stm = "SELECT * FROM Survey";
           using var cmd = new SQLiteCommand(stm, con);
           
           using SQLiteDataReader rdr = cmd.ExecuteReader();
            List<Survey> allSurveys = new List<Survey>();
           while(rdr.Read())
           {
                DateTime ? temp = new DateTime();
                if(rdr.IsDBNull(4)){
                    temp=null;
                }
                else{
                    temp=DateTime.Parse(rdr.GetString(4));
                }
                allSurveys.Add(new Survey(){SurveyId = rdr.GetInt32(0), Cycle = rdr.GetString(1), ReviewerEmpId = rdr.GetInt32(5), SubjectEmpId = rdr.GetInt32(6), DateDue = DateTime.Parse(rdr.GetString(2)), BeenCompleted = rdr.GetBoolean(3), DateCompleted=temp});
           }
           return allSurveys;
        }

        public Survey GetSurvey(int id)
        {
            string cs = @"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\API\Database\TAS.db";
            using var con = new SQLiteConnection(cs);
            con.Open();
            string stm = "SELECT * FROM survey WHERE id =@id";
            using var cmd = new SQLiteCommand(stm, con);
        
            cmd.Parameters.AddWithValue("@id",id);  
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            return new Survey(){SurveyId=rdr.GetInt32(0), Cycle =rdr.GetString(1), ReviewerEmpId=rdr.GetInt32(2), SubjectEmpId=rdr.GetInt32(3), DateDue = DateTime.Parse(rdr.GetString(4)), BeenCompleted=rdr.GetBoolean(5), DateCompleted = DateTime.Parse(rdr.GetString(6))};
        }

        
    }
}