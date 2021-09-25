using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkinglotApp.Business;
using ParkinglotApp.Data.VO;
using ParkinglotApp.Hypermedia.Filter;
using ParkinglotApp.Model;
using System.Collections.Generic;

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
    [ProducesResponseType(200, Type = typeof(List<ManobristaVO>))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get()
    {

      return Ok(_manobristaBusiness.Listar());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(ManobristaVO))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get(long id)
    {
      var person = _manobristaBusiness.BuscarPorId(id);
      if (person == null)
        return NotFound();
      return Ok(person);
    }

    [HttpPost]
    [ProducesResponseType((200), Type = typeof(ManobristaVO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Post([FromBody] ManobristaVO manobrista)
    {
      if (manobrista == null)
        return BadRequest();
      return Ok(_manobristaBusiness.Criar(manobrista));
    }

    [HttpPut]
    [ProducesResponseType((200), Type = typeof(ManobristaVO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Put([FromBody] ManobristaVO manobrista)
    {
      if (manobrista == null)
        return BadRequest();
      return Ok(_manobristaBusiness.Atualizar(manobrista));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Delete(long id)
    {
      _manobristaBusiness.Deletar(id);
      return NoContent();
    }
  }
}
