namespace TAS_Project.Database
{
    public interface IReadInputChoicesData
    {
         public List<InputChoices> GetAllInputChoices();
         public InputChoices GetInputChoice(int InputChoiceId);
    }
}