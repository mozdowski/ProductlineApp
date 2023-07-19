using ProductlineApp.Domain.Aggregates.Order.Entities;
using ProductlineApp.Domain.Aggregates.Order.ValueObjects;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Domain.Common.Abstractions;
using ProductlineApp.Domain.ValueObjects;

namespace ProductlineApp.Domain.Aggregates.Order.Repository;

public interface IOrderRepository : IRepository<Order, OrderId>
{
    Task<IEnumerable<Document>> GetDocumentsByOrderIdAsync(OrderId orderId);

    Task<Document?> GetDocumentByIdAsync(DocumentId documentId);

    Task<IEnumerable<string>> GetOfferIdsForPlatform(UserId userId, PlatformId platformId);

    Task<bool> IsAnyByPlatformOrderId(UserId userId, PlatformId platformId, string orderId);

    Task<OrderId?> GetOrderIdByPlatformOrder(UserId userId, PlatformId platformId, string orderId);

    Task<Dictionary<string, int>> GetProductsIdsWithCountByUserIdAsync(UserId userId);

    Task<Dictionary<string, int>> GetTodayProductsIdsWithCountByUserIdAsync(UserId userId);

    Task<List<int>> GetWeeklySellsCount(UserId userId);
}
