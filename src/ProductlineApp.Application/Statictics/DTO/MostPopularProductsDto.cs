namespace ProductlineApp.Application.Statictics.DTO;

public class MostPopularProductsDto
{
    public IEnumerable<ProductStatistics> ProductsStatistics { get; set; }

    public class ProductStatistics
    {
        public string Name { get; set; }

        public int SoldCount { get; set; }
    }
}
