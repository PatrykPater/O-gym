using O_gym.Shared.Abstractions.Exceptions;

namespace O_gym.Domain.Exceptions
{
    public class InvalidAgregateIdException : OGymException
    {
        public InvalidAgregateIdException() : base("Invalid agregate Id exception")
        {
        }
    }
}