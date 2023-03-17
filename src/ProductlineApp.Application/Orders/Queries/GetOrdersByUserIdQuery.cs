using AutoMapper;
using FluentValidation;
using ProductlineApp.Application.Common.Interfaces;
using ProductlineApp.Application.Orders.Models;

namespace ProductlineApp.Application.Orders.Queries;

public class GetOrdersByUserIdQuery
{
    public record Query(Guid UserId) : IQuery<OrdersDtoResponse>;

    public class Validator : AbstractValidator<OrdersDtoResponse>
    {
        public Validator()
        {
        }
    }

    public class Handler : IQueryHandler<Query, OrdersDtoResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public Handler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<OrdersDtoResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            var auctionOrders = this._context.AuctionOrders
                .Where(x => x.Auction.Owner.Id == request.UserId);

            var orders = this._context.Orders.Where(x => x.AuctionOrder);

            return this._mapper.Map<OrdersDtoResponse>(orders);
        }
    }
}
