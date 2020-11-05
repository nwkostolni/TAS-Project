namespace TAS_Project.Database
{
    public class SaveSurveyData : ISaveSurveyData
    {
        public void SaveAllSurveys()
        {
            public void SaveSurveys(Surveys survey){ //Method for saving survey data
            string cs;
            try
            {
                cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\Database\TAS.db";
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
            cmd.Parameters.AddWithValue("@DateDue", survey.DateDue); 
            cmd.Parameters.AddWithValue("@BeenCompleted", survey.BeenCompleted); 
            cmd.Parameters.AddWithValue("@DateCompleted", survey.DateCompleted); 
            cmd.Parameters.AddWithValue("@ReviewerEmpId", survey.ReviewerEmpId); 
            cmd.Parameters.AddWithValue("@SubjectEmpId", survey.SubjectEmpId); 
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            
        }
    }
}