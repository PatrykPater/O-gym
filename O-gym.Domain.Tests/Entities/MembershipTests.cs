using O_gym.Domain.Entities;
using O_gym.Domain.Exceptions;
using Xunit;

namespace O_gym.Domain.Tests.Entities
{
    public class MembershipTests
    {
        private readonly Membership membership;

        public MembershipTests()
        {
            membership = Membership.Create(1, 100);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(8)]
        [InlineData(11)]
        public void ExtendMembership_Should_ExtendMembership_BySpecifiedNumberOfMonths(ushort months)
        {
            var originalExpiration = membership.MembershipDuration.ExpirationDate;

            membership.ExtendMembership(months);
            var newExpirationDate = membership.MembershipDuration.ExpirationDate;

            Assert.True(originalExpiration.AddMonths(months).Month == newExpirationDate.Month);
        }

        [Fact]
        public void ExtendMembership_Should_Throw_InvalidMembershipDurationValueException()
        {
            Assert.Throws<InvalidMembershipDurationValueException>(() => membership.ExtendMembership(12));
        }

        [Fact]
        public void Create_Should_Throw_InvalidMembershipDurationValueException()
        {
            Assert.Throws<InvalidMembershipDurationValueException>(() => Membership.Create(13, 100));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Create_Should_Throw_InvalidPriceValueException(decimal price)
        {
            Assert.Throws<InvalidPriceValueException>(() => Membership.Create(1, price));
        }

        [Fact]
        public void Create_Should_CreateNewMembership()
        {
            var membership = Membership.Create(1, 100);

            Assert.NotNull(membership);
            Assert.NotNull(membership.MembershipDuration);
            Assert.NotNull(membership.MonthlyPrice);
            Assert.True(membership.MonthlyPrice > 0);
            Assert.True(membership.MembershipDuration.ExpirationDate > membership.MembershipDuration.StartDate);
        }
    }
}
