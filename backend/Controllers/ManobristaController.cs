using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkinglotApp.Model;
using ParkinglotApp.Services;

namespace ParkinglotApp.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ManobristaController : ControllerBase
  {
    private readonly ILogger<ManobristaController> _logger;
    private IManobristaService _manobristaService;

    public ManobristaController(ILogger<ManobristaController> logger, 
                                IManobristaService manobristaService)
    {
      _logger = logger;
      _manobristaService = manobristaService;
    }

    [HttpGet]
    public IActionResult Get()
    {

      return Ok(_manobristaService.Listar());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
      var person = _manobristaService.BuscarPorId(id);
      if (person == null)
        return NotFound();
      return Ok(person);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Manobrista manobrista)
    {
      if (manobrista == null)
        return BadRequest();
      return Ok(_manobristaService.Criar(manobrista));
    }

    [HttpPut]
    public IActionResult Put([FromBody] Manobrista manobrista)
    {
      if (manobrista == null)
        return BadRequest();
      return Ok(_manobristaService.Atualizar(manobrista));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      _manobristaService.Deletar(id);
      return NoContent();
    }
  }
}
