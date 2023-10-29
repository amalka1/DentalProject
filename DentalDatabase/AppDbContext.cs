using DentalDatabase.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Application.Database
{
    /// The application's primary database context. Dynamically registers entities  derived from <see cref="BaseEntity"/> to the database.
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var entityTypes = Assembly.GetExecutingAssembly().GetTypes()
                                  .Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(BaseEntity)));

            foreach (var type in entityTypes)
            {
                modelBuilder.Entity(type);
            }
        }
    }
}
