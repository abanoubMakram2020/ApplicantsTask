using ApplicantsTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicantsTask.Infra.Data.Context
{
    public class ApplicantsTaskDBContext:DbContext
    {
        public ApplicantsTaskDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Applicant> Applicant { get; set; }
        public DbSet<User> User { get; set; }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Start Seed Data
          //  modelBuilder.StartSeedData();
            #endregion
        }
    }
}
