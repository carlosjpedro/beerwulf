using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Review.API.Services.Model;

namespace Review.API.Repositories
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProductDbContext(serviceProvider.GetRequiredService<DbContextOptions<ProductDbContext>>()))
            {
                if (context.Products.Any())
                {
                    return;
                }

                context.Products.AddRange(new[]
                {
                    new Product(1,"beer 1"),
                    new Product(2, "another beer")
                });
                context.SaveChanges();
            }
        }
    }
}