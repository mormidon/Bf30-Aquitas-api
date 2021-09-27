using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Data.SeedData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Catalyte.Apparel.Data.Context
{
    public static class Extensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var productFactory = new ProductFactory();

            modelBuilder.Entity<Product>().HasData(productFactory.GenerateRandomProducts(7));
        }
    }
}
