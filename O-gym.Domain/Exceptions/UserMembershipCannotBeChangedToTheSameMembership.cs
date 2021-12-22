using O_gym.Shared.Abstractions.Exceptions;

namespace O_gym.Domain.Exceptions
{
    public class UserMembershipCannotBeChangedToTheSameMembership: OGymException
    {
        public UserMembershipCannotBeChangedToTheSameMembership() : base("Operation cannot be performed. User cannot change membership to the same membership")
        {
        }
    }
}
