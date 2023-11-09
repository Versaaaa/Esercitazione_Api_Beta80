using FrontEnd.Data.Models;
using FrontEnd.Data.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontEnd.Pages
{
    public class GestioneFunzionalitaModel : PageModel
    {

        public Task<ICollection<Banche>> Banches { get; set; }
        private readonly ApiRepository _rep;

        public GestioneFunzionalitaModel(ApiRepository rep)
        {
            _rep = rep;
        }

        public void OnGet()
        {
            Banches = _rep.GetBanche();
        }
    }
}
