using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using webapi.Data;
using webapi.Models;
using System.Threading.Tasks;

namespace webapi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public IRepository _repo { get; }
        public AlunoController(IRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {


            try
            {
                var result = await _repo.GetAllAlunosAsync(true);
                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao comunicar com a base de dados");
            }



        }
        [HttpGet("ByProfessor/{ProfessorId}")]
        public async Task<IActionResult> GetAlunoByProfessorId(int ProfessorId)
        {


            try
            {
                var result = await _repo.GetAlunoByProfessorId(ProfessorId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao comunicar com a base de dados");
            }



        }

        [HttpGet("{alunoId}")]
        public async Task<IActionResult> Get(int alunoId)

        {
            var result = await _repo.GetAlunoAsyncById(alunoId, true);
            try
            {
                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao comunicar com a base de dados");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(Aluno model)

        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/aluno/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao comunicar com a base de dados");
            }

            return BadRequest();

        }
        [HttpPut("{alunoId}")]
        public async Task<IActionResult> Put(int alunoId, Aluno model)

        {

            try
            {
                var aluno = await _repo.GetAlunoAsyncById(alunoId, false);

                if (aluno == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    aluno = await _repo.GetAlunoAsyncById(alunoId, true);
                    return Created($"/api/aluno/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao comunicar com a base de dados");
            }

            return BadRequest();

        }

        [HttpDelete("{alunoId}")]
        public async Task<IActionResult> Delete(int alunoId)

        {
            try
            {
                var aluno = await _repo.GetAlunoAsyncById(alunoId, false);

                if (aluno == null) return NotFound();

                _repo.Delete(aluno);

                if (await _repo.SaveChangesAsync())
                {
                    aluno = await _repo.GetAlunoAsyncById(alunoId, true);
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