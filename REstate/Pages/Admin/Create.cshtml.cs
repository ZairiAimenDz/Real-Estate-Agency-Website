using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using REstate.Data;
using REstate.Models;
using REstate.Services;

namespace REstate.Pages.Admin
{
    [Authorize(Roles ="Admin")]
    public class CreateModel : PageModel
    {
        private readonly REstate.Data.ApplicationDbContext _context;
        private readonly IImageService imgservice;

        public CreateModel(REstate.Data.ApplicationDbContext context,IImageService imgservice)
        {
            _context = context;
            this.imgservice = imgservice;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Property Property { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Property.DateAdded = DateTime.Now;
            Property.MainThumbnail = imgservice.UploadImage(Property.ThumbnailFile);
            _context.Property.Add(Property);
            await _context.SaveChangesAsync();

            return RedirectToPage("./AddImages",new {id=Property.ID});
        }
    }
}
