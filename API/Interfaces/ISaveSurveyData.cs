using System.Collections.Generic;
using TAS_Project.Models;

namespace TAS_Project.Interfaces
{
    public interface ISaveSurveyData
    {
        public void UpdateSurveys(Survey value);
        public void DeleteSurvey(Survey value);
    }
}