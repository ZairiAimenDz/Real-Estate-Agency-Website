using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using REstate.Data;
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
        private readonly ApplicationDbContext context;

        public IndexModel(ILogger<IndexModel> logger,ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [BindProperty]
        public SaleType stype { get; set; }
        [BindProperty]
        public PropertyType ptype { get; set; }
        [BindProperty]
        public int Bedrooms{ get; set; }

        public List<Property> Properties = new List<Property>();

        public void OnGet()
        {
            Properties = context.Property.Where(p=>!p.PrivatePost).OrderByDescending(p => p.DateAdded).Take(9).ToList();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/List",new {stype=stype,ptype=ptype,Bedrooms=Bedrooms });
        }
    }
}
