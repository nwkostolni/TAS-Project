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
    public class AnswerController : ControllerBase
    {
        // GET: api/Answer
        [HttpGet]
        public List<Answer> Get()
        {
            IReadAnsData readObject = new ReadAnswerData();
            return readObject.GetAllAnswers();
        }

        // GET: api/Answer/5
        [HttpGet("{id}", Name = "GetAnswer")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Answer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Answer/5
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
