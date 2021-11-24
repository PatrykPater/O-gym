using Ardalis.GuardClauses;
using O_gym.Domain.Events;
using O_gym.Domain.Exceptions;
using O_gym.Shared.Abstractions.Domain;

namespace games_store.Domain.Entities
{
    public class User: AggregateRoot<User>
    {
        private string _name;
        private string _lastName;
        private string _Email;
        private Membership _membership;

        public User(string name, string lastName, string email)
        {
            _name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
            _lastName = Guard.Against.NullOrWhiteSpace(lastName, nameof(lastName));
            _Email = Guard.Against.NullOrWhiteSpace(email, nameof(email)); ;
        }

        public void AddMembership(ushort months, decimal monthlyprice)
        {
            if (_membership is not null)
            {
                throw new UserAlreadyHasMembershipException();
            }

            _membership = new(months, monthlyprice);

            AddEvent(new UserMembershipAdded(this, _membership));
        }

        public void ExtendMembership(ushort months)
        {
            if (_membership is null)
            {
                throw new UserDoesNotHaveMembershipException();
            }

            _membership.ExtendMembership(months);

            // add domain event and tests
        }

        public void CancelMembership()
        {
            if (_membership is null)
            {
                throw new UserDoesNotHaveMembershipException();
            }

            _membership = null;

            // add domain event and tests
        }
    }
}