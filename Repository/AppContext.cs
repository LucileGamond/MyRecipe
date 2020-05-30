using System;

using Microsoft.EntityFrameworkCore;
using Data;

namespace Repository
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new RecipeMap(modelBuilder.Entity<Recipe>());
            new StepMap(modelBuilder.Entity<Step>());
        }
    }
}
