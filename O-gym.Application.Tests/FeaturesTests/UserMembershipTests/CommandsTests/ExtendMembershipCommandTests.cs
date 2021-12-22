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
    public class ExtendMembershipCommandTests
    {
        private readonly Mock<IUserRepository> repository = new ();
        private readonly ExtendMembershipHandler _commandHandler;
        private readonly Guid userId;
        private readonly ExtendMembershipCommand command;
        private readonly CancellationToken token;
        private readonly User user;

        public ExtendMembershipCommandTests()
        {
            _commandHandler = new ExtendMembershipHandler(repository.Object);

            userId = Guid.NewGuid();
            command = new ExtendMembershipCommand() { Id = userId, Months = 1 };

            user = new User("FirstName", "LastName", "email@test.com");
            user.AddMembership(1, 100);

            CancellationTokenSource source = new();
            token = source.Token;
        }

        private Task Act(ExtendMembershipCommand command, CancellationToken cancellation)
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
