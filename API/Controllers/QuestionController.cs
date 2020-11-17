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
    public class QuestionController : ControllerBase
    {
        // GET: api/Question
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Question> Get()
        {
            IReadQuestionData readObject = new ReadQuestionData();
            return readObject.GetAllQuestions();
        }

        // GET: api/Question/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetQuestion")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Question
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Question/5
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
