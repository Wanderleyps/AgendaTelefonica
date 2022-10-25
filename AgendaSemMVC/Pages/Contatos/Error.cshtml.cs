using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaSemMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AgendaSemMVC.Pages.Contatos
{
    public class ErrorModel : PageModel
    {
        [BindProperty]
        public Erro Erro { get; set; }

        public void OnGet(Erro erro)
        {
            Erro = erro;
            ViewData["Erro"] = Erro.ErroMessage;
        }
    }
}