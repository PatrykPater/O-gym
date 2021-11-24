using games_store.Domain.Entities;
using O_gym.Domain.Events;
using O_gym.Domain.Exceptions;
using System.Linq;
using Xunit;

namespace O_gym.Domain.Tests.Entities
{
    public class UserTests
    {
        [Fact]
        public void AddMembership_Should_AddNewMembership()
        {
            var user = new User("name", "last name", "email");

            user.AddMembership(1, 100);

            Assert.NotNull(user.Events);

            var userMembershipAddedEvent = user.Events.FirstOrDefault();
            Assert.NotNull(userMembershipAddedEvent);
            Assert.IsAssignableFrom<UserMembershipAdded>(userMembershipAddedEvent);
        }

        [Fact]
        public void AddMembership_Should_Throw_UserAlreadyHasMembershipException()
        {
            var user = new User("name", "last name", "email");
            user.AddMembership(1, 100);

            Assert.Throws<UserAlreadyHasMembershipException>(() => user.AddMembership(1, 100));
        }
    }
}