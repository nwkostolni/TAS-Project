namespace TAS_Project.Models
{
    public class Question
    {
        public int QstId {get;set;}
        public string QstText {get;set;}
        public bool QstRequired {get;set;}
        public bool AnsRequired {get;set;}
        public bool AllowMultipleAnswers {get;set;}
        public string QstCategory {get;set;}
        public int InputTypeId {get;set;}

        public Question(){

        }
    }
}