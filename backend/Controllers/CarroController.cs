using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkinglotApp.Business;
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
    public IActionResult Get()
    {

      return Ok(_carroBusiness.Listar());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
      var person = _carroBusiness.BuscarPorId(id);
      if (person == null)
        return NotFound();
      return Ok(person);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Carro carro)
    {
      if (carro == null)
        return BadRequest();
      return Ok(_carroBusiness.Criar(carro));
    }

    [HttpPut]
    public IActionResult Put([FromBody] Carro carro)
    {
      if (carro == null)
        return BadRequest();
      return Ok(_carroBusiness.Atualizar(carro));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
      _carroBusiness.Deletar(id);
      return NoContent();
    }
  }
}
