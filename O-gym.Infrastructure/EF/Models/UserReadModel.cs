using System;

namespace O_gym.Infrastructure.EF.Models
{
    internal class UserReadModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public MembershipReadModel Membership { get; set; }
    }
}
