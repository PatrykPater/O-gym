using O_gym.Domain.Exceptions;
using System;

namespace O_gym.Domain.ValueObjects
{
    public record AgregateId
    {
        public Guid Value { get; }

        public AgregateId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidAgregateIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(AgregateId id)
            => id.Value;
        public static implicit operator AgregateId(Guid id)
            => new(id);
    }
}