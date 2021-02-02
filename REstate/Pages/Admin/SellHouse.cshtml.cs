using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using REstate.Data;
using REstate.Models;

namespace REstate.Pages.Admin
{
    [Authorize(Roles="Admin")]
    public class SellHouseModel : PageModel
    {
        private readonly REstate.Data.ApplicationDbContext _context;

        public SellHouseModel(REstate.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        private Property prop;
        [BindProperty]
        public Vente Vente { get; set; }
        [BindProperty(SupportsGet =true)]
        public Guid id { get; set; }

        public IActionResult OnGet()
        {
            if (id.Equals(Guid.Empty))
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }            
            prop = await _context.Property.FirstOrDefaultAsync(m => m.ID == id);

            if (prop == null)
            {
                return NotFound();
            }
            Vente.Property = prop;
            _context.Add(Vente);
            prop.vendu = true;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
