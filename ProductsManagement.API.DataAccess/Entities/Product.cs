using System.ComponentModel.DataAnnotations;

namespace ProductsManagement.API.DataAccess.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public Decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; } 
    }
}
