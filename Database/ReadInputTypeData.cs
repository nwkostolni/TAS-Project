namespace TAS_Project.Database
{
    public class ReadInputTypeData : IReadInputTypeData
    {
        public List<InputType> GetAllInputTypes(){
            List<InputType> allInputType = new List<InputType>();
            string cs;
            try
            {
                cs =@"URI=file:C:\Users\hnnhp\source\repos\MIS 321\pa4-hdpetty-1\API\Models\posts.db"; //NEEDS TO BE UPDATED
            }
            catch (FileNotFoundException e) //Error Check
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong.....returning blank list. {0}", e);
                Console.ForegroundColor = ConsoleColor.White;
                return allInputType;
            }
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM InputType"; //Pulls the data from the table
            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();
            
            while(rdr.Read()){ //Reads in each new row of data
                InputType temp= new InputType(){InputTypeId=rdr.GetInt32(0), InputTypeName=rdr.GetString(1)};
                allInputType.Add(temp);
            }

            return allInputType; //Returns a list containing the data from the database
        }
        public InputType GetInputType(int InputTypeId){
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

            string stm= "SELECT * FROM InputType WHERE InputTypeId=@id";
            using var cmd=new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", InputTypeId);
            cmd.Prepare();
            using SQLiteDataReader reader=cmd.ExecuteReader();

            reader.Read();
            return new InputType(){InputTypeId=rdr.GetInt32(0), InputTypeName=rdr.GetString(1)};
        }
    }
}