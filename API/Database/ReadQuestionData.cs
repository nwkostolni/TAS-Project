namespace TAS_Project.Database
{
    public class ReadQuestionData :IReadQuestionData
    {
        public List<Question> GetAllQuestions(){
            string cs =@"URI=file:C:\Users\snibb\source\repos\MIS321\TAS-Project\Database\questions.db";
            using var con = new SQLiteConnection(cs);
           con.Open();
           string stm = "SELECT * FROM questions";
           using var cmd = new SQLiteCommand(stm, con);
           
           using SQLiteDataReader rdr = cmd.ExecuteReader();
            List<Question> allQuestions = new List<Question>();
           while(rdr.Read())
           {
               allQuestions.Add(new Question(){QstId=rdr.GetInt32(0), QstText= rdr.GetString(1),QstRequired= rdr.GetBool(2), AnsRequired=rdr.GetBool(3), AllowMultipleAnswers=rdr.GetBool(4), QstCategory=rdr.GetString(5),InputType= rdr.GetInt32(6)});

           }
           return allQuestions;
        }
    }
}