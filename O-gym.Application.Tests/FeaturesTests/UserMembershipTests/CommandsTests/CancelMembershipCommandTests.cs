using Moq;
using O_gym.Application.Features.UserMembership.Commands;
using O_gym.Domain.Entities;
using O_gym.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace O_gym.Application.Tests.FeaturesTests.UserMembershipTests.CommandsTests
{
    public class CancelMembershipCommandTests
    {
        private readonly CancelMembershipCommandHandler _commandHandler;
        private readonly Guid userId;
        private readonly CancelMembershipCommand command;
        private readonly User user;
        private readonly Mock<IUserRepository> repository = new();
        private readonly CancellationToken token;

        public CancelMembershipCommandTests()
        {
            _commandHandler = new CancelMembershipCommandHandler(repository.Object);

            userId = Guid.NewGuid();
            command = new CancelMembershipCommand() { Id = userId };

            user = new User("FirstName", "LastName", "email@test.com");
            user.AddMembership(1, 100);

            CancellationTokenSource source = new();
            token = source.Token;
        }

        private Task Act(CancelMembershipCommand command, CancellationToken cancellation)
            => _commandHandler.Handle(command, cancellation);

        [Fact]
        public async Task HandleAsync_Should_CallRepositoryUpdate_WithSuccess()
        {
            repository.Setup(r => r.GetById(userId, token)).ReturnsAsync(user);

            var exception = await Record.ExceptionAsync(() => Act(command, token));

            Assert.Null(exception);
            repository.Verify(r => r.Update(user, token), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_Should_Not_CallRepositoryUpdate()
        {
            repository.Setup(r => r.GetById(It.IsAny<Guid>(), token)).ReturnsAsync(() => null);

            var exception = await Record.ExceptionAsync(() => Act(command, token));

            Assert.Null(exception);
            repository.Verify(r => r.Update(user, token), Times.Never);
        }
    }
}
