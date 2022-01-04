using Microsoft.EntityFrameworkCore;
using O_gym.Infrastructure.EF.Configuration.ReadConfig;
using O_gym.Infrastructure.EF.Models;

namespace O_gym.Infrastructure.EF.Contexts
{
    internal sealed class ReadDbContext: DbContext
    {
        public DbSet<UserReadModel> Users { get; set; }
        public DbSet<MembershipDetailsReadModel> MembershipDetails { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("OGymApp");

            new UserReadConfig().Configure(modelBuilder.Entity<UserReadModel>());
            new MembershipConfig().Configure(modelBuilder.Entity<MembershipReadModel>());
            new MembershipDetailsConfig().Configure(modelBuilder.Entity<MembershipDetailsReadModel>());
        }
    }
}
