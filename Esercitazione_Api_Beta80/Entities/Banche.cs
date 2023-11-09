using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esercitazione_Api_Beta80.Entities
{
    public class Banche
    {
        public Banche()
        {
            this.BancheFunzionalita = new HashSet<BancheFunzionalita>();
            this.Utenti = new HashSet<Utenti>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<BancheFunzionalita> BancheFunzionalita { get; set; }
        public virtual ICollection<Utenti> Utenti { get; set; }
    }
}
