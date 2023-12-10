using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_GRUPO3.Models;
using System.Collections.Generic;


namespace TP_GRUPO3.Context
{
    public class NegocioDatabaseContext : DbContext
    {
        public NegocioDatabaseContext(DbContextOptions<NegocioDatabaseContext> options) : base(options) 
        {
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Carrito>? Carrito { get; set; }
        //public DbSet<TP_GRUPO3.Models.Carrito>? Carrito { get; set; }
       

    }
}
