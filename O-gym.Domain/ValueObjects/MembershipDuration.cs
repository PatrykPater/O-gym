using O_gym.Domain.Exceptions;
using System;

namespace O_gym.Domain.ValueObjects
{
    public record MembershipDuration
    {
        public DateTime ExpirationDate { get; }

        public MembershipDuration(ushort months)
        {
            if (months > 12 || months <= 0)
            {
                throw new InvalidMembershipDurationValueException();
            }

            ExpirationDate = DateTime.UtcNow.AddMonths(months);
        }
    }
}