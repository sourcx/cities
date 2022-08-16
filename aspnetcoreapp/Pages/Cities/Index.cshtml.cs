using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using aspnetcoreapp.Models;
using aspnetcoreapp.Data;

namespace aspnetcoreapp.Pages_Cities
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesCityContext _context;

        public IndexModel(RazorPagesCityContext context)
        {
            _context = context;
        }

        public IList<City> City { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.City != null)
            {
                City = await _context.City.ToListAsync();
            }
        }
    }
}
