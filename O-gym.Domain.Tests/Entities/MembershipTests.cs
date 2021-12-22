using O_gym.Domain.Entities;
using O_gym.Domain.Exceptions;
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

        [Fact]
        public void Create_Should_CreateNewMembership()
        {
            var membership = Membership.Create(1, 100);

            Assert.NotNull(membership);
            Assert.NotNull(membership.MembershipDuration);
            Assert.True(membership.MembershipDuration.ExpirationDate > DateTime.UtcNow);
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
