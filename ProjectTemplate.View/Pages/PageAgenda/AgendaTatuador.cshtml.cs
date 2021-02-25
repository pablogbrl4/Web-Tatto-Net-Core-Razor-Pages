using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ProjectTemplate.Domain.Entities;
using System.IO;
using DocumentFormat.OpenXml.Office.CustomUI;

namespace ProjectTemplate.View.Pages.PageAgenda
{
    public class AgendaTatuador : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public Tatuador Tatuador { get; set; }

 
        public AgendaTatuador(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
