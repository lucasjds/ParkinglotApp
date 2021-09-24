using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkinglotApp.Business;
using ParkinglotApp.Model;

namespace ParkinglotApp.Controllers
{
  [ApiVersion("1")]
  [ApiController]
  [Route("api/[controller]/v{version:apiVersion}")]
  public class ManobristaController : ControllerBase
  {
    private readonly ILogger<ManobristaController> _logger;
    private IManobristaBusiness _manobristaBusiness;

    public ManobristaController(ILogger<ManobristaController> logger,
                                IManobristaBusiness manobristaBusiness)
    {
      _logger = logger;
      _manobristaBusiness = manobristaBusiness;
    }

    [HttpGet]
    public IActionResult Get()
    {

      return Ok(_manobristaBusiness.Listar());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
      var person = _manobristaBusiness.BuscarPorId(id);
      if (person == null)
        return NotFound();
      return Ok(person);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Manobrista manobrista)
    {
      if (manobrista == null)
        return BadRequest();
      return Ok(_manobristaBusiness.Criar(manobrista));
    }

    [HttpPut]
    public IActionResult Put([FromBody] Manobrista manobrista)
    {
      if (manobrista == null)
        return BadRequest();
      return Ok(_manobristaBusiness.Atualizar(manobrista));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      _manobristaBusiness.Deletar(id);
      return NoContent();
    }
  }
}
