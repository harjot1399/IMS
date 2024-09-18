using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Product
{
    public class UpdateProductDto
    {
        [Required]

        public string? Name { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Description must be at least 10 characters long")]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int QuantityInStock { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}