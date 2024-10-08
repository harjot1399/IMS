using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int QuantityInStock { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}