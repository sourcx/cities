using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using aspnetcoreapp.Models;
using aspnetcoreapp.Data;

namespace aspnetcoreapp.Pages_Cities
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesCityContext _context;

        public CreateModel(RazorPagesCityContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // The Page method creates a PageResult object that renders the Create.cshtml page.
            return Page();
        }

        //The City property uses the [BindProperty] attribute to opt-in to model binding. 
        // When the Create form posts the form values, the ASP.NET Core runtime binds the posted values to the City model.
        [BindProperty]
        public City City { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.City == null || City == null)
            {
                return Page();
            }

            _context.City.Add(City);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
