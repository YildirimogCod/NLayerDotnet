﻿using App.Repositories.Categories;

namespace App.Repositories.Products
{
    public class Product:IAuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public Category category { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime ?UpdatedAt { get; set; }
    }
}
