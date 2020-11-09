using System.Data.SQLite;
using System.Collections.Generic;
using System;
using System.IO;
using TAS_Project.Interfaces;

namespace TAS_Project.Models
{
    public class SeedQuestionData : ISeedData
    {
        public void SeedData(){ //Method for Reseeding all the Question Data
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

            cmd.CommandText = "DROP TABLE IF EXISTS Question"; //Deletes any pre-existing tables
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"CREATE TABLE Question(QuestionId INTEGER PRIMARY KEY, QuestionText TEXT, QuestionRequired BOOLEAN, AnswerRequired BOOLEAN, AllowMultipleAnswers BOOLEAN, QuestionCategory TEXT, InputTypeId INTEGER, FOREIGN KEY(InputTypeId) REFERENCES InputType(InputTypeId))"; //Creates a new table
            cmd.ExecuteNonQuery();

            //Resets the database to the original.
            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "1"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Actively contributes as a team member to achieve results");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Collaboration"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "2"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Encourages collaboration among the team members");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Collaboration"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "3"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Establishes and maintains effective working relationships within his/her team");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Collaboration"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "4"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Maintains smooth, effective working relationships");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Collaboration"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "5"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Proactively stimulates ideas and discussion, openly sharing all relevant information");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Collaboration"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "6"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Shares relevant data with members of cross-functional teams");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Collaboration"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "7"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Works effectively as a member of informal teams or groups");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Collaboration"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "8"); 
            cmd.Parameters.AddWithValue("@QuestionText", "What suggestions do you have to help this employee improve his/her collaboration?");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "0"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Collaboration"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "2"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "9"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Communicates clearly, concisely and in an organized manner");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Communication"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "10"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Effectively shares the rationale behind his/her decisions/conclusions");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Communication"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "11"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Encourages open and candid communications");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Communication"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "12"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Gears communication to the audience and uses the appropriate level of detail");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Communication"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();            

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "13"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Handles conflict effectively");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Communication"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery(); 

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "14"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Listens effectively");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Communication"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "15"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Seeks to understand others views and priorities");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Communication"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "16"); 
            cmd.Parameters.AddWithValue("@QuestionText", "What suggestions do you have to help this employee improve his/her communication?");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "0"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Communication"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "2"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "17"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Anticipates and addresses emerging customer needs");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Customer Focus"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "18"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Clearly communicates customer needs/requirements");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Customer Focus"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "19"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Demonstrates a customer service focus within the organization");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Customer Focus"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "20"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Listens carefully to customers to determine their goals, needs and expectations");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Customer Focus"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "21"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Readily readjusts priorities to respond to pressing and changing customer demands");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Customer Focus"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "22"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Responds quickly to customer issues to ensure their satisfaction with outcomes");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Customer Focus"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "23"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Uses knowledge and information about customer experience to improve service");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Customer Focus"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "24"); 
            cmd.Parameters.AddWithValue("@QuestionText", "What suggestions do you have to help this employee improve his/her customer focus?");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "0"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Customer Focus"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "2"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "25"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Follows through on assignments");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Productivity"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "26"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Handles day-to-day work challenges confidently and routinely");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Productivity"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "27"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Has high performance standards and expectations");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Productivity"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "28"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Identifies and implements opportunities to save time, effort and money");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Productivity"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "29"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Knowledgeable in all areas of assigned job responsibilities");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Productivity"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "30"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Produces high volumes of meaningful results in an efficient and timely manner");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Productivity"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "31"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Works with a sense of urgency and deliberate speed to accomplish quality results");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Productivity"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "32"); 
            cmd.Parameters.AddWithValue("@QuestionText", "What suggestions do you have to help this employee improve his/her productivity?");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "0"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Productivity"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "2"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "33"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Accepts responsibility for his/her mistakes");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Integrity"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "34"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Consistently treats others with respect");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Integrity"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "35"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Creates trust through honest and consistent behaviors");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Integrity"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "36"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Gives praise and credit to others where due");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Integrity"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "37"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Keeps sensitive and personal information confidential");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Integrity"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "38"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Respectful of gender and cultural differences");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Integrity"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "39"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Treats others fairly and ethically");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Integrity"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "40"); 
            cmd.Parameters.AddWithValue("@QuestionText", "What suggestions do you have to help this employee improve his/her integrity?");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "0"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Integrity"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "2"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "41"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Applies knowledge, skills and experience in ways that result in effective decisions");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Problem Solving"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "42"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Considers a broad range of issues or factors in making decisions");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Problem Solving"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "43"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Demonstrates creativity in problem solving");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Problem Solving"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "44"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Seeks input and information from others when appropriate");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Problem Solving"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "45"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Generates innovative ideas and solutions to problems");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Problem Solving"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "46"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Is a creative thinker");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Problem Solving"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "47"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Pursues new ways to approach issues and solve problems");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Problem Solving"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "48"); 
            cmd.Parameters.AddWithValue("@QuestionText", "What suggestions do you have to help this employee improve his/her problem solving?");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "0"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Problem Solving"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "2"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "49"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Accepts responsibility for own mistakes");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Self Leadership"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "50"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Actively requests feedback for personal improvement");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Self Leadership"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "51"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Eagerly pursues new knowledge, skills, and methods");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Self Leadership"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "52"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Is open, flexible and prepared to learn");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Self Leadership"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "53"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Knows own strengths and limitations");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Self Leadership"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "54"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Manages his/her own emotions appropriately");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Self Leadership"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "55"); 
            cmd.Parameters.AddWithValue("@QuestionText", "Shows empathy in dealing with others");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "1"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Self Leadership"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "56"); 
            cmd.Parameters.AddWithValue("@QuestionText", "What suggestions do you have to help this employee improve his/her self leadership?");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "0"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Self Leadership"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "2"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "57"); 
            cmd.Parameters.AddWithValue("@QuestionText", "What do you value most about working with this person?");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "0"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Open Ended"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "2"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO Question(QuestionId, QuestionText, QuestionRequired, AnswerRequired, AllowMultipleAnswers, QuestionCategory, InputTypeId) VALUES(@QuestionId, @QuestionText, @QuestionRequired, @AnswerRequired, @AllowMultipleAnswers, @QuestionCategory, @InputTypeId)";
            cmd.Parameters.AddWithValue("@QuestionId", "58"); 
            cmd.Parameters.AddWithValue("@QuestionText", "What would make this person more effective in their job?");
            cmd.Parameters.AddWithValue("@QuestionRequired", "1"); 
            cmd.Parameters.AddWithValue("@AnswerRequired", "1"); 
            cmd.Parameters.AddWithValue("@AllowMultipleAnswers", "0"); 
            cmd.Parameters.AddWithValue("@QuestionCategory", "Open Ended"); 
            cmd.Parameters.AddWithValue("@InputTypeId", "2"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}