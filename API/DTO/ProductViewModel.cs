using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
    }
}
