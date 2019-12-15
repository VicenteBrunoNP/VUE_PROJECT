using Microsoft.AspNetCore.Mvc;

namespace project_school_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AlunoController : Controller
    {
        public AlunoController()
        {
            
        }

        [HttpGet]
        public IActionResult get()
        {
            return Ok();
        }

        [HttpGet("{AlunoId}")]
        public IActionResult get(int AlunoId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult post()
        {
            return Ok();
        }

        [HttpPut("{AlunoId}")]
        public IActionResult put(int AlunoId)
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