namespace TAS_Project.Database
{
    public class Survey
    {
        public int SurveyId {get;set;}
        public string Cycle  {get;set;}
        public int ReviewerEmpId {get;set;}
        public int SubjectEmpId {get;set;}
        public DateTime DateDue {get;set;}
        public bool BeenCompleted {get;set;}
        public DateTime DateCompleted {get;set;}

        public Survey(){

        }

        public List<Question> CreateQuestionList(){
            
        }
    }
}