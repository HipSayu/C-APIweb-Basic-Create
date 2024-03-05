using System.ComponentModel.DataAnnotations;

namespace ApiBasic.Dtos.Category
{
    public class CreateCategoryDto
    {
        private string _nameCategory;

        [Required]
        [MaxLength(100, ErrorMessage = "Tên loại không quá 100 ký tự")]
        public string CategoryName
        {
            get => _nameCategory;
            set => _nameCategory = value?.Trim();
        }
    }
}
