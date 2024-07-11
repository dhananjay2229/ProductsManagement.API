﻿namespace ProductsManagement.API.Models.Response
{
    public class ProductResponseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Decimal ? Price { get; set; }
        public int? Quantity { get; set; }
    }
}
