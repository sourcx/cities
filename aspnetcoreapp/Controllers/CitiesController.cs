using AspNetCoreApp.Data;
using AspNetCoreApp.Models;
using AspNetCoreApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreApp.Controllers;

public class CitiesController : Controller
{
    private readonly RazorPagesCityContext _context;
    private readonly IMyCustomService _customService;

    public CitiesController(RazorPagesCityContext context, IMyCustomService customService)
    {
        _context = context;
        _customService = customService;
    }

    // GET: Cities
    public async Task<IActionResult> Index(string? a, int? b, string searchString)
    {
        var cities = from c in _context.City select c;

        if (!string.IsNullOrEmpty(searchString))
        {
            cities = cities.Where(c => c.Name.Contains(searchString));
            ViewData["searchString"] = searchString;
        }

        // ViewData can be set in controllers
        ViewData["hello"] = "world";
        ViewData["a"] = a;
        ViewData["b"] = b;
        ViewData["myCustomService result"] = _customService.DoThings();

        return _context.City != null ?
                    View(await cities.ToListAsync()) :
                    Problem("Entity set 'RazorPagesCityContext.City'  is null.");
    }

    // Override posting to this Index endpoint.
    [HttpPost]
    public string Index(string searchString, bool notUsed)
    {
        return "From [HttpPost]Index: filter on " + searchString;
    }

    // GET: Cities/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.City == null)
        {
            return NotFound();
        }

        var city = await _context.City
            .FirstOrDefaultAsync(m => m.Id == id);
        if (city == null)
        {
            return NotFound();
        }

        return View(city);
    }

    // GET: Cities/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Cities/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,PublishDate,Json,Country")] City city)
    {
        if (ModelState.IsValid)
        {
            _context.Add(city);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(city);
    }

    // GET: Cities/Edit/5
    // https://localhost:7154/Mvc/Cities/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.City == null)
        {
            return NotFound();
        }

        var city = await _context.City.FindAsync(id);
        if (city == null)
        {
            return NotFound();
        }

        return View(city); // this type should match with the @model directive in Edit.cshtml
    }

    // POST: Cities/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost] // POSTING data from form
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PublishDate,Json,Country")] City city)
    {
        if (id != city.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(city);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(city.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        return View(city);
    }

    // GET: Cities/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.City == null)
        {
            return NotFound();
        }

        var city = await _context.City
            .FirstOrDefaultAsync(m => m.Id == id);
        if (city == null)
        {
            return NotFound();
        }

        return View(city);
    }

    // POST: Cities/Delete/5
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.City == null)
        {
            return Problem("Entity set 'RazorPagesCityContext.City'  is null.");
        }

        var city = await _context.City.FindAsync(id);
        if (city != null)
        {
            _context.City.Remove(city);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CityExists(int id)
    {
        return (_context.City?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
