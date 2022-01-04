using O_gym.Infrastructure.EF.ValueObjects;

namespace O_gym.Infrastructure.EF.Models
{
    internal class MembershipDetailsReadModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MonthlyMembershipPriceReadModel Price { get; set; }
        public MembershipReadModel Membership { get; set; }
    }
}
