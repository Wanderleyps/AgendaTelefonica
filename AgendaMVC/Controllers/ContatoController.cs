using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context)
        {
            _context = context;

            if (_context.Contatos.Count() == 0)
            {
                _context.Contatos.Add(new Contato { Nome = "José", Numero = "83 998443239" });
                _context.SaveChanges();
            }
        }

       
        public async Task<ActionResult<IEnumerable<Contato>>> Index()
        {
            return View(await _context.Contatos.ToListAsync());
        }

        
        public async Task<ActionResult<Contato>> Details(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);

            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<ActionResult<Contato>> Create(Contato contato)
        {
            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        
        public async Task<ActionResult<Contato>> Edit(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Contato contato)
        {
            if (id != contato.Id)
            {
                return BadRequest();
            }
            try
            {                
                _context.Contatos.Update(contato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Error), e.Message);
            }
        }
        
        public async Task<ActionResult<Contato>> Delete(int? id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }
            return View(contato);
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            var contato = await _context.Contatos.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }

            try
            {
                _context.Contatos.Remove(contato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Error), e.Message);
            }
        }

        public IActionResult Error(string message)
        {
            ViewData["Erro"] = message;
            return View();
        }

    }

}
