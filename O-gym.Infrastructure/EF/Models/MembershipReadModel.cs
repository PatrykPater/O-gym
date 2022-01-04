using System;

namespace O_gym.Infrastructure.EF.Models
{
    internal class MembershipReadModel
    {
        public Guid UserId { get; set; }
        public int MembershipDetailsId { get; set; }
        public MembershipDetailsReadModel MembershipDetails { get; set; }
        public UserReadModel User { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
