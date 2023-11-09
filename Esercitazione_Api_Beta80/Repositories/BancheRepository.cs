using Esercitazione_Api_Beta80.Contexts;
using Esercitazione_Api_Beta80.Entities;
using Microsoft.EntityFrameworkCore;

namespace Esercitazione_Api_Beta80.Repositories
{
    public class BancheRepository
    {
        private readonly BankomatContext _context;

        public BancheRepository(BankomatContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Banche>> Get()
        {
            return await _context.Banche.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Banche> GetById(int id)
        {
            return await _context.Banche.FirstAsync(x => x.Id == id);
        }
    }
}
