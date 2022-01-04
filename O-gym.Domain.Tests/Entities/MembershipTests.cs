using O_gym.Domain.Entities;
using System;
using System.Collections.Generic;
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
        [MemberData(nameof(TestData))]
        public void ExtendMembership_Should_ExtendMembership_BySpecifiedNumberOfMonths(ushort months)
        {
            var originalExpiration = membership.ExpirationDate;

            membership.ExtendMembership(months);
            var newExpirationDate = membership.ExpirationDate;

            Assert.True(originalExpiration.AddMonths(months).Month == newExpirationDate.Month);
        }

        [Fact]
        public void Create_Should_CreateNewMembership()
        {
            var membership = Membership.Create(1, 100);

            Assert.NotNull(membership);
            Assert.True(membership.ExpirationDate > DateTime.UtcNow);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(9)]
        public void RemainingMonths_Should_ReturnNumberOfMonthsUntilExpirationDate(ushort months)
        {
            var membership = Membership.Create(months, 100);

            var remainingMonths = membership.RemainingMonths;

            Assert.Equal(months, remainingMonths);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 1 };
            yield return new object[] { 2 };
            yield return new object[] { 3 };
            yield return new object[] { 4 };
            yield return new object[] { 5 };
            yield return new object[] { 6 };
            yield return new object[] { 9 };
            yield return new object[] { 11 };
        }
    }
}
