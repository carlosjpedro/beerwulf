using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Review.API.Entities;

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
                    new Product(1,"Delirium Tremens"),
                    new Product(2, "Duvel"),
                    new Product(3, "Super Bock"),
                    new Product(4, "Guiness"),
                });
                context.SaveChanges();
            }
        }
    }
}