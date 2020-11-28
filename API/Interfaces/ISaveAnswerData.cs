using TAS_Project.Models;

namespace TAS_Project.Interfaces
{
    public interface ISaveAnswerData
    {
        public void UpdateAnswer(Answer value);
        public void AddAnswers(Answer[] arrayOfAnswers);
    }
}