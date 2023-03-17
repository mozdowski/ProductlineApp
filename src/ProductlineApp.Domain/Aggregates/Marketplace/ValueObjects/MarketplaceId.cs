using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductlineApp.Domain.Aggregates.Marketplace.ValueObjects
{
    public class MarketplaceId
    {
        private MarketplaceId(Guid value)
        {
            this.Value = value;
        }

        public Guid Value { get; private set; }

        public static MarketplaceId CreateUnique()
        {
            return new MarketplaceId(Guid.NewGuid());
        }

        public static MarketplaceId Create(Guid value)
        {
            return new MarketplaceId(value);
        }
    }
}