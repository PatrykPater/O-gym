using O_gym.Domain.Entities;
using O_gym.Shared.Abstractions.Domain;

namespace O_gym.Domain.Events
{
    public record UserMembershipChanged(User User, Membership NewMembership, Membership OldMembership) : IDomainEvent
    {
    }
}
