using MediatR;
using O_gym.Application.Services;
using O_gym.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace O_gym.Application.Features.UserMembership.Commands
{
    public class AddMembershipCommand : IRequest<Guid?>
    {
        public Guid UserId { get; set; }
        public int MembershipDetailsId { get; set; }
        public ushort NumberOfMonths { get; set; }
    }

    public class AddMembershipHandler : IRequestHandler<AddMembershipCommand, Guid?>
    {
        private readonly IUserRepository userRepository;
        private readonly IMembershipService membershipService;

        public AddMembershipHandler(IUserRepository userRepository, IMembershipService membershipService)
        {
            this.userRepository = userRepository;
            this.membershipService = membershipService;
        }

        public async Task<Guid?> Handle(AddMembershipCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetById(request.UserId, cancellationToken);

            if (user is null)
            {
                return null;
            }

            if (!membershipService.MembershipDetailsExists(request.MembershipDetailsId))
            {
                return null;
            }

            user.AddMembership(request.NumberOfMonths, request.MembershipDetailsId);

            await userRepository.Update(user, cancellationToken);

            return user.Id;
        }
    }
}
