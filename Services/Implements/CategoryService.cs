using ApiBasic.Dtos.Category;
using ApiBasic.Entites;
using ApiBasic.Services.Interfaces;
using ApiWebBasicPlatFrom.Context;
using ApiWebBasicPlatFrom.Dtos.Shared;
using ApiWebCoin.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ApiBasic.Services.Implements
{
    public class CategoryService : ICategoryServices
    {

        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)  
        {
            _context = context;
        }
        public void Create(CreateCategoryDto input)
        {
            if(_context.Categories.Any(c => c.CategoryName == input.CategoryName)) 
            {
                throw new UserFriendlyExceptions($"TMa CategoryName \"{input.CategoryName}\" đã tồn tại");
            }
            _context.Categories.Add(new Category
            {
                CategoryName = input.CategoryName,
            });
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.CategoryId == id);
            if(category == null)
            {
                throw new UserFriendlyExceptions($"TMa CategoryName \"{id}\" khong tim thay");
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public PageResultDto<List<Category>> GetAll(FilterDto input)
        {
            var query = _context.Categories.AsQueryable();
            query = query.Skip(input.PageSize *(input.PageIndex - 1)).Take(input.PageSize);
            var total = query.Count();
            return new PageResultDto<List<Category>>
            {
                TotalItem = total,
                Items = query.ToList()
            };
        }
        public void Update(UpdateCategoryDto input)
        {
            var category = _context.Categories.FirstOrDefault(p => p.CategoryId == input.CategoriId);
            if (category == null)
            {
                throw new UserFriendlyExceptions($"TMa CategoryName \"{input.CategoriId}\" khong tim thay");
            }
            category.CategoryName = input.CategoryName;
            _context.SaveChanges();




        }

    }

       
}
