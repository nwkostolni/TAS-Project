using System.Security.AccessControl;
using System.Collections.Generic;
using TAS_Project.Models;

namespace TAS_Project.Interfaces
{
    public interface IReadInputChoicesData
    {
         public List<InputChoices> GetAllInputChoices();
         public InputChoices GetInputChoice(int InputChoiceId);
    }
}