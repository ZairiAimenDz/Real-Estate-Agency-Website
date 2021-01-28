using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using REstate.Data;
using REstate.Models;

namespace REstate.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly REstate.Data.ApplicationDbContext _context;

        public IndexModel(REstate.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Property> Property { get;set; }

        public readonly int EPP = 12;

        [BindProperty(SupportsGet =true)]
        public int PageNum { get; set; }

        public async Task OnGetAsync()
        {
            Property = await _context.Property.OrderByDescending(p=>p.DateAdded).Skip(12*PageNum).Take(EPP).ToListAsync();
        }
    }
}
