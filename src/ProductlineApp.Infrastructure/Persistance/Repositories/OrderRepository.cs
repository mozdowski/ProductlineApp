using ProductlineApp.Domain.Aggregates.Order;
using ProductlineApp.Domain.Aggregates.Order.Entities;
using ProductlineApp.Domain.Aggregates.Order.Repository;
using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Infrastructure.Persistance.Repositories;

public class OrderRepository : IOrderRepository
{
    public async Task<Order> GetByIdAsync(OrderId id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Order entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Order entity)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveAsync(Order id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Order>> GetAllByUserIdAsync(UserId userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Document>> GetDocumentsByOrderIdAsync(OrderId orderId)
    {
        throw new NotImplementedException();
    }

    public async Task<Document> GetDocumentByIdAsync(DocumentId documentId)
    {
        throw new NotImplementedException();
    }
}
