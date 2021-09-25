using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkinglotApp.Business;
using ParkinglotApp.Data.VO;
using ParkinglotApp.Hypermedia.Filter;
using ParkinglotApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkinglotApp.Controllers
{
  [ApiVersion("1")]
  [ApiController]
  [Route("api/[controller]/v{version:apiVersion}")]
  public class CarroController : ControllerBase
  {
    private readonly ILogger<CarroController> _logger;
    private ICarroBusiness _carroBusiness;

    public CarroController(ILogger<CarroController> logger,
                           ICarroBusiness carroBusiness)
    {
      _logger = logger;
      _carroBusiness = carroBusiness;
    }

    [HttpGet]
    [ProducesResponseType((200), Type = typeof(List<CarroVO>))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get()
    {

      return Ok(_carroBusiness.Listar());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(CarroVO))]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get(long id)
    {
      var person = _carroBusiness.BuscarPorId(id);
      if (person == null)
        return NotFound();
      return Ok(person);
    }

    [HttpPost]
    [ProducesResponseType((200), Type = typeof(CarroVO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Post([FromBody] CarroVO carro)
    {
      if (carro == null)
        return BadRequest();
      return Ok(_carroBusiness.Criar(carro));
    }

    [HttpPut]
    [ProducesResponseType((200), Type = typeof(CarroVO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Put([FromBody] CarroVO carro)
    {
      if (carro == null)
        return BadRequest();
      return Ok(_carroBusiness.Atualizar(carro));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Delete(long id)
    {
      _carroBusiness.Deletar(id);
      return NoContent();
    }
  }
}
