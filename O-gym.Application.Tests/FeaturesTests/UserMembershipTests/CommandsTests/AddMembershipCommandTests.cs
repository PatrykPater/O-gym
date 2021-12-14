using Moq;
using O_gym.Application.Features.UserMembership.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace O_gym.Application.Tests.FeaturesTests.UserMembershipTests.CommandsTests
{
    public class AddMembershipCommandTests
    {
        private readonly AddMembershipHandler _commandHandler;
        private readonly Mock<IUserRepository> repository = new();

        public AddMembershipCommandTests()
        {
            _commandHandler = new AddMembershipHandler(repository.Object);
        }

        private Task Act(AddMembershipCommand command, CancellationToken cancellation)
            => _commandHandler.Handle(command, cancellation);

        [Fact]
        public async Task HandleAsync_Should_CallRepository_WithSuccess()
        {
            var command = new AddMembershipCommand();

            CancellationTokenSource source = new();
            CancellationToken token = source.Token;

            var exception = await Record.ExceptionAsync(() => Act(command, token));

            Assert.Null(exception);
            await repository.Verify(r => r.Update);
        }
    }
}
