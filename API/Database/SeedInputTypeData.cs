using System.Data.SQLite;
using System.Collections.Generic;
using System;
using System.IO;

namespace TAS_Project.Database
{
    public class SeedInputTypeData : ISeedData
    {
        public void SeedData(){ //Method for Reseeding all the Input Types
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

            cmd.CommandText = "DROP TABLE IF EXISTS InputType"; //Deletes any pre-existing tables
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"CREATE TABLE InputType(InputTypeId INTEGER PRIMARY KEY, InputTypeName TEXT)"; //Creates a new table
            cmd.ExecuteNonQuery();

            //Resets the database to the original 2 types.
            cmd.CommandText=@"INSERT INTO InputType(InputTypeId, InputTypeName) VALUES(@InputTypeId, @InputTypeName)";
            cmd.Parameters.AddWithValue("@InputTypeId", "1"); 
            cmd.Parameters.AddWithValue("@InputTypeName", "Rating Scale"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText=@"INSERT INTO InputType(InputTypeId, InputTypeName) VALUES(@InputTypeId, @InputTypeName)";
            cmd.Parameters.AddWithValue("@InputTypeId", "2");
            cmd.Parameters.AddWithValue("@InputTypeName", "Open Ended"); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}