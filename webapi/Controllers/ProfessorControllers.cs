using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController()
        {

        }

        [HttpGet]
        public IActionResult Get()

        {
            return Ok();
        }
        [HttpGet("{professorId}")]
        public IActionResult Get(int professorId)

        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()

        {
            return Ok();
        }
        [HttpPut("{professorId}")]
        public IActionResult Put(int professorId)

        {
            return Ok();
        }

        [HttpDelete("{professorId}")]
        public IActionResult Delete(int professorId)

        {
            return Ok();
        }
    }
}