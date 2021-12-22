using O_gym.Domain.ValueObjects;

namespace O_gym.Domain.Entities
{
    public class MembershipDetails
    {
        public int Id { get; }
        private string _name;
        private MonthlyMembershipPrice _price;
        private ushort _tier;

        protected MembershipDetails()
        {
        }

        public MembershipDetails(int id)
        {
            Id = id;
        }
    }
}
