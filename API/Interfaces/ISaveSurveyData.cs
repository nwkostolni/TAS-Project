using System.Collections.Generic;
using TAS_Project.Models;

namespace TAS_Project.Interfaces
{
    public interface ISaveSurveyData
    {
        public void UpdateSurvey(Survey value);
        public void DeleteSurvey(Survey value);
        public void EditSurvey(Survey value);
    }
}