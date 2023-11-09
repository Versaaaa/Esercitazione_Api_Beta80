using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esercitazione_Api_Beta80.Entities
{
    public class ContiCorrente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long IdUtente { get; set; }
        public int Saldo { get; set; }
        public System.DateTime DataUltimaOperazione { get; set; }

        [ForeignKey(nameof(IdUtente))]
        public virtual Utenti Utenti { get; set; }
    }
}
