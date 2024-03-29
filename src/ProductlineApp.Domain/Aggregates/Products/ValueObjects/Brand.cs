﻿namespace ProductlineApp.Domain.Aggregates.Products.ValueObjects
{
    public record Brand
    {
        public Brand(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Brand name cannot be null or empty.");

            this.Name = name.Trim().ToLower();
        }

        public string Name { get; private init; }
    }
}
