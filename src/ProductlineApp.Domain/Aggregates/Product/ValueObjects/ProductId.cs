﻿namespace ProductlineApp.Domain.Aggregates.Product.ValueObjects
{
    public class ProductId
    {
        private ProductId(Guid value)
        {
            this.Value = value;
        }

        public Guid Value { get; private set; }

        public static ProductId CreateUnique()
        {
            return new ProductId(Guid.NewGuid());
        }

        public static ProductId Create(Guid value)
        {
            return new ProductId(value);
        }
    }
}