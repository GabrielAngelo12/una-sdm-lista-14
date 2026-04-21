using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CacauShowApi324118333.Models;
using Microsoft.EntityFrameworkCore;

namespace CacauShowApi324118333.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<Franquia> Franquias => Set<Franquia>();
        public DbSet<LoteProducao> LoteProducoes => Set<LoteProducao>();
        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<Produto> Produtos => Set<Produto>();
        
    }
}