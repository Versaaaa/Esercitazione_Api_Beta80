using Esercitazione_Api_Beta80.Entities;
using Microsoft.EntityFrameworkCore;

namespace Esercitazione_Api_Beta80.Contexts
{
    public class BankomatContext : DbContext
    {
        public BankomatContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Banche> Banche { get; set; }
        public DbSet<BancheFunzionalita> Banche_Funzionalita { get; set; }
        public DbSet<ContiCorrente> ContiCorrente { get; set; }
        public DbSet<Funzionalita> Funzionalita { get; set; }
        public DbSet<Movimenti> Movimenti { get; set; }
        public DbSet<Utenti> Utenti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
