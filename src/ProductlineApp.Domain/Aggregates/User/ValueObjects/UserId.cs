namespace ProductlineApp.Domain.Aggregates.User.ValueObjects
{
    public record UserId
    {
        private UserId(Guid value)
        {
            this.Value = value;
        }

        public Guid Value { get; private set; }

        public static UserId CreateUnique()
        {
            return new UserId(Guid.NewGuid());
        }

        public static UserId Create(Guid value)
        {
            return new UserId(value);
        }
    }
}