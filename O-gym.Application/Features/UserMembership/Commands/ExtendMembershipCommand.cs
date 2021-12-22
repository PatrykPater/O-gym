using MediatR;
using O_gym.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace O_gym.Application.Features.UserMembership.Commands
{
    public class ExtendMembershipCommand : IRequest<Guid?>
    {
        public Guid Id { get; set; }
        public ushort Months { get; set; }
    }

    public class ExtendMembershipHandler : IRequestHandler<ExtendMembershipCommand, Guid?>
    {
        private readonly IUserRepository userRepository;

        public ExtendMembershipHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Guid?> Handle(ExtendMembershipCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetById(request.Id, cancellationToken);

            if (user is null)
            {
                return null;
            }

            user.ExtendMembership(request.Months);

            await userRepository.Update(user, cancellationToken);

            return user.Id;
        }
    }
}
