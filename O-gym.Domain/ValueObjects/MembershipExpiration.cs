using O_gym.Domain.Exceptions;
using System;

namespace O_gym.Domain.ValueObjects
{
    public record MembershipExpiration
    {
        public DateTime ExpirationDate { get; }

        public MembershipExpiration(ushort months)
        {
            if (months > 12 || months <= 0)
            {
                throw new InvalidMembershipDurationValueException();
            }

            ExpirationDate = DateTime.UtcNow.AddMonths(months);
        }
    }
}