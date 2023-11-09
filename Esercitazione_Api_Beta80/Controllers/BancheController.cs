using Esercitazione_Api_Beta80.Models;
using Esercitazione_Api_Beta80.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Esercitazione_Api_Beta80.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancheController : ControllerBase
    {

        BancheRepository _rep;

        public BancheController(BancheRepository rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = new List<BancheModel>();
                foreach(var i in await _rep.Get())
                {
                    res.Add(new BancheModel(i));
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
                var res = new BancheModel(await _rep.GetById(id));
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
