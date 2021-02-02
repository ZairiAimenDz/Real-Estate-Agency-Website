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
    public class SaleDetailModel : PageModel
    {
        private readonly REstate.Data.ApplicationDbContext _context;

        public SaleDetailModel(REstate.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Vente Vente { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vente = await _context.Vente
                .Include(v => v.Property).FirstOrDefaultAsync(m => m.ID == id);

            if (Vente == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
