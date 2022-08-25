using Microsoft.EntityFrameworkCore;
using aspnetcoreapp.Data;
using aspnetcoreapp.Models;
using Microsoft.Extensions.DependencyInjection;
using aspnetcoreapp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<RazorPagesCityContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesCityContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesCityContext' not found.")));
}
else
{
    builder.Services.AddDbContext<RazorPagesCityContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionCityContext")));
}

builder.Services.AddScoped<IMyCustomService, MyCustomService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "Mvc/{controller=HelloWorld}/{action=Index}/{id?}"
);

app.Run();
