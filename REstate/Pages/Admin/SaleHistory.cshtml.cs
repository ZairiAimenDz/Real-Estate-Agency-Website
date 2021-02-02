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
    public class SaleHistoryModel : PageModel
    {
        private readonly REstate.Data.ApplicationDbContext _context;

        public SaleHistoryModel(REstate.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public readonly int EPP = 12;

        [BindProperty(SupportsGet = true)]
        public int PageNum { get; set; }

        public IList<Vente> Vente { get;set; }

        public async Task OnGetAsync()
        {
            Vente = await _context.Vente
                .Include(v => v.Property).OrderByDescending(p=>p.DateAchat).Skip(EPP*PageNum).Take(EPP).ToListAsync();
        }
    }
}
