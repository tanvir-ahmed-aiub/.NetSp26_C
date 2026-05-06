using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public double Price { get; set; }

        public int Qty { get; set; }

        public int Cid { get; set; }
    }
}
