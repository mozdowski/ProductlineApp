namespace ProductlineApp.WebUI.Services.Products
{
    public interface IProductService
    {
        public Task<GetProductResult> GetProductById(Guid id);

        public Task<Guid> CreateProduct(NewProductRequest newProduct);

        public Task<Guid> DeleteProduct(Guid id);

        public Task EditProduct(NewProductRequest newProduct);
    }
}
