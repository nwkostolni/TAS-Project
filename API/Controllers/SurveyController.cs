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
    public class SurveyController : ControllerBase
    {
        // GET: api/Survey
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Survey> Get()
        {
            IReadSurveyData readObject = new ReadSurveyData();
            return readObject.GetAllSurveys();
        }

        // GET: api/Survey/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetSurvey")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Survey
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Survey/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete]
        public void Delete([FromBody] Survey value)
        {
            ISaveSurveyData deleteObject = new SaveSurveyData();
            deleteObject.DeleteSurvey(value);
        }
    }
}
