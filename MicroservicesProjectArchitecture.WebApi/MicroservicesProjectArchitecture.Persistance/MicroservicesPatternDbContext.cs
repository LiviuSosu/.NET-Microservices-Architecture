using MicroservicesProjectArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesProjectArchitecture.Persistance
{
    public class MicroservicesPatternDbContext: DbContext
    {
        public MicroservicesPatternDbContext(DbContextOptions<MicroservicesPatternDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-M80MDUC;Initial Catalog=MicroservicesPatternDbContext;Integrated Security = True;"
                ,x => x.MigrationsAssembly("MicroservicesProjectArchitecture.Migrations")
                );
            base.OnConfiguring(optionsBuilder);
        }
    }
}
