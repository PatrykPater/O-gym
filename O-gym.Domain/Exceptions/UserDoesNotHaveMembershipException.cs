using O_gym.Shared.Abstractions.Exceptions;

namespace O_gym.Domain.Exceptions
{
    public class UserDoesNotHaveMembershipException : OGymException
    {
        public UserDoesNotHaveMembershipException() : base("Operation cannot be performed. User does not posses membership.")
        {
        }
    }
}