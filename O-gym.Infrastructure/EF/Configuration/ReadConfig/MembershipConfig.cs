using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O_gym.Infrastructure.EF.Models;

namespace O_gym.Infrastructure.EF.Configuration.ReadConfig
{
    internal sealed class MembershipConfig : IEntityTypeConfiguration<MembershipReadModel>
    {
        public void Configure(EntityTypeBuilder<MembershipReadModel> builder)
        {
            builder.ToTable("Memberships");

            builder.HasKey(o => new { o.UserId, o.MembershipDetailsId });
        }
    }
}
