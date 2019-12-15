using Microsoft.AspNetCore.Mvc;

namespace project_school_API.Controllers
{   
    [Route("api/[Controller]")]
    [ApiController]
    public class ProfessorController: Controller
    {        
        public ProfessorController()
        {
            
        }

        [HttpGet]
        public IActionResult get()
        {
            return Ok();
        }

        [HttpGet("{ProfessorId}")]
        public IActionResult get(int ProfessorId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult post()
        {
            return Ok();
        }

        [HttpPut("{ProfessorId}")]
        public IActionResult put(int PofessorId)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult delete()
        {
            return Ok();
        }
    }
}