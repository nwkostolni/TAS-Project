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
    public class InputTypeController : ControllerBase
    {
        // GET: api/InputType
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<InputType> Get()
        {
            IReadInputTypeData readObject = new ReadInputTypeData();
            return readObject.GetAllInputTypes();
        }

        // GET: api/InputType/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetInputType")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/InputType
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/InputType/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
