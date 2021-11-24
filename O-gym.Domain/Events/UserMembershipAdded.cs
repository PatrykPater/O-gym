using games_store.Domain.Entities;
using O_gym.Shared.Abstractions.Domain;

namespace O_gym.Domain.Events
{
    public record UserMembershipAdded(User User, Membership Membership) : IDomainEvent
    {
    }
}