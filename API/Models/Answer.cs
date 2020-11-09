
namespace TAS_Project.Models
{
    public class Answer
    {
        public int AnsId {get;set;}
        public int AnsNumeric {get;set;}
        public string AnsText {get;set;}
        public int SurveyId {get;set;}
        public int InputChoiceId {get;set;}
        public int QstId {get;set;}



        public Answer()
        {

        }
    }
}