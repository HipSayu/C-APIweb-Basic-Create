using ApiWebBasicPlatFrom.Dtos.Product;
using ApiWebBasicPlatFrom.Entites;

namespace ApiBasic.Services.Interfaces
{
    public interface IProductServices
    {
        List<ProductDto> GetAllProducts();

        ProductDto GetProductById(int id);

        void Create(CreateProductDto input);

        void Update(UpdateProductDto input);

        void Delete(int id);

        List<ProductDto> GetProductByPricesMax();

        List<Product> GetProductsWithSearch(string search);
        List<Product> GetProductsFromTo(double? from, double? to);
    }
}
