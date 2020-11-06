namespace TAS_Project.Database
{
    public class ReadAnswerData
    {
        public List<Answers> GetAllAnswers()
        {
            List <Answers> allAnswers = new List<Answers>();
            string cs;
            try
            {
                cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\TAS-Project\Database\TAS.db"; 
            }
            catch (FileNotFoundException e) //Error Check
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong.....returning blank list. {0}", e);
                Console.ForegroundColor = ConsoleColor.White;
                return allInputChoices;
            }
            using var con = new SQLiteConnection(cs);
            con.Open();
             string stm = "SELECT * FROM Answers"; //Pulls the data from the table
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();
            
            while(rdr.Read()){ //Reads in each new row of data
                Answers temp = new Answers(){AnsId=rdr.GetInt32(0), QstId=GetInt32(1),AnsNumeric =GetInt32(2) ,AnsText =GetInt32(3),InputChoiceId= GetInt32(4),SurveyId= GetInt32(5)};
                allAnswers.Add(temp);
                               
            }
            return allAnswers;


        }
        public Answer GetAnswer(int AnsId)
        {
            string cs;
            try
            {
                cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\pa4-hdpetty-1\API\Models\posts.db"; //NEEDS TO BE UPDATED
            }
            catch (FileNotFoundException e) //Error Check
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong.....returning nothing. {0}", e);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            using var con=new SQLiteConnection(cs);
            con.Open();

            string stm= "SELECT * FROM InputChoices WHERE AnsId=@id";
            using var cmd=new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", ansId);
            cmd.Prepare();
            using SQLiteDataReader reader=cmd.ExecuteReader();

            reader.Read();
            return new Answer(){AnsId=rdr.GetInt32(0), QstId=GetInt32(1),AnsNumeric =GetInt32(2) ,AnsText =GetInt32(3),InputChoiceId= GetInt32(4),SurveyId= GetInt32(5)};
        }
        
    }
}