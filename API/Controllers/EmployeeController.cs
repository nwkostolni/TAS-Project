using System.Threading;
using System.Security.AccessControl;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAS_Project.Models;
using TAS_Project.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/Employee
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Employee> Get()
        {
            IReadEmpData readObject = new ReadEmpData();
            return readObject.GetAllEmployees();
        }

        // GET: api/Employee/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetEmployee")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        [EnableCors("AnotherPolicy")]
        [HttpPost] 
        public void Post([FromBody] Employee value)
        {
            ISaveEmpData insertObject = new SaveEmpData();
            insertObject.UpdateEmployee(value);
        }

        // PUT: api/Employee/5
        [EnableCors("AnotherPolicy")]
        [HttpPut]
        public void Put([FromBody] Employee value)
        {
            ISaveEmpData editObject = new SaveEmpData();
            editObject.EditEmployee(value);
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete]
        public void Delete([FromBody] Employee value)
        {
            ISaveEmpData deleteObject = new SaveEmpData();
            deleteObject.DeleteEmployee(value);
        }
    }
}
