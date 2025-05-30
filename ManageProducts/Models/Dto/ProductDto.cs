﻿using System.ComponentModel.DataAnnotations;

namespace ManageProducts.Models.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public string ImageUrl { get; set; }
    }
}
