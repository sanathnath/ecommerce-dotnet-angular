using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Price { get; set; }
        public string Discount { get; set; }
        public string Quantity { get; set; }
        public string Description { get; set; }
        public List<PhotoDto> Photos { get; set; }
    }
}