using Esercitazione_Api_Beta80.Contexts;
using Esercitazione_Api_Beta80.Entities;
using Esercitazione_Api_Beta80.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Esercitazione_Api_Beta80.Repositories
{
    public class UtentiRepository
    {

        public class DuplicateKeyException : Exception 
        { 
            
        }

        private readonly BankomatContext _context;

        public UtentiRepository(BankomatContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Utenti>> Get()
        {
            return await _context.Utenti.OrderBy(x => x.Id).Include(x => x.Banche).ToListAsync();
        }
        public async Task<Utenti> GetById(long id)
        {
            return await _context.Utenti.Include(x => x.Banche).FirstAsync(x => x.Id == id);
        }

        public async Task<Utenti> Post(UtentiPostModel utente)
        {
            var res = new Utenti() 
            { 
                Banche = await _context.Banche.FirstAsync(x => x.Id == utente.IdBanca),
                NomeUtente = utente.NomeUtente,
                Password = utente.Password,
                Bloccato = false,
            };

            if (_context.Utenti.FirstOrDefault(x => x.NomeUtente == utente.NomeUtente) != null )
            {
                throw new DuplicateKeyException();
            }

            await _context.Utenti.AddAsync(res);
            var contoCorrente = new ContiCorrente()
            {
                Utenti = res,
                Saldo = 0,
            };

            res.ContiCorrente.Add(contoCorrente);
            await _context.ContiCorrente.AddAsync(contoCorrente);
            await _context.SaveChangesAsync();

            return res;
        }

        public async Task Put(long id, UtentiPutModel utente)
        {
            var res = await _context.Utenti.FirstAsync(x => x.Id == id);
            res.Password = utente.Password;
            res.Bloccato = utente.Bloccato;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            _context.Utenti.Remove(_context.Utenti.First(x => x.Id == id));
            await _context.SaveChangesAsync();
        }

    }
}
