using Moq;
using O_gym.Domain.Entities;
using O_gym.Domain.Events;
using O_gym.Domain.Exceptions;
using System.Linq;
using Xunit;

namespace O_gym.Domain.Tests.Entities
{
    public class UserTests
    {
        private readonly User user;
        private readonly int membershipDetailsId = 100;

        public UserTests()
        {
            user = new User("name", "last name", "email");
        }

        [Fact]
        public void AddMembership_Should_AddNewMembership()
        {
            user.AddMembership(1, membershipDetailsId);

            Assert.NotNull(user.Events);

            var userMembershipAddedEvent = user.Events.FirstOrDefault();
            Assert.NotNull(userMembershipAddedEvent);
            Assert.IsAssignableFrom<UserMembershipAdded>(userMembershipAddedEvent);
        }

        [Fact]
        public void AddMembership_Should_Throw_UserAlreadyHasMembershipException()
        {
            user.AddMembership(1, membershipDetailsId);

            Assert.Throws<UserAlreadyHasMembershipException>(() => user.AddMembership(1, membershipDetailsId));
        }

        [Fact]
        public void ExtendMembership_Should_ExtendCurrentMembership_BySpecifiedNumberOfMonths()
        {
            user.AddMembership(1, membershipDetailsId);

            user.ExtendMembership(1);

            var userMembershipExtendEvent = user.Events.Skip(1).FirstOrDefault();
            Assert.NotNull(userMembershipExtendEvent);
            Assert.IsAssignableFrom<UserMembershipExtended>(userMembershipExtendEvent);
        }

        [Fact]
        public void ExtendMembership_Should_Throw_UserDoesNotHaveMembershipException()
        {
            Assert.Throws<UserDoesNotHaveMembershipException>(() => user.ExtendMembership(1));
        }

        [Fact]
        public void CancelMembership_Should_CancelCurrentMembership()
        {
            user.AddMembership(1, membershipDetailsId);

            user.CancelMembership();

            var userMembershipCancelledEvent = user.Events.Skip(1).FirstOrDefault();
            Assert.NotNull(userMembershipCancelledEvent);
            Assert.IsAssignableFrom<UserMembershipCancelled>(userMembershipCancelledEvent);
        }

        [Fact]
        public void CancelMembership_Should_Throw_UserDoesNotHaveMembershipException()
        {
            Assert.Throws<UserDoesNotHaveMembershipException>(() => user.CancelMembership());
        }

        [Fact]
        public void ChangeMembership_Should_ChangeCurrentMembership()
        {
            user.AddMembership(1, membershipDetailsId);

            user.ChangeMembership(It.IsAny<int>());

            Assert.NotNull(user.Events);

            var userMembershipChangedEvent = user.Events.Skip(1).FirstOrDefault();
            Assert.NotNull(userMembershipChangedEvent);
            Assert.IsAssignableFrom<UserMembershipChanged>(userMembershipChangedEvent);
        }

        [Fact]
        public void ChangeMembership_Should_Throw_UserMembershipCannotBeChangedToTheSameMembership()
        {
            user.AddMembership(1, membershipDetailsId);

            Assert.Throws<UserMembershipCannotBeChangedToTheSameMembership>(() => user.ChangeMembership(membershipDetailsId));
        }
    }
}