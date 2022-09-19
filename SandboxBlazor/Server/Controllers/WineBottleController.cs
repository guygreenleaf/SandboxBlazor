using Microsoft.AspNetCore.Mvc;
using SandboxBlazor.Server.Repository;
using SandboxBlazor.Shared.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SandboxBlazor.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WineBottleController : ControllerBase
    {
        private readonly IWineBottleRepository _wineBottleRepository;

        public WineBottleController(IWineBottleRepository wineBottleRepository)
        {
            _wineBottleRepository = wineBottleRepository;
        }

        //Gets all bottles
        [HttpGet("AllBottles")]
        public async Task<IActionResult> GetAllWineBottles()
        {
            try
            {
                var data = await _wineBottleRepository.GetAllWineBottles();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
                
            }
        }


        //Gets bottle by sku
        [HttpGet("BySku/{sku}")]
        public async Task<IActionResult> GetWineBottlesBySku(string sku)
        {
            try
            {
                var data = await _wineBottleRepository.GetWineBottleBySku(sku);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> InsertWineBottle([FromBody] WineBottle newWineBottle)
        {
            try
            {
                var newBottleID = await _wineBottleRepository.InsertWineBottle(newWineBottle);

                return Ok(newBottleID);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
