using O_gym.Shared.Abstractions.Exceptions;

namespace O_gym.Domain.Exceptions
{
    public class UserAlreadyHasMembershipException : OGymException
    {
        public UserAlreadyHasMembershipException() : base("User already has membership")
        {
        }
    }
}