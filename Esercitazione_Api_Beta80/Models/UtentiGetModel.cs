using Esercitazione_Api_Beta80.Entities;

namespace Esercitazione_Api_Beta80.Models
{
    public class UtentiGetModel
    {
        public long Id { get; set; }
        public string Banca { get; set; }
        public string NomeUtente { get; set; }
        public bool Bloccato { get; set; }

        public UtentiGetModel(Utenti utente)
        {
            Id = utente.Id;
            NomeUtente = utente.NomeUtente;
            Banca = utente.Banche.Nome;   
            Bloccato = utente.Bloccato;
        }

    }
}
