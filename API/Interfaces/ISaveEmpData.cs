using System.Collections.Generic;
using TAS_Project.Models;

namespace TAS_Project.Interfaces
{
    public interface ISaveEmpData
    {
         public void UpdateEmployee(Employee value);
         public void DeleteEmployee(Employee value);
         public void EditEmployee(Employee Value);
    }
}