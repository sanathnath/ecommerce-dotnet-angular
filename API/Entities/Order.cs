namespace API.Entities
{
    public class Order
    {
        public AppProduct Product { get; set; }
        public DateTime OrderedDate { get; set; } = DateTime.UtcNow;
    }
}