using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O_gym.Infrastructure.EF.Models;

namespace O_gym.Infrastructure.EF.Configuration.ReadConfig
{
    internal sealed class UserReadConfig : IEntityTypeConfiguration<UserReadModel>
    {
        public void Configure(EntityTypeBuilder<UserReadModel> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(user => user.Id);

            builder.Property(user => user.FirstName).HasMaxLength(255);
            builder.Property(user => user.LastName).HasMaxLength(255);

            builder.HasOne(user => user.Membership)
                   .WithOne(userMb => userMb.User)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
