using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class ProductType : BaseEntity<int>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}