﻿using Microsoft.EntityFrameworkCore;

namespace APIProducto.Models.Data
{
    public class ProductosContext : DbContext
    {
        public ProductosContext(DbContextOptions<ProductosContext> options) : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
    }
}
