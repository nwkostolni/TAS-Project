namespace TAS_Project.Database
{
    public class SaveAnswerData : ISaveAnswerData
    {
        public void SaveAllAnswers(){
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
             
             using var cmd= new SQLiteCommand(con);
            
        
            cmd.CommandText=@"INSERT INTO Answers(QstId,AnsNumeric,AnsText,InputChoiceId,SurveyId)"
            cmd.Parameters.AddWithValue("qstid",  answer.qstid );
            cmd.Parameters.AddWithValue(" 
       
        } 

    }
}