using TAS_Project.Models;
using System.Collections.Generic;

namespace TAS_Project.Interfaces
{
    public interface IReadAnsData
    {
         public List<Answer> GetAllAnswers();
         public Answer GetAnswer(int AnsId);
    }
}