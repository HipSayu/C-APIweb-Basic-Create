namespace ApiBasic.Dtos.Product
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }

        public string ProductID { get; set; }

        public string CategoryName { get; set; }

        public int IdCategory { get; set; }

        public string NameProduct { set; get; }

        public int NumberProduct { get; set; }

        public double Price { get; set; }
    }
}
