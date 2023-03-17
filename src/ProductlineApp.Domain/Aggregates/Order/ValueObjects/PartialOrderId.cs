namespace ProductlineApp.Domain.Aggregates.Order.ValueObjects
{
    public class PartialOrderId
    {
        private PartialOrderId(Guid value)
        {
            this.Value = value;
        }

        public Guid Value { get; private set; }

        public static PartialOrderId CreateUnique()
        {
            return new PartialOrderId(Guid.NewGuid());
        }

        public static PartialOrderId Create(Guid value)
        {
            return new PartialOrderId(value);
        }
    }
}
