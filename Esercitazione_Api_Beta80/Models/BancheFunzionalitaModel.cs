using Esercitazione_Api_Beta80.Entities;

namespace Esercitazione_Api_Beta80.Models
{
    public class BancheFunzionalitaModel
    {
        public long IdBanca { get; set; }
        public long IdFunzionalita { get; set; }

        public BancheFunzionalitaModel()
        {
            
        }

        public BancheFunzionalitaModel(BancheFunzionalita input)
        {
            IdBanca = input.IdBanca;
            IdFunzionalita = input.IdFunzionalita;
        }
    }
}
