using System.ComponentModel.DataAnnotations;

namespace InventoryManagementApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Name can't exceed 100 characters.")]
        public string Name { get; set; }

        [Range(1, 100000, ErrorMessage = "Price must be between 1 and 100000.")]
        public decimal Price { get; set; }

        [StringLength(300, ErrorMessage = "Description can't exceed 300 characters.")]
        public string Description { get; set; }
    }
}
