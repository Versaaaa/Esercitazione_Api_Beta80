using Esercitazione_Api_Beta80.Models;
using Esercitazione_Api_Beta80.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Esercitazione_Api_Beta80.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunzionalitaController : ControllerBase
    {

        FunzionalitaRepository _rep;

        public FunzionalitaController(FunzionalitaRepository rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = new List<FunzionalitaModel>();
                foreach (var i in await _rep.Get())
                {
                    res.Add(new FunzionalitaModel(i));
                }
                return Ok(res); 
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var res = new FunzionalitaModel(await _rep.GetById(id));
                return Ok(res);
            }
            catch (InvalidOperationException)
            {
                return NotFound("Id non trovato");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
