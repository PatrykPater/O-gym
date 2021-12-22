namespace O_gym.Domain.Entities
{
    public class MembershipDetails
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal MonthlyPrice { get; private set; }
        public ushort Tier { get; private set; }

        protected MembershipDetails()
        {
        }

        public MembershipDetails(int id)
        {
            Id = id;
        }
    }
}
