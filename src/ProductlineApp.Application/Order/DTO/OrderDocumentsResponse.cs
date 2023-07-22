namespace ProductlineApp.Application.Order.DTO;

public class OrderDocumentsResponse
{
    public IEnumerable<OrderDocumentResponse> OrderDocuments { get; set; }

    public class OrderDocumentResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }
    }
}
