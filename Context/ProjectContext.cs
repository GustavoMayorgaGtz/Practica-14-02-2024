using Microsoft.EntityFrameworkCore;
using Practica_14_02_2024.Models;

namespace Practica_14_02_2024.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> contextOptions): base(contextOptions)
        {

        }
        public DbSet<Practica_14_02_2024.Models.OrdenCompra>? OrdenCompra { get; set; }
        public DbSet<Practica_14_02_2024.Models.Comprador>? Comprador { get; set; }

        //public DbSet<Comprador> Comprador { get; set; }
        //public DbSet<OrdenCompra> OrdenCompra { get; set; }

    }
}
