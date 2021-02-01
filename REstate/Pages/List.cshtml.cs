using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using REstate.Data;
using REstate.Models;

namespace REstate.Pages
{
    public class ListModel : PageModel
    {
        private readonly REstate.Data.ApplicationDbContext _context;

        public ListModel(REstate.Data.ApplicationDbContext context)
        {
            _context = context;
        }


        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        [BindProperty(SupportsGet = true)]
        public SaleType stype { get; set; }
        [BindProperty(SupportsGet = true)]
        public PropertyType ptype { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Bedrooms { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageNum { get; set; } = 0;

        public readonly int EPP = 12;

        public IList<Property> Property { get;set; }

        public async Task OnGetAsync()
        {
            var querry = _context.Property.Where(p=>!p.vendu);
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                querry = querry.Where(p => p.Description.ToLower().Contains(SearchTerm.ToLower()) || p.Title.ToLower().Contains(SearchTerm.ToLower()));
            }
            if(stype > 0)
            {
                querry = querry.Where(p => p.SaleType == stype);
            }
            if(ptype > 0)
            {
                querry = querry.Where(p => p.propertyType == ptype);
            }
            if(Bedrooms > 0)
            {
                querry = querry.Where(p => p.Bedrooms >= Bedrooms);
            }
            Property = await querry.OrderByDescending(p=>p.DateAdded).Skip(12*PageNum).Take(EPP).ToListAsync();
        }
    }
}
