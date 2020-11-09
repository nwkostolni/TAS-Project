using System.Xml.Schema;
using System.Collections.Generic;
using TAS_Project.Models;

namespace TAS_Project.Interfaces
{
    public interface IReadEmpData
    {
         public List<Employee> GetAllEmployees();
         
    }
}