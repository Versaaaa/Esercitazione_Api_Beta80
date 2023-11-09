using Esercitazione_Api_Beta80.Entities;

namespace Esercitazione_Api_Beta80.Models
{
    public class FunzionalitaModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public FunzionalitaModel(Funzionalita input)
        {
            Id = input.Id;
            Nome = input.Nome;
        }

    }
}
