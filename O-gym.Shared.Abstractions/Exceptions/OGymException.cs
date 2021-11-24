using System;

namespace O_gym.Shared.Abstractions.Exceptions
{
    public abstract class OGymException : Exception
    {
        protected OGymException(string message) : base(message)
        {
        }
    }
}