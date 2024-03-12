using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LanDotBien_BackEnd.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class Manage_Manager_Accounts : ControllerBase
    {
        // GET: api/<Manage_Manager_Accounts>
        [HttpGet]
        public IEnumerable<string> GetAllUser()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Manage_Manager_Accounts>/5
        [HttpGet("{id}")]
        public string GetUserById(int id)
        {
            return "value";
        }

        // POST api/<Manage_Manager_Accounts>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Manage_Manager_Accounts>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Manage_Manager_Accounts>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
