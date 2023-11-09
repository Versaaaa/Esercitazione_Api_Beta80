using FrontEnd.Data.Models;
using FrontEnd.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Pages
{
    public class ModificaBancaModel : PageModel
    {

        readonly ApiRepository _rep;

        public Task<Banche> Banca { get; set; }
        public Task<ICollection<Funzionalita>> Funzionalitas { get; set; }
        public Task<ICollection<BancheFunzionalita>> BancheFunzionalitas { get; set; }

        public ModificaBancaModel(ApiRepository rep)
        {
            _rep = rep;
        }

        public void OnGet()
        {
            Banca = _rep.GetBanca(int.Parse(Request.Query["i"]));
            Funzionalitas = _rep.GetFunzionalita();
            BancheFunzionalitas = _rep.GetBancheFunzionalita();
        }

        public void OnSaveButton() 
        {

        }

    }
}
