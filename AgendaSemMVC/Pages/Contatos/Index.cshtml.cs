using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaSemMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaSemMVC.Pages.Contato
{
    public class IndexModel : PageModel
    {
        private readonly AgendaContext _context;
        public IList<Models.Contato> Contatos { get; set; }

        public IndexModel(AgendaContext context)
        {
            _context = context;

            if (_context.Contatos.Count() == 0)
            {
                _context.Contatos.Add(new Models.Contato { Nome = "José", Numero = "83 998443239" });
                _context.SaveChanges();
            }
        }               
        
        public async Task OnGetAsync()
        {
            Contatos = await _context.Contatos.ToListAsync();

        }
       
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);

            if (contato != null)
            {
                _context.Contatos.Remove(contato);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

    }
}