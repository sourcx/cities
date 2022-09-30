using AspNetCoreApp.Data;
using AspNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApp.Pages_Cities
{
    public class Details : PageModel
    {
        private readonly RazorPagesCityContext _context;

        public Details(RazorPagesCityContext context)
        {
            _context = context;
        }

        public City City { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.City == null)
            {
                return NotFound();
            }

            var city = await _context.City.FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }
            else
            {
                City = city;
            }

            return Page();
        }
    }
}
