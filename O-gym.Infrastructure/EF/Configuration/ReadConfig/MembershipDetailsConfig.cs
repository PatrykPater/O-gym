using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O_gym.Infrastructure.EF.Models;
using O_gym.Infrastructure.EF.ValueObjects;

namespace O_gym.Infrastructure.EF.Configuration.ReadConfig
{
    internal sealed class MembershipDetailsConfig : IEntityTypeConfiguration<MembershipDetailsReadModel>
    {
        public void Configure(EntityTypeBuilder<MembershipDetailsReadModel> builder)
        {
            builder.ToTable("MembershipDetails");
            builder.HasKey(details => details.Id);

            builder.Property(details => details.Name).HasMaxLength(255);

            builder.Property(details => details.Price)
                   .HasConversion(price => price.Value, price => MonthlyMembershipPriceReadModel.Create(price));

            builder.HasOne(details => details.Membership)
                   .WithOne(mb => mb.MembershipDetails)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
