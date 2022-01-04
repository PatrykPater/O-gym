namespace O_gym.Infrastructure.EF.ValueObjects
{
    internal class MonthlyMembershipPriceReadModel
    {
        public decimal Value { get; set; }

        protected MonthlyMembershipPriceReadModel()
        {
        }

        public static MonthlyMembershipPriceReadModel Create(decimal value)
        {
            return new MonthlyMembershipPriceReadModel
            {
                Value = value
            };
        }

        public static implicit operator decimal(MonthlyMembershipPriceReadModel price)
            => price.Value;
        public static implicit operator MonthlyMembershipPriceReadModel(decimal price)
            => Create(price);
    }
}
