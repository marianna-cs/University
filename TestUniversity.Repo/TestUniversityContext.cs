#nullable disable
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using University.Data;

namespace University.Repo
{
    public class TestUniversityContext : DbContext
    {
        public TestUniversityContext(DbContextOptions<TestUniversityContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Student> Students { get; set; }

    }
    public class EFDBContextFactory : IDesignTimeDbContextFactory<TestUniversityContext>
    {
        public TestUniversityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestUniversityContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestUniversityDb;Trusted_Connection=True;MultipleActiveResultSets=true");/*, b => b.MigrationsAssembly("DataLayer")*/

            return new TestUniversityContext(optionsBuilder.Options);
        }
    }

}
