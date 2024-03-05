using ApiBasic.Services.Interfaces;
using ApiWebBasicPlatFrom.Context;
using ApiWebBasicPlatFrom.Dtos.Product;
using ApiWebBasicPlatFrom.Entites;
using ApiWebCoin.Exceptions;

namespace ApiBasic.Services.Implements
{
    public class ProductService : IProductServices
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(CreateProductDto input)
        {
            if (_context.Products.Any(p => p.ProductID == input.ProductID))
            {
                throw new UserFriendlyExceptions($"TMa Product\"{input.ProductID}\" đã tồn tại");
            }
            _context.Products.Add(
                new Product
                {
                    ProductID = input.ProductID,
                    NameProduct = input.NameProduct,
                    NumberProduct = input.NumberProduct,
                    Price = input.Price,
                }
            );
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product != null)
            {
                throw new UserFriendlyExceptions($" Product\"{id}\" Không tồn tại");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public List<ProductDto> GetAllProducts()
        {
            List<ProductDto> result = new List<ProductDto>();
            var products = _context
                .Products.OrderBy(p => p.Price)
                .ThenByDescending(p => p.NumberProduct);
            foreach (var product in products)
            {
                result.Add(
                    new ProductDto
                    {
                        Id = product.Id,
                        ProductID = product.ProductID,
                        NameProduct = product.NameProduct,
                        Price = product.Price,
                        NumberProduct = product.NumberProduct,
                    }
                );
            }
            return result;
        }

        public ProductDto GetProductById(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product != null)
            {
                throw new UserFriendlyExceptions($" Product\"{id}\" Không tồn tại");
            }
            return new ProductDto
            {
                Id = product.Id,
                ProductID = product.ProductID,
                NameProduct = product.NameProduct,
                Price = product.Price,
                NumberProduct = product.NumberProduct,
            };
        }

        public List<ProductDto> GetProductByPricesMax()
        {
            List<ProductDto> result = new List<ProductDto>();
            var priceMax = _context.Products.Max(p => p.Price);
            var products = _context.Products.Where(p => p.Price == priceMax);

            foreach (var product in products)
            {
                result.Add(
                    new ProductDto
                    {
                        Id = product.Id,
                        ProductID = product.ProductID,
                        NameProduct = product.NameProduct,
                        Price = product.Price,
                        NumberProduct = product.NumberProduct,
                    }
                );
            }
            return result;
        }

        public List<Product> GetProductsFromTo(double? from, double? to)
        {
            var product = _context.Products.AsQueryable();
            if (!from.HasValue)
            {
                throw new UserFriendlyExceptions($"Nhap vao");
            }
            if (!to.HasValue)
            {
                throw new UserFriendlyExceptions($"Nhap vao");
            }
            product = product.Where(p => p.Price >= from);
            product = product.Where(p => p.Price <= to);

            return product.ToList();
        }

        public List<Product> GetProductsWithSearch(string search)
        {
            var product = _context.Products.AsQueryable();
            if (string.IsNullOrEmpty(search))
            {
                throw new UserFriendlyExceptions($"nhap vao search");
            }
            product = product.Where(p => p.NameProduct.Contains(search));
            return product.ToList();
        }

        public void Update(UpdateProductDto input)
        {
            var product = _context.Products.SingleOrDefault( p => p.Id == input.Id );
            if (product == null)
            {
                throw new UserFriendlyExceptions($"Không tồn tại product nào có Id là {input.Id}");
            }
            product.NumberProduct = input.NumberProduct;
            product.Price = input.Price;
            product.ProductID = input.ProductID;
            _context.SaveChanges();
            
        }
    }
}
