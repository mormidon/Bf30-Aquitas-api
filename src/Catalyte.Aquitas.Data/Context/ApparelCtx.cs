﻿using Catalyte.Aquitas.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.Data.Context
{
    public class ApparelCtx : DbContext, IApparelCtx
    {

        public ApparelCtx(DbContextOptions<ApparelCtx> options) : base(options)
        { }

        public DbSet<Company> Companies { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
