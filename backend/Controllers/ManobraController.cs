using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkinglotApp.Business;
using ParkinglotApp.Data.VO;
using ParkinglotApp.Model;

namespace ParkinglotApp.Controllers
{
  [ApiVersion("1")]
  [ApiController]
  [Route("api/[controller]/v{version:apiVersion}")]
  public class ManobraController : ControllerBase
  {
    private readonly ILogger<ManobraController> _logger;
    private IManobraBusiness _manobraBusiness;

    public ManobraController(ILogger<ManobraController> logger,
                             IManobraBusiness manobraBusiness)
    {
      _logger = logger;
      _manobraBusiness = manobraBusiness;
    }

    [HttpGet]
    public IActionResult Get()
    {

      return Ok(_manobraBusiness.Listar());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
      var person = _manobraBusiness.BuscarPorId(id);
      if (person == null)
        return NotFound();
      return Ok(person);
    }

    [HttpPost]
    public IActionResult Post([FromBody] ManobraVO manobra)
    {
      if (manobra == null)
        return BadRequest();
      return Ok(_manobraBusiness.Criar(manobra));
    }

    [HttpPut]
    public IActionResult Put([FromBody] ManobraVO manobra)
    {
      if (manobra == null)
        return BadRequest();
      return Ok(_manobraBusiness.Atualizar(manobra));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      _manobraBusiness.Deletar(id);
      return NoContent();
    }
  }
}
