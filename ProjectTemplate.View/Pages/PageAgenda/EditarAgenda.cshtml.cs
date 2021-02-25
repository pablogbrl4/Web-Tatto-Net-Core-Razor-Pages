using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.View.Pages.PageAgenda
{
    public class EditarAgendaModel : PageModel
    {
        public Agenda Agenda { get; set; }
        public void OnGet()
        {
        }
    }
}
