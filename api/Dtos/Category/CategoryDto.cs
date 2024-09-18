using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Product;


namespace api.Dtos.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<ProductDto> Products { get; set; } = [];
    }
}