using MediatR;
using O_gym.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace O_gym.Application.Features.UserMembership.Commands
{
    public class CancelMembershipCommand : IRequest<Guid?>
    {
        public Guid UserId { get; set; }
    }

    public class CancelMembershipCommandHandler : IRequestHandler<CancelMembershipCommand, Guid?>
    {
        private readonly IUserRepository userRepository;

        public CancelMembershipCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Guid?> Handle(CancelMembershipCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetById(request.UserId, cancellationToken);

            if (user is null)
            {
                return null;
            }

            user.CancelMembership();

            await userRepository.Update(user, cancellationToken);

            return user.Id;
        }
    }
}
