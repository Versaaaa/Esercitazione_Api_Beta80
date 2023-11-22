using Esercitazione_Api_Beta80.Entities;
using Esercitazione_Api_Beta80.Models;
using Esercitazione_Api_Beta80.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Esercitazione_Api_Beta80.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtentiController : ControllerBase
    {

        UtentiRepository _rep;

        public UtentiController(UtentiRepository rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var utenti = await _rep.Get();
                var res = new List<UtentiGetModel>();

                foreach (var utente in utenti)
                {
                    res.Add(new UtentiGetModel(utente));
                }

                return Ok(res);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}", Name = nameof(Get))]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var utente = await _rep.GetById(id);
                var res = new UtentiGetModel(utente);

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
        public async Task<IActionResult> Post([FromBody] UtentiPostModel utente)
        {
            try
            {
                var res = await _rep.Post(utente);
                return CreatedAtRoute(nameof(Get), new { id = res.Id }, new UtentiGetModel(res));
            }
            catch (InvalidOperationException)
            {
                return NotFound("Id Banca non trovato");
            }
            catch(UtentiRepository.DuplicateKeyException)
            {
                return BadRequest("Utente Duplicato");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] UtentiPutModel utente)
        {
            try
            {
                if(utente.Password == "")
                {
                    utente.Password = (await _rep.GetById(id)).Password;
                }
                await _rep.Put(id, utente);
                return await Get(id);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _rep.Delete(id);
                return NoContent();
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
