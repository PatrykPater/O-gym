using O_gym.Domain.ValueObjects;
using System;

namespace O_gym.Domain.Entities
{
    public class Membership
    {
        public int Id { get; }
        public MembershipDuration MembershipDuration { get; private set; }
        public MonthlyMembershipPrice MonthlyPrice { get; }

        protected Membership()
        {
        }

        private Membership(ushort months, decimal monthlyprice)
        {
            MembershipDuration = new (months);
            MonthlyPrice = new (monthlyprice);
        }

        public static Membership Create(ushort months, decimal monthlyprice)
            => new(months, monthlyprice);

        public void ExtendMembership(ushort months)
        {
            var expiration = MembershipDuration.ExpirationDate;

            var ramainingMonths = MonthDifference(DateTime.UtcNow, expiration);
            months += Convert.ToUInt16(ramainingMonths);

            MembershipDuration = new(months);
        }

        private static int MonthDifference(DateTime lValue, DateTime rValue)
        {
            return Math.Abs((lValue.Month - rValue.Month) + (12 * (lValue.Year - rValue.Year)));
        }
    }
}