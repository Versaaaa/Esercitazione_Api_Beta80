using Esercitazione_Api_Beta80.Contexts;
using Esercitazione_Api_Beta80.Entities;
using Microsoft.EntityFrameworkCore;

namespace Esercitazione_Api_Beta80.Repositories
{
    public class FunzionalitaRepository
    {

        private readonly BankomatContext _context;

        public FunzionalitaRepository(BankomatContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Funzionalita>> Get() 
        { 
            return await _context.Funzionalita.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Funzionalita> GetById(int id)
        {
            return await _context.Funzionalita.FirstAsync(x => x.Id == id);
        }

    }
}
