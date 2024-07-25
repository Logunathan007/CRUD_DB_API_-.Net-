using CRUD_DB_Using_API.Model.Entitys;
using CRUD_DB_Using_API.Model.Operations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_DB_Using_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        static DML dml;
        static ApiController() {
            dml = new DML();
            Console.WriteLine("ApiController Constructor is called");
        }
        // GET: api/<ApiController>
        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            List<Employee> obj = dml.GetAllData();
            if(obj == null) return NoContent();
            return Ok(obj);
        }

        // GET api/<ApiController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            Employee obj = dml.GetDataById(id);
            if (obj != null)
                return Ok(obj);
            else 
                return BadRequest();
        }

        // POST api/<ApiController>
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee obj)
        {
            if (obj == null)
            {
                return BadRequest();
            }
            if (dml.InsertData(obj))
            {
                return Ok(obj);
            }
            return BadRequest();
        }

        // PUT api/<ApiController>/5
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromBody] Employee obj)
        {
            if (dml.UpdateData(id,obj))
            {
                return Ok(obj);
            }
            return BadRequest();
        }

        // DELETE api/<ApiController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (dml.DeleteData(id))
            {
                return Ok();
            }
            return BadRequest(); 
        }
    }
}
