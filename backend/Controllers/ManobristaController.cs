using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ParkinglotApp.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ManobristaController : ControllerBase
  {
    private readonly ILogger<ManobristaController> _logger;

    public ManobristaController(ILogger<ManobristaController> logger)
    {
      _logger = logger;
    }


  }
}
