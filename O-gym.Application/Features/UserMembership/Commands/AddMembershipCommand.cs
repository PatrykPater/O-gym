using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace O_gym.Application.Features.UserMembership.Commands
{
    public class AddMembershipCommand: IRequest<Guid>
    {
    }

    public class AddMembershipHandler : IRequestHandler<AddMembershipCommand, Guid>
    {
        public Task<Guid> Handle(AddMembershipCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
