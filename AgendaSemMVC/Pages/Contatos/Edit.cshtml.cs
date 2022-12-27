using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaSemMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AgendaSemMVC.Pages.Contatos
{
    public class EditModel : PageModel
    {
        private readonly AgendaContext _context;
        [BindProperty]
        public Models.Contato Contato { get; set; }               

        public EditModel(AgendaContext context)
        {
            _context = context;

            if (_context.Contatos.Count() == 0)
            {
                _context.Contatos.Add(new Models.Contato { Nome = "José", Numero = "83 998443239" });
                _context.SaveChanges();
            }
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Contato = await _context.Contatos.FirstOrDefaultAsync(c => c.Id == id);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Models.Contato contato)
        {
            try { 
                _context.Entry(null).State = EntityState.Modified;
                await _context.SaveChangesAsync();            
                return RedirectToPage("./Index");
            }
            catch (Exception e)
            {
                return RedirectToPage("./Error", new Erro { ErroMessage = e.Message });
            }
        }
    }
}