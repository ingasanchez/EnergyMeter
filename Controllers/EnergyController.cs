using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestEnergyProject.Models;

namespace TestEnergyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyController : ControllerBase
    {
        Mod_power_readings mod_Power_Readings = new Mod_power_readings();


        [HttpGet("GetAll")]
        public IActionResult Get()
        {

            try
            {
                var listCli = mod_Power_Readings.BuscarTodos();
                return Ok(listCli);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("SaveReading")]
        public IActionResult SaveData(PowerReading pwd)
        {

            try
            {
                 mod_Power_Readings.Guardar(pwd);
                return Ok(pwd);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
