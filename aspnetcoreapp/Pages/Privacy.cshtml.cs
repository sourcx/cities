﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreApp.Pages;

public class Privacy : PageModel
{
    private readonly ILogger<Privacy> _logger;

    public Privacy(ILogger<Privacy> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}
