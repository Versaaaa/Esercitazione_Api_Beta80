using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esercitazione_Api_Beta80.Entities
{
    public class Funzionalita
    {
        public Funzionalita()
        {
            this.BancheFunzionalita = new HashSet<BancheFunzionalita>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<BancheFunzionalita> BancheFunzionalita { get; set; }
    }
}
