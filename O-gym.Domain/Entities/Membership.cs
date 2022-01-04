using System;

namespace O_gym.Domain.Entities
{
    public class Membership
    {
        private Guid _userId;
        private int _membershipDetailsId;

        public int Id { get; }
        public MembershipDetails MembershipDetails { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        protected Membership()
        {
        }

        private Membership(ushort months, int membershipId)
        {
            MembershipDetails = new(membershipId);
            ExpirationDate = DateTime.UtcNow.AddMonths(months);
        }

        public static Membership Create(ushort months, int membershipId)
            => new(months, membershipId);

        public ushort RemainingMonths =>
            Convert.ToUInt16(MonthDifference(ExpirationDate, DateTime.UtcNow));

        public void ExtendMembership(ushort months)
        {
            ExpirationDate = ExpirationDate.AddMonths(months);
        }

        private static int MonthDifference(DateTime lValue, DateTime rValue)
        {
            return Math.Abs((lValue.Month - rValue.Month) + (12 * (lValue.Year - rValue.Year)));
        }
    }
}