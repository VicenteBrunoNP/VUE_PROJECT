using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_school_API.Data;
using project_school_API.Models;

namespace project_school_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProfessorController : Controller
    {
        public IRepository _repo { get; }
        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
         public async Task<IActionResult> get()
        {
            try
            {
                var result = await _repo.GetAllProfessorAsync(true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet("{ProfessorId}")]
        public async Task<IActionResult> get(int ProfessorId)
        {
            try
            {
                var result = await _repo.GetAlunosAsyncByProfessorId(ProfessorId,true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Professor model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/professor/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpPut("{ProfessorId}")]
        public async Task<IActionResult> put(int PofessorId, Professor model)
        {
            try
            {
                var professor = await _repo.GetProfessorAsyncById(PofessorId, false);
                if (professor == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    professor = await _repo.GetProfessorAsyncById(PofessorId, true);

                    return Created($"/api/professor/{model.Id}", professor);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }

        [HttpDelete("{ProfessorId}")]
        public async Task<IActionResult> delete(int PofessorId)
        {
            try
            {
                var professor = await _repo.GetProfessorAsyncById(PofessorId, false);
                if (professor == null) return NotFound();

                _repo.Delete(professor);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }
    }
}