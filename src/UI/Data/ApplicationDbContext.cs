using Microsoft.EntityFrameworkCore;
using UI.Data.Configurations;
using UI.Models.Entities;

namespace UI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder
        //         .UseSqlServer(
        //             "Server=.\\SQLEXPRESS;Database=SurveySystem;Trusted_Connection=True;TrustServerCertificate=True;");
        //     base.OnConfiguring(optionsBuilder);
        // }
    }
}
