using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class BasketItemDto
    {
        [Required] public int Id { get; set; }
        [Required] public string ProductName { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than Zero(0)")]
        public decimal Price { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = " Quantity must be at least One(1)")]
        public int Quantity { get; set; }
        [Required] public string pictureUrl { get; set; }
        [Required] public string ProductBrand { get; set; }
        [Required] public string ProductType { get; set; }
    }
}
