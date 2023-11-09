using Esercitazione_Api_Beta80.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esercitazione_Api_Beta80.Models
{
    public class UtentiPostModel
    {
        public long IdBanca { get; set; }
        public string NomeUtente { get; set; }
        public string Password { get; set; }
    }
}
