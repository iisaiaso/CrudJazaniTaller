using Jazani.Domain.Admins.Models;
using Jazani.Infastructure.Admins.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infastructure.Cores.Contexts
{
    public  class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { }
        #region "DBSet"
        public DbSet<Stateattention> Stateattentions { get; set; }
        public DbSet<Tupa> Tupas { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           modelBuilder.ApplyConfiguration(new StateattentionConfiguration());
            modelBuilder.ApplyConfiguration(new TupaConfiguration());
        }


    }
}
