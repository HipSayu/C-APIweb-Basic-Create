using ApiBasic.Dtos.Category;
using ApiBasic.Entites;
using ApiWebBasicPlatFrom.Dtos.Shared;

namespace ApiBasic.Services.Interfaces
{
    public interface ICategoryServices
    {
        void Create(CreateCategoryDto input);

        void Update(UpdateCategoryDto input);

        PageResultDto<List<Category>> GetAll(FilterDto input);

        void Delete(int id);

    }
}
