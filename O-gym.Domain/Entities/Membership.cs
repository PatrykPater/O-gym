using O_gym.Domain.ValueObjects;
using System;

namespace O_gym.Domain.Entities
{
    public class Membership
    {
        public int Id { get; }
        public MembershipExpiration MembershipExpiration { get; private set; }
        public MembershipDetails MembershipDetails { get; private set; }

        protected Membership()
        {
        }

        private Membership(ushort months, int membershipId)
        {
            MembershipExpiration = new (months);
            MembershipDetails = new(membershipId);
        }

        public static Membership Create(ushort months, int membershipId)
            => new(months, membershipId);

        public ushort RemainingMonths =>
            Convert.ToUInt16(MonthDifference(MembershipExpiration.ExpirationDate, DateTime.UtcNow));

        public void ExtendMembership(ushort months)
        {
            var expiration = MembershipExpiration.ExpirationDate;

            var ramainingMonths = MonthDifference(DateTime.UtcNow, expiration);
            months += Convert.ToUInt16(ramainingMonths);

            MembershipExpiration = new(months);
        }

        private static int MonthDifference(DateTime lValue, DateTime rValue)
        {
            return Math.Abs((lValue.Month - rValue.Month) + (12 * (lValue.Year - rValue.Year)));
        }
    }
}