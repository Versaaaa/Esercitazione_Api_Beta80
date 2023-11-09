using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esercitazione_Api_Beta80.Entities
{
    public class Movimenti
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string NomeBanca { get; set; }
        public string NomeUtente { get; set; }
        public string Funzionalita { get; set; }
        public int Quantita { get; set; }
        public System.DateTime DataOperazione { get; set; }
    }
}
