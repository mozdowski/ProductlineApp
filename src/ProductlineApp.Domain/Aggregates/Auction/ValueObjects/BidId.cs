using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductlineApp.Domain.Aggregates.Auction.ValueObjects
{
    public class BidId
    {
        private BidId(Guid value)
        {
            this.Value = value;
        }

        public Guid Value { get; private set; }

        public static BidId CreateUnique()
        {
            return new BidId(Guid.NewGuid());
        }

        public static BidId Create(Guid value)
        {
            return new BidId(value);
        }
    }
}