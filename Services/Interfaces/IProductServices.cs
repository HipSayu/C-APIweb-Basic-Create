using ApiBasic.Dtos.Product;
using ApiWebBasicPlatFrom.Dtos.Product;
using ApiWebBasicPlatFrom.Entites;

namespace ApiBasic.Services.Interfaces
{
    public interface IProductServices
    {
        List<ProductCategoryDto> GetAllProducts();

        ProductDto GetProductById(int id);

        void Create(CreateProductDto input);

        void Update(UpdateProductDto input);

        void Delete(int id);

        List<ProductDto> GetProductByPricesMax();

        List<Product> GetProductsWithSearch(string search);
        List<Product> GetProductsFromTo(double? from, double? to);

        //Querry one to many

        List<ProductCategoryDto> GetProductByCagetogry (string Namecagetogry);
    }
}
