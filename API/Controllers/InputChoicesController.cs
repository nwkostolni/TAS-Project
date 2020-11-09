using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAS_Project.Models;
using TAS_Project.Interfaces;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputChoicesController : ControllerBase
    {
        // GET: api/InputChoices
        [HttpGet]
        public List<InputChoices> Get()
        {
            IReadInputChoicesData readObject = new ReadInputChoicesData();
            return readObject.GetAllInputChoices();
        }

        // GET: api/InputChoices/5
        [HttpGet("{id}", Name = "GetInputChoices")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/InputChoices
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/InputChoices/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
