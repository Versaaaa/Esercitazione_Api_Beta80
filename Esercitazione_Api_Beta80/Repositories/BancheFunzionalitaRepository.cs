using Esercitazione_Api_Beta80.Contexts;
using Esercitazione_Api_Beta80.Entities;
using Esercitazione_Api_Beta80.Models;
using Microsoft.EntityFrameworkCore;

namespace Esercitazione_Api_Beta80.Repositories
{
    public class BancheFunzionalitaRepository
    {
        private readonly BankomatContext _context;

        public BancheFunzionalitaRepository(BankomatContext context)
        {
            _context = context;
        }

        public async Task<ICollection<BancheFunzionalita>> Get()
        {
            return await _context.Banche_Funzionalita.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<BancheFunzionalita> Post(BancheFunzionalitaModel model)
        {

            var banca = await _context.Banche.FirstAsync(x => x.Id == model.IdBanca);
            var funzionalita = await _context.Funzionalita.FirstAsync(x => x.Id == model.IdFunzionalita);

            var res = new BancheFunzionalita()
            {
                Banche = banca,
                Funzionalita = funzionalita, 
            };

            _context.Banche_Funzionalita.Add(res);

            await _context.SaveChangesAsync();

            return res;

        }

        public async Task Delete(BancheFunzionalitaModel model)
        {
            var banca = await _context.Banche.FirstAsync(x => x.Id == model.IdBanca);
            var funzionalita = await _context.Funzionalita.FirstAsync(x => x.Id == model.IdFunzionalita);

            var res = await _context.Banche_Funzionalita.FirstAsync(x => x.IdBanca == banca.Id && x.IdFunzionalita == funzionalita.Id);

            banca.BancheFunzionalita.Remove(res);
            funzionalita.BancheFunzionalita.Remove(res);

            _context.Remove(res);

            await _context.SaveChangesAsync();
        }

    }
}
