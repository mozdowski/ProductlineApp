export interface MostPopularProductsChartData {
  productsStatistics: ProductStatistics[];
}

export interface ProductStatistics {
  name: string;
  soldCount: number;
}
