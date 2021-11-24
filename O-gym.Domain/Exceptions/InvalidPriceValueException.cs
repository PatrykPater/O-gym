using O_gym.Shared.Abstractions.Exceptions;

namespace O_gym.Domain.Exceptions
{
    public class InvalidPriceValueException : OGymException
    {
        public InvalidPriceValueException() : base("Value for price must be higher than 0")
        {
        }
    }
}