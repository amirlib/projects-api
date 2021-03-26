using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectsApi.Configuration;
using ProjectsApi.Entities;

namespace ProjectsApi.Helpers
{
    public class DataContext: DbContext
    {
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #region Fileds
        protected readonly IConfiguration Configuration;
        #endregion

        #region Properties
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion

        #region Protected Methods
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("db"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectsConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
        }
        #endregion
    }
}
