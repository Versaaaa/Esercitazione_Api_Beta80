using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esercitazione_Api_Beta80.Entities
{
    public class BancheFunzionalita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long IdBanca { get; set; }
        public long IdFunzionalita { get; set; }

        [ForeignKey(nameof(IdBanca))]
        public virtual Banche Banche { get; set; }
        [ForeignKey(nameof(IdFunzionalita))]
        public virtual Funzionalita Funzionalita { get; set; }
    }
}
