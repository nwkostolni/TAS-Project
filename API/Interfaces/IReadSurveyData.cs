using System.Collections.Generic;
using TAS_Project.Models;

namespace TAS_Project.Interfaces
{
    public interface IReadSurveyData
    {
         public List<Survey> GetAllSurveys();
    }
}