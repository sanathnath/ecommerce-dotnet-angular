namespace API.Entities
{
    public class AppProduct
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
        public string Quantity { get; set; }
        public string Description { get; set; }
        public List<Photo> Photos { get; set; } = new();
    }
}