using MediatR;
using O_gym.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace O_gym.Application.Features.UserMembership.Commands
{
    public class AddMembershipCommand : IRequest<Guid?>
    {
        public Guid Id { get; set; }
        public ushort Months { get; set; }
        public decimal Price { get; set; }
    }

    public class AddMembershipHandler : IRequestHandler<AddMembershipCommand, Guid?>
    {
        private readonly IUserRepository userRepository;

        public AddMembershipHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Guid?> Handle(AddMembershipCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetById(request.Id, cancellationToken);

            if (user is null)
            {
                return null;
            }

            user.AddMembership(request.Months, request.Price);

            await userRepository.Update(user, cancellationToken);

            return user.Id;
        }
    }
}
