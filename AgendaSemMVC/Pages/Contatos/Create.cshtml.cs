using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaSemMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgendaSemMVC.Pages.Contatos
{
    public class CreateModel : PageModel
    {
        private readonly AgendaContext _context;
        [BindProperty]
        public Models.Contato Contato { get; set; }

        public CreateModel(AgendaContext context)
        {
            _context = context;

            if (_context.Contatos.Count() == 0)
            {
                _context.Contatos.Add(new Models.Contato { Nome = "José", Numero = "83 998443239" });
                _context.SaveChanges();
            }
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync(Models.Contato contato)
        {

            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}