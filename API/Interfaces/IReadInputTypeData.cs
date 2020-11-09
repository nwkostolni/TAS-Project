using System.Security.AccessControl;
using System.Collections.Generic;
using TAS_Project.Models;

namespace TAS_Project.Interfaces
{
    public interface IReadInputTypeData
    {
         public List<InputType> GetAllInputTypes();
         public InputType GetInputType(int InputTypeId);
    }
}