using Microsoft.EntityFrameworkCore;
using aspnetcoreapp.Data;

namespace aspnetcoreapp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new RazorPagesCityContext(serviceProvider.GetRequiredService<DbContextOptions<RazorPagesCityContext>>());

            if (context == null || context.City == null)
            {
                throw new ArgumentNullException("Null RazorPagesCityContext");
            }

            // Look for any Cities.
            if (context.City.Any())
            {
                return; // DB already seeded
            }

            context.City.AddRange(
                new City
                {
                    Name = "Wageningen",
                    PublishDate = DateTime.Parse("1989-2-12"),
                    Json = @"{ ""name"" : ""Wageningen"" }",
                },

                new City
                {
                    Name = "Renkum",
                    PublishDate = DateTime.Parse("1984-3-13"),
                    Json = @"{ ""name"" : ""Renkum"" }",
                },

                new City
                {
                    Name = "Arnhem",
                    PublishDate = DateTime.Parse("1986-2-23"),
                    Json = @"{ ""name"" : ""Arnhem"" }",
                }
            );

            context.SaveChanges();
        }
    }
}