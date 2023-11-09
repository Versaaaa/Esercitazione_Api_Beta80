using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esercitazione_Api_Beta80.Entities
{
    public class Utenti
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long IdBanca { get; set; }
        public string NomeUtente { get; set; }
        public string Password { get; set; }
        public bool Bloccato { get; set; }

        [ForeignKey("IdBanca")]
        public virtual Banche Banche { get; set; }

        public virtual ICollection<ContiCorrente> ContiCorrente { get; set; }

        public Utenti()
        {
            ContiCorrente = new HashSet<ContiCorrente>();
        }

    }
}
