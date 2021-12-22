using O_gym.Domain.ValueObjects;

namespace O_gym.Domain.Entities
{
    public class MembershipDetails
    {
        private int _id;
        private string _name;
        private MonthlyMembershipPrice _price;
        private ushort _tier;

        protected MembershipDetails()
        {
        }

        public MembershipDetails(int id)
        {
            _id = id;
        }
    }
}
