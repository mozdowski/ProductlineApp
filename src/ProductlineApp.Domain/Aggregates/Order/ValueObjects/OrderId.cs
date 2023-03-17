namespace ProductlineApp.Domain.Aggregates.Order.ValueObjects
{
    public record OrderId
    {
        private OrderId(Guid value)
        {
            this.Value = value;
        }

        public Guid Value { get; private set; }

        public static OrderId CreateUnique()
        {
            return new OrderId(Guid.NewGuid());
        }

        public static OrderId Create(Guid value)
        {
            return new OrderId(value);
        }
    }
}
