using ApiBasic.Dtos.Product;
using ApiBasic.Entites;
using ApiBasic.Services.Interfaces;
using ApiWebBasicPlatFrom.Context;
using ApiWebBasicPlatFrom.Dtos.Product;
using ApiWebBasicPlatFrom.Entites;
using ApiWebCoin.Exceptions;
using Microsoft.EntityFrameworkCore;

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
                    IdCategory = input.IdCategory
                }
            );
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new UserFriendlyExceptions($" Product\"{id}\" Không tồn tại");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public List<ProductCategoryDto> GetAllProducts()
        {
            List<ProductCategoryDto> result = new List<ProductCategoryDto>();
            var products = _context
                .Products.OrderBy(p => p.Price)
                .ThenByDescending(p => p.NameProduct);
            foreach (var product in products)
            {
                result.Add(
                    new ProductCategoryDto
                    {
                        Id = product.Id,
                        ProductID = product.ProductID,
                        NameProduct = product.NameProduct,
                        Price = product.Price,
                        NumberProduct = product.NumberProduct,
                        CategoryName = product.NameProduct,
                        IdCategory = product.IdCategory,
                    }
                );
            }
            return result;
        }

        public ProductDto GetProductById(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
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
            var product = _context.Products.SingleOrDefault(p => p.Id == input.Id);
            if (product == null)
            {
                throw new UserFriendlyExceptions($"Không tồn tại product nào có Id là {input.Id}");
            }
            product.NumberProduct = input.NumberProduct;
            product.Price = input.Price;
            product.ProductID = input.ProductID;
            _context.SaveChanges();
        }

        public List<ProductCategoryDto> GetProductByCagetogry(string Namecagetogry)
        {
            var result =
                from category in _context.Categories
                join product in _context.Products on category.CategoryId equals product.IdCategory
                where category.CategoryName.Equals(Namecagetogry)
                select new ProductCategoryDto
                {
                    Id = product.Id,
                    ProductID = product.ProductID,
                    IdCategory = product.IdCategory,
                    CategoryName = category.CategoryName,
                    NameProduct = product.NameProduct,
                    NumberProduct = product.NumberProduct,
                    Price = product.Price,
                };
            return result.ToList();
        }

        public List<Product> GetProductInOrder(int OrderId)
        {
            var query =
                from product in _context.Products
                join orderDetail in _context.OrderDetails on product.Id equals orderDetail.ProductId
                where orderDetail.OrderId == OrderId
                select product;
            return query.ToList();
        }

        public List<ProductDto> GetProductWithPriceMaxInOrder(int OrderId)
        {
            var query =
                from product in _context.Products
                join orderDetail in _context.OrderDetails on product.Id equals orderDetail.ProductId
                where orderDetail.OrderId == OrderId
                select product;
            var PriceMax = query.Max(x => x.Price);
            var result =
                from product in _context.Products
                join orderDetail in _context.OrderDetails on product.Id equals orderDetail.ProductId
                where orderDetail.OrderId == OrderId && product.Price >= PriceMax
                select new ProductDto
                {
                    Price = product.Price,
                    NameProduct = product.NameProduct,
                    NumberProduct = product.NumberProduct,
                    Id = orderDetail.OrderId,
                    ProductID = product.ProductID
                };
            return result.ToList();
        }

        public List<ProductCategoryDto> GetProductWithCategoryInOrder(
            string CategoryName,
            int OrderId
        )
        {
            var query =
                from category in _context.Categories
                join product in _context.Products on category.CategoryId equals product.IdCategory
                where category.CategoryName == CategoryName
                select new
                {
                    Price = product.Price,
                    NameProduct = product.NameProduct,
                    NumberProduct = product.NumberProduct,
                    ProductID = product.ProductID,
                    Id = product.Id,
                    CategoryName = category.CategoryName,
                    CategoryId = category.CategoryId,
                };
            var result =
                from a in query
                join orderDetail in _context.OrderDetails on a.Id equals orderDetail.ProductId
                where orderDetail.OrderId == OrderId
                select new ProductCategoryDto
                {
                    CategoryName = a.CategoryName,
                    Id = a.Id,
                    IdCategory = a.CategoryId,
                    NameProduct = a.NameProduct,
                    NumberProduct = a.NumberProduct,
                    Price = a.Price,
                    ProductID = a.ProductID
                };
            return result.ToList();
        }
    }
}
