using Microsoft.EntityFrameworkCore;
using ProductlineApp.Domain.Aggregates.Order;
using ProductlineApp.Domain.Aggregates.Order.Entities;
using ProductlineApp.Domain.Aggregates.Order.Repository;
using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Infrastructure.Persistance.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ProductlineDbContext _context;

    public OrderRepository(
        ProductlineDbContext context)
    {
        this._context = context;
    }

    public async Task<Order?> GetByIdAsync(OrderId id)
    {
        return await this._context.Orders.FindAsync(id);
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await this._context.Orders.ToListAsync();
    }

    public async Task AddAsync(Order entity)
    {
        await this._context.Orders.AddAsync(entity);
        await this._context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order entity)
    {
        await this._context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Order id)
    {
        if (this._context.Entry(id).State is EntityState.Detached)
        {
            return;
        }

        this._context.Orders.Remove(id);
        await this._context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetAllByUserIdAsync(UserId userId)
    {
        return await this._context.Orders.Where(x => x.OwnerId == userId).ToListAsync();
    }

    public async Task<IEnumerable<Document>> GetDocumentsByOrderIdAsync(OrderId orderId)
    {
        return await this._context.Orders
            .Where(x => x.Id == orderId)
            .Include(x => x.Documents)
            .SelectMany(x => x.Documents)
            .ToListAsync();
    }

    public async Task<Document?> GetDocumentByIdAsync(DocumentId documentId)
    {
        return await this._context.Orders
            .Include(x => x.Documents)
            .SelectMany(x => x.Documents)
            .FirstOrDefaultAsync(x => x.Id == documentId);
    }

    public async Task<IEnumerable<string>> GetOfferIdsForPlatform(UserId userId, PlatformId platformId)
    {
        return await this._context.Orders
            .Where(x => x.OwnerId == userId && x.PlatformId == platformId)
            .Select(x => x.PlatformOrderId)
            .ToListAsync();
    }

    public async Task<bool> IsAnyByPlatformOrderId(UserId userId, PlatformId platformId, string orderId)
    {
        return await this._context.Orders
            .Where(x => x.OwnerId == userId && x.PlatformId == platformId && x.PlatformOrderId == orderId)
            .AnyAsync();
    }

    public async Task<OrderId?> GetOrderIdByPlatformOrder(UserId userId, PlatformId platformId, string orderId)
    {
        return await this._context.Orders
            .Where(x => x.OwnerId == userId && x.PlatformId == platformId && x.PlatformOrderId == orderId)
            .Select(x => x.Id)
            .FirstOrDefaultAsync();
    }
}
