using Moq;
using O_gym.Application.Features.UserMembership.Commands;
using O_gym.Application.Services;
using O_gym.Domain.Entities;
using O_gym.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace O_gym.Application.Tests.FeaturesTests.UserMembershipTests.CommandsTests
{
    public class AddMembershipCommandTests
    {
        private readonly AddMembershipHandler _commandHandler;
        private readonly Guid userId;
        private readonly AddMembershipCommand command;
        private readonly User user;
        private readonly Mock<IUserRepository> repository = new();
        private readonly Mock<IMembershipService> membershipService = new();
        private readonly CancellationToken token;

        public AddMembershipCommandTests()
        {
            _commandHandler = new AddMembershipHandler(repository.Object, membershipService.Object);

            userId = Guid.NewGuid();
            command = new AddMembershipCommand() { UserId = userId, NumberOfMonths = 1, MembershipDetailsId = 10 };
            user = new User("FirstName", "LastName", "email@test.com");

            CancellationTokenSource source = new();
            token = source.Token;
        }

        private Task Act(AddMembershipCommand command, CancellationToken cancellation)
            => _commandHandler.Handle(command, cancellation);

        [Fact]
        public async Task HandleAsync_Should_CallRepositoryUpdate_WithSuccess()
        {
            repository.Setup(r => r.GetById(userId, token)).ReturnsAsync(user);
            membershipService.Setup(s => s.MembershipDetailsExists(It.IsAny<int>())).Returns(true);

            var exception = await Record.ExceptionAsync(() => Act(command, token));

            Assert.Null(exception);
            repository.Verify(r => r.Update(user, token), Times.Once);
        }

        [Theory]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public async Task HandleAsync_Should_Not_CallRepositoryUpdate(bool membershipExists, bool returnsUser)
        {
            var returns = returnsUser ? user : null;
            repository.Setup(r => r.GetById(It.IsAny<Guid>(), token)).ReturnsAsync(() => returns);
            membershipService.Setup(s => s.MembershipDetailsExists(It.IsAny<int>())).Returns(membershipExists);

            var exception = await Record.ExceptionAsync(() => Act(command, token));

            Assert.Null(exception);
            repository.Verify(r => r.Update(user, token), Times.Never);
        }
    }
}
