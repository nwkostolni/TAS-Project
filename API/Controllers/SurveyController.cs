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
    public class SurveyController : ControllerBase
    {
        // GET: api/Survey
        [HttpGet]
        public List<Survey> Get()
        {
            IReadSurveyData readObject = new ReadSurveyData();
            return readObject.GetAllSurveys();
        }

        // GET: api/Survey/5
        [HttpGet("{id}", Name = "GetSurvey")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Survey
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Survey/5
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
