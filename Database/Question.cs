namespace TAS_Project.Database
{
    public class Question
    {
        public int QstId {get;set;}
        public string QstText {get;set;}
        public bool QstRequired {get;set;}
        public bool AnsRequired {get;set;}
        public bool AllowMultipleAnswers {get;set;}
        public string QstCategory {get;set;}
        public int InputType {get;set;}

        public Question(){

        }
        public void SetQuestionLevel(){
            
        }
        public void ShowQuestion(){
            
        }
    }
}