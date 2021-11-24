using O_gym.Domain.Exceptions;

namespace O_gym.Domain.ValueObjects
{
    public record MonthlyMembershipPrice
    {
        public decimal Value { get; }

        public MonthlyMembershipPrice(decimal value)
        {
            if (value <= 0)
            {
                throw new InvalidPriceValueException();
            }

            Value = value;
        }

        public static implicit operator decimal(MonthlyMembershipPrice price)
            => price.Value;
        public static implicit operator MonthlyMembershipPrice(decimal price)
            => new(price);
    }
}