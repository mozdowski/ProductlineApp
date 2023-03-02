namespace ProductlineApp.WebUI.Services.Products
{
    public class ProductService : IProductService
    {
        public Task<Guid> CreateProduct(NewProductRequest newProduct)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task EditProduct(NewProductRequest newProduct)
        {
            throw new NotImplementedException();
        }

        public Task<GetProductResult> GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
