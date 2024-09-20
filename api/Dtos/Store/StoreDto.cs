using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Store
{
    public class StoreDto
    {
        public int Id { get; set; } // Primary Key

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Province { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }
    }
}