namespace Ecommerce.Web.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
        public List<string> Images { get; set; }
        public List<string> Authors { get; set; }
    }
}
