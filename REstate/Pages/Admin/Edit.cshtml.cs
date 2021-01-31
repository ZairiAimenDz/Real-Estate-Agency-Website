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
using REstate.Services;

namespace REstate.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly REstate.Data.ApplicationDbContext _context;
        private readonly IImageService service;

        public EditModel(REstate.Data.ApplicationDbContext context,IImageService service)
        {
            _context = context;
            this.service = service;
        }

        [BindProperty]
        public Property Property { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Property = await _context.Property.FirstOrDefaultAsync(m => m.ID == id);

            if (Property == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Property.DateAdded = DateTime.Now;
            if (Property.ThumbnailFile is not null)
            {
                service.DeleteImage(Property.MainThumbnail);
                Property.MainThumbnail = service.UploadImage(Property.ThumbnailFile);
            }
            _context.Attach(Property).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(Property.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PropertyExists(Guid id)
        {
            return _context.Property.Any(e => e.ID == id);
        }
    }
}
