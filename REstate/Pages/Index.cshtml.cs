using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using REstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REstate.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty(SupportsGet =true)]
        public SaleType stype { get; set; }
        [BindProperty(SupportsGet =true)]
        public PropertyType ptype { get; set; }
        [BindProperty(SupportsGet =true)]
        public int Bedrooms{ get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/List",new {stype=stype,ptype=ptype,Bedrooms=Bedrooms });
        }
    }
}
