using AspNetCoreApp.Data;
using AspNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApp.Pages_Cities
{
    public class Index : PageModel
    {
        private readonly RazorPagesCityContext _context;

        public Index(RazorPagesCityContext context)
        {
            _context = context;
        }

        public IList<City> City { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchName { get; set; }

        public SelectList? Countries { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchCountry { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.City == null)
            {
                return;
            }

            IQueryable<string> countryQuery = from c in _context.City orderby c.Country select c.Country;

            var cities = from c in _context.City select c;

            if (!string.IsNullOrEmpty(SearchName))
            {
                cities = cities.Where(c => c.Name.Contains(SearchName));
            }

            if (!string.IsNullOrEmpty(SearchCountry))
            {
                cities = cities.Where(c => c.Country == SearchCountry);
            }

            Countries = new SelectList(await countryQuery.Distinct().ToListAsync());
            City = await cities.ToListAsync();
        }
    }
}
