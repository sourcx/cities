using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using aspnetcoreapp.Models;

    public class MvcCityContext : DbContext
    {
        public MvcCityContext (DbContextOptions<MvcCityContext> options)
            : base(options)
        {
        }

        public DbSet<aspnetcoreapp.Models.City> City { get; set; } = default!;
    }
