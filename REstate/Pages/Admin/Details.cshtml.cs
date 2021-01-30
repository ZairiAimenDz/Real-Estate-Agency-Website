using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using REstate.Data;
using REstate.Models;

namespace REstate.Pages.Admin
{
    [Authorize(Roles ="Admin")]
    public class DetailsModel : PageModel
    {
        private readonly REstate.Data.ApplicationDbContext _context;

        public DetailsModel(REstate.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Property Property { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Property = await _context.Property.Include(p=>p.PropertyImages).FirstOrDefaultAsync(m => m.ID == id);

            if (Property == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
