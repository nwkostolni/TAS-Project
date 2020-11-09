using System.Data.SQLite;
using System.Collections.Generic;
using System;
using System.IO;
using TAS_Project.Interfaces;

namespace TAS_Project.Models
{
    public class SeedInputChoicesData :ISeedData 
    {
        public void SeedData(){ //Method for Reseeding all the Input Choices
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

            cmd.CommandText = "DROP TABLE IF EXISTS InputChoices"; //Deletes any pre-existing tables
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"CREATE TABLE InputChoices(InputChoiceId INTEGER PRIMARY KEY, InputChoiceName TEXT, InputTypeId INTEGER, FOREIGN KEY(InputTypeId) REFERENCES InputType(InputTypeId))"; //Creates a new table
            cmd.ExecuteNonQuery();

            //Resets the database to the original.
            cmd.CommandText=@"INSERT INTO InputChoices(InputChoiceId, InputChoiceName, InputTypeId) VALUES(@InputChoiceId, @InputChoiceName, @InputTypeId)";
            cmd.Parameters.AddWithValue("@InputChoiceId", "1"); 
            cmd.Parameters.AddWithValue("@InputChoiceName", "Always");
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO InputChoices(InputChoiceId, InputChoiceName, InputTypeId) VALUES(@InputChoiceId, @InputChoiceName, @InputTypeId)";
            cmd.Parameters.AddWithValue("@InputChoiceId", "2"); 
            cmd.Parameters.AddWithValue("@InputChoiceName", "Often");
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO InputChoices(InputChoiceId, InputChoiceName, InputTypeId) VALUES(@InputChoiceId, @InputChoiceName, @InputTypeId)";
            cmd.Parameters.AddWithValue("@InputChoiceId", "3"); 
            cmd.Parameters.AddWithValue("@InputChoiceName", "Sometimes");
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO InputChoices(InputChoiceId, InputChoiceName, InputTypeId) VALUES(@InputChoiceId, @InputChoiceName, @InputTypeId)";
            cmd.Parameters.AddWithValue("@InputChoiceId", "4"); 
            cmd.Parameters.AddWithValue("@InputChoiceName", "Rarely");
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO InputChoices(InputChoiceId, InputChoiceName, InputTypeId) VALUES(@InputChoiceId, @InputChoiceName, @InputTypeId)";
            cmd.Parameters.AddWithValue("@InputChoiceId", "5"); 
            cmd.Parameters.AddWithValue("@InputChoiceName", "Never");
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO InputChoices(InputChoiceId, InputChoiceName, InputTypeId) VALUES(@InputChoiceId, @InputChoiceName, @InputTypeId)";
            cmd.Parameters.AddWithValue("@InputChoiceId", "6"); 
            cmd.Parameters.AddWithValue("@InputChoiceName", "Open Ended");
            cmd.Parameters.AddWithValue("@InputTypeId", "2"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}