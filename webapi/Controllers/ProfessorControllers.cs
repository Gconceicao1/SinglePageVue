using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        public IRepository _repo { get; }
        public ProfessorController(IRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> Get()

        {
            try
            {
                var result = await _repo.GetAllProfessorAsync(true);
                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao comunicar com a base de dados");
            }

        }
        [HttpGet("{professorId}")]
        public async Task<IActionResult> Get(int professorId)

        {
            try
            {
                var result = await _repo.GetAProfessorAsyncById(professorId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao comunicar com a base de dados");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Professor model)

        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/professor/{model.Id}", model);
                }

            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao comunicar com a base de dados" + ex.Message);
            }
            return BadRequest();
        }
        [HttpPut("{professorId}")]
        public async Task<IActionResult> Put(int professorId, Professor model)

        {

            try
            {
                var professor = await _repo.GetAProfessorAsyncById(professorId, true);
                if (professor == null) BadRequest();

                _repo.Update(model);
                if (await _repo.SaveChangesAsync())
                {
                    professor = await _repo.GetAProfessorAsyncById(professorId, false);
                    return Created($"/api/professor/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao comunicar com a base de dados");
            }
            return BadRequest();

        }

        [HttpDelete("{professorId}")]
        public async Task <IActionResult> Delete(int professorId)

        {
             try
            {
                var professor = await _repo.GetAProfessorAsyncById(professorId, false);
                if (professor == null) BadRequest();

                _repo.Delete(professor);

                if (await _repo.SaveChangesAsync())
                {
                   return Ok();

                }
            }    
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao comunicar com a base de dados");
            }
            return BadRequest();

        }
    }
}