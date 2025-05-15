using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Web.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống nha!")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Giá không được để trống nha!")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
        public List<string> Images { get; set; }
        public List<string> Authors { get; set; }
    }
}
