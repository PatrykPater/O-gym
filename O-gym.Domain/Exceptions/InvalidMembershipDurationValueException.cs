using O_gym.Shared.Abstractions.Exceptions;

namespace O_gym.Domain.Exceptions
{
    public class InvalidMembershipDurationValueException : OGymException
    {
        public InvalidMembershipDurationValueException() : base("Invalid value for membership duration. Duration cannot exceed 12 months")
        {
        }
    }
}