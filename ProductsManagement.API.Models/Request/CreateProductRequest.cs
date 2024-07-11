using System.ComponentModel.DataAnnotations;

namespace ProductsManagement.API.Models.Request
{
    public class CreateProductRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public Decimal Price { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
    }
}