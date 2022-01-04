using Ardalis.GuardClauses;
using O_gym.Domain.Events;
using O_gym.Domain.Exceptions;
using O_gym.Shared.Abstractions.Domain;
using System;

namespace O_gym.Domain.Entities
{
    public class User: AggregateRoot<Guid>
    {
        private string _name;
        private string _lastName;
        private string _Email;
        private Membership _membership;

        public DateTime? MembershipExpirationDate =>
            _membership?.ExpirationDate;

        public User(string name, string lastName, string email)
        {
            _name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
            _lastName = Guard.Against.NullOrWhiteSpace(lastName, nameof(lastName));
            _Email = Guard.Against.NullOrWhiteSpace(email, nameof(email)); ;
        }

        public void AddMembership(ushort months, int membershipId)
        {
            if (_membership is not null)
            {
                throw new UserAlreadyHasMembershipException();
            }

            _membership = Membership.Create(months, membershipId);

            AddEvent(new UserMembershipAdded(this, _membership));
        }

        public void ExtendMembership(ushort months)
        {
            if (_membership is null)
            {
                throw new UserDoesNotHaveMembershipException();
            }

            _membership.ExtendMembership(months);

            AddEvent(new UserMembershipExtended(this, _membership));
        }

        public void CancelMembership()
        {
            if (_membership is null)
            {
                throw new UserDoesNotHaveMembershipException();
            }

            var id = _membership.Id;

            AddEvent(new UserMembershipCancelled(this, id));
        }

        public void ChangeMembership(int membershipDetailsId)
        {
            if (_membership is null)
            {
                throw new UserDoesNotHaveMembershipException();
            }

            if (membershipDetailsId == _membership.MembershipDetails.Id)
            {
                throw new UserMembershipCannotBeChangedToTheSameMembership();
            }

            var months = _membership.RemainingMonths;
            var oldMembership = _membership;

            _membership = Membership.Create(months, membershipDetailsId);

            AddEvent(new UserMembershipChanged(this, _membership, oldMembership));
        }
    }
}