using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class ProductBrand : BaseEntity<int>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}