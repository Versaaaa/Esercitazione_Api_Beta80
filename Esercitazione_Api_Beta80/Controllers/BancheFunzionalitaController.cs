using Esercitazione_Api_Beta80.Models;
using Esercitazione_Api_Beta80.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace Esercitazione_Api_Beta80.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancheFunzionalitaController : ControllerBase
    {

        BancheFunzionalitaRepository _rep;

        public BancheFunzionalitaController(BancheFunzionalitaRepository rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = new List<BancheFunzionalitaModel>();
                foreach (var i in await _rep.Get())
                {
                    res.Add(new BancheFunzionalitaModel(i));
                }
                return Ok(res);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByBankId(int id)
        {
            try
            {
                var res = new List<BancheFunzionalitaModel>();
                foreach (var i in await _rep.GetByBankId(id))
                {
                    res.Add(new BancheFunzionalitaModel(i));
                }
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BancheFunzionalitaModel model)
        {
            try
            {
                await _rep.Post(model);
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] BancheFunzionalitaModel model)
        {
            try
            {
                await _rep.Delete(model);
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
