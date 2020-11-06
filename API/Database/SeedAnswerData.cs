using System.Data.SQLite;
using System.Collections.Generic;
using System;
using System.IO;

namespace TAS_Project.Database
{
    public class SeedAnswerData : ISeedData
    {
        public void SeedData(){ //Method for Reseeding all the Answer Data
            string cs;
            try
            {
                cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\Database\TAS.db";
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

            cmd.CommandText = "DROP TABLE IF EXISTS Answer"; //Deletes any pre-existing tables
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"CREATE TABLE Answer(AnswerId INTEGER PRIMARY KEY, AnswerNumeric INTEGER, AnswerText TEXT, SurveyId INTEGER, InputChoiceId INTEGER, QuestionId INTEGER, FOREIGN KEY(SurveyId) REFERENCES Survey(SurveyId), FOREIGN KEY(InputChoiceId) REFERENCES InputChoices(InputChoiceId), FOREIGN KEY(QuestionId) REFERENCES Question(QuestionId))"; //Creates a new table
            cmd.ExecuteNonQuery();

            //Resets the database to the original.
            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "1"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "5");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "5");
            cmd.Parameters.AddWithValue("@QuestionId", "1");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "2"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "4");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "4");
            cmd.Parameters.AddWithValue("@QuestionId", "2");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "3"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "4");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "4");
            cmd.Parameters.AddWithValue("@QuestionId", "3");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "4"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "5");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "5");
            cmd.Parameters.AddWithValue("@QuestionId", "4");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "5"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "3");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "3");
            cmd.Parameters.AddWithValue("@QuestionId", "5");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "6"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "4");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "4");
            cmd.Parameters.AddWithValue("@QuestionId", "6");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "7"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "2");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "2");
            cmd.Parameters.AddWithValue("@QuestionId", "7");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "8"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "");
            cmd.Parameters.AddWithValue("@AnswerText", "Lorem ipsum dolor sit amet");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "6");
            cmd.Parameters.AddWithValue("@QuestionId", "8");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "9"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "4");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "4");
            cmd.Parameters.AddWithValue("@QuestionId", "9");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "10"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "5");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "5");
            cmd.Parameters.AddWithValue("@QuestionId", "10");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "11"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "4");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "4");
            cmd.Parameters.AddWithValue("@QuestionId", "11");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "12"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "5");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "5");
            cmd.Parameters.AddWithValue("@QuestionId", "12");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "13"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "3");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "3");
            cmd.Parameters.AddWithValue("@QuestionId", "13");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "14"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "5");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "5");
            cmd.Parameters.AddWithValue("@QuestionId", "14");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "15"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "3");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "3");
            cmd.Parameters.AddWithValue("@QuestionId", "15");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "16"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "");
            cmd.Parameters.AddWithValue("@AnswerText", "Lorem ipsum dolor sit amet");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "6");
            cmd.Parameters.AddWithValue("@QuestionId", "16");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "17"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "5");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "5");
            cmd.Parameters.AddWithValue("@QuestionId", "17");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "18"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "4");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "4");
            cmd.Parameters.AddWithValue("@QuestionId", "18");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "19"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "4");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "4");
            cmd.Parameters.AddWithValue("@QuestionId", "19");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "20"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "5");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "5");
            cmd.Parameters.AddWithValue("@QuestionId", "20");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "21"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "3");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "3");
            cmd.Parameters.AddWithValue("@QuestionId", "21");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "22"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "4");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "4");
            cmd.Parameters.AddWithValue("@QuestionId", "22");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "23"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "2");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "2");
            cmd.Parameters.AddWithValue("@QuestionId", "23");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "24"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "");
            cmd.Parameters.AddWithValue("@AnswerText", "Lorem ipsum dolor sit amet");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "6");
            cmd.Parameters.AddWithValue("@QuestionId", "24");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "25"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "4");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "4");
            cmd.Parameters.AddWithValue("@QuestionId", "25");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "26"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "5");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "5");
            cmd.Parameters.AddWithValue("@QuestionId", "26");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "27"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "4");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "4");
            cmd.Parameters.AddWithValue("@QuestionId", "27");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "28"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "5");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "5");
            cmd.Parameters.AddWithValue("@QuestionId", "28");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "29"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "3");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "3");
            cmd.Parameters.AddWithValue("@QuestionId", "29");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "30"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "5");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "5");
            cmd.Parameters.AddWithValue("@QuestionId", "30");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "31"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "3");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "3");
            cmd.Parameters.AddWithValue("@QuestionId", "31");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "32"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "");
            cmd.Parameters.AddWithValue("@AnswerText", "Lorem ipsum dolor sit amet");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "6");
            cmd.Parameters.AddWithValue("@QuestionId", "32");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "33"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "5");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "5");
            cmd.Parameters.AddWithValue("@QuestionId", "33");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "34"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "4");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "4");
            cmd.Parameters.AddWithValue("@QuestionId", "34");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "35"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "4");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "4");
            cmd.Parameters.AddWithValue("@QuestionId", "35");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "36"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "5");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "5");
            cmd.Parameters.AddWithValue("@QuestionId", "36");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "37"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "3");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "3");
            cmd.Parameters.AddWithValue("@QuestionId", "37");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "38"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "4");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "4");
            cmd.Parameters.AddWithValue("@QuestionId", "38");
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Answer(AnswerId, AnswerNumeric, AnswerText, SurveyId, InputChoiceId, QuestionId) VALUES(@AnswerId, @AnswerNumeric, @AnswerText, @SurveyId, @InputChoiceId, @QuestionId)";
            cmd.Parameters.AddWithValue("@AnswerId", "39"); 
            cmd.Parameters.AddWithValue("@AnswerNumeric", "2");
            cmd.Parameters.AddWithValue("@AnswerText", "");
            cmd.Parameters.AddWithValue("@SurveyId", "1");
            cmd.Parameters.AddWithValue("@InputChoiceId", "2");
            cmd.Parameters.AddWithValue("@QuestionId", "39");
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}