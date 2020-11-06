namespace TAS_Project.Database
{
    public interface IReadInputTypeData
    {
         public List<InputType> GetAllInputTypes();
         public InputType GetInputType(int InputTypeId);
    }
}