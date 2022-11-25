using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Product : BaseEntity<int>
    {
        [Key]
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
    }
}